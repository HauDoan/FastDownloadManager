using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using VideoLibrary;

namespace FastDownloadManager
{
    public partial class Form1 : Form
    {
        /*
        Chương trình sau khi lấy link download sẽ xét đường link
        - TH1: Nếu đường link là youtube hoặc tải file extension (.exe, .iso, ... )
                --> thì thực hiện lấy length của file:
            + B1: Sau đó chia file thành 4 part nhỏ (cài đặt của nhóm)
            + B2: Khởi tạo đối tượng FileDownloader (Class FileDownloader ở cuối file)
                chứa các thông tin của part nhỏ 
                    -> Vị trí bắt tải của file part nhỏ
                    -> Tổng length của file part nhỏ
                    -> đường link download của file
                    -> đường dẫn thư mục download
                    -> Tên file download
                    -> index của file download trong bảng Download
                    -> thứ tự của các file part nhỏ
            + B3: Sử dụng HttpWebRequest, task để tải các part nhỏ cùng lúc
            + B4: Sau khi tải xong các part nhỏ
                --> Gộp các part nhỏ lại thành file hoàn chỉnh
                --> Thông báo cho người dùng
        - TH2: Nếu file extension không có (nghĩa là tải html) thì sẽ thực hiện
            download file html bằng WebClient, thread 
            (vì kích thước file khá nhỏ)

            {Mỗi file sẽ được tải bằng 4 tasks riêng biệt, nhiều file được tải bằng nhiều threads
            khác nhau}
        */


        /*
         Tạo dictionary với Key: tên file, Value: giá trị (0, 1, 2)
            - 0 là running
            - 1 là pause
            - 2 là cancel
            --> dành cho chức năng (stop: pause, resume, cancel)
         */
        public volatile Dictionary<string, int> ListStatus = new Dictionary<string, int>();

        //Cài đặt về phần giao diện
        List<string> proc = new List<string>();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect,
            int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        int count = 0;
        int mov;
        int movX;
        int movY;
        static string dir = Path.GetDirectoryName(Application.ExecutablePath).ToString().Replace(
            @"bin\Debug\net5.0-windows", string.Empty);

        //Hình ảnh cho các nút play, stop, resume, cancel, delete
        Image play = Image.FromFile(dir + "/IconFolder/icons8-play-50.png");
        Image stop = Image.FromFile(dir + "/IconFolder/icons8-pause-52.png");
        Image resume = Image.FromFile(dir + "/IconFolder/icons8-memories-64.png");
        Image cancel = Image.FromFile(dir + "/IconFolder/icons8-cancel-60.png");
        Image delete = Image.FromFile(dir + "/IconFolder/icons8-remove-50.png");

        Image stopHide = Image.FromFile(dir + "/IconFolder/icons8-pause-hide-52.png");
        Image resumeHide = Image.FromFile(dir + "/IconFolder/icons8-memories-hide-64.png");
        Image cancelHide = Image.FromFile(dir + "/IconFolder/icons8-cancel-hide-60.png");

        //Khởi tạo WebClient để tải file html
        WebClient client = new WebClient();



        //Form1: FastDownloadManager
        public Form1()
        {
            InitializeComponent();
            proc.Add("");
            proc.Add("");
            proc.Add("");
            proc.Add("");

            //Bo tròn form
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn
                (0, 0, Width, Height, 20, 20));

            txtPath.Text = dir + @"DownloadFolder";

            //Ẩn nút pauseAll, resumeAll, CancelAll
            btnPauseAll.Image = stopHide;
            btnResumeAll.Image = resumeHide;
            btnCancelAll.Image = cancelHide;

            btnCancelAll.Enabled = false;
            btnResumeAll.Enabled = false;
            btnPauseAll.Enabled = false;

        }

        //Thêm một link vào table Download
        private void addItem(Image play, string urlname, string filename, string status,
            string total, string speed, string timeleft, string lastry, string process1, string process2, string process3,
            string process4, Image stop, Image resume, Image cancel, Image delete)
        {

            int rowId = tblDownload.Rows.Add();
            DataGridViewRow row = tblDownload.Rows[rowId];

            row.Cells[0].Value = play;
            row.Cells[1].Value = urlname;
            row.Cells[2].Value = filename;
            row.Cells[3].Value = status;
            row.Cells[4].Value = total;
            row.Cells[5].Value = speed;
            row.Cells[6].Value = timeleft;
            row.Cells[7].Value = lastry;
            row.Cells[8].Value = process1;
            row.Cells[9].Value = process2;
            row.Cells[10].Value = process3;
            row.Cells[11].Value = process4;
            row.Cells[12].Value = stop;
            row.Cells[13].Value = resume;
            row.Cells[14].Value = cancel;
            row.Cells[15].Value = delete;

        }

        //Close form (nút Close)
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to close FastDownloadManager??",
                                     "Confirm Close",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }



        //Hàm tải về file lớn hoàn chỉnh
        /*
        Từ url --> Lấy file extension
        - Nếu extension không có (tải file html) --> thực hiện tải html bằng 1 luồng (WebClient)
        - Nếu extension là exe, iso:
            *(Phần giao diện được update liên tục trạng thái của file download)
            + B1: Lấy length của file
            + B2: Chia file thành 4 phần bằng nhau
            + B3: Khởi tạo các đối tượng FileDownloader chứa thông tin của các part nhỏ
            + B4: Tạo 4 tasks để tải 4 part nhỏ (truyền FileDownloader vào hàm DownloadPart)
            + B5: Sau khi tải xong 
                --> gọi hàm gộp các part nhỏ thành file lớn hoàn chỉnh
                --> gọi hàm xóa các part nhỏ
                --> Thông báo cho người dùng
         */
        public void Download(object url1)
        {
            try
            {
                //Truyền object (UrlInd) vào
                var urlTemp = url1 as UrlInd;

                //Lấy index từ bảng Download
                int ind = urlTemp.ind;

                //Lấy url
                string url = urlTemp.url.ToString();
                Uri uri = new Uri(url);

                //Lấy file extension
                string ext = System.IO.Path.GetExtension(url);

                //Lấy tên File
                string fileName = tblDownload.Rows[ind].Cells[2].Value.ToString();

                //Hiển thị Downloading trong bảng Download
                tblDownload.Rows[ind].Cells[3].Value = "Downloading...";

                //TH1: Nếu là file html sẽ download bằng WebClient
                if (ext == "" && !url.Contains("youtube.com"))
                {
                    Extension extension = IFactory.getExtension(ExtensionType.HTML ,uri, url, ind, txtPath.Text, fileName);
                    extension.run();

                }

                //TH2: Ngược lại --> Chia nhỏ file để download
                else
                {
                    Extension extension = IFactory.getExtension(ExtensionType.FILE, uri, url, ind, txtPath.Text, fileName);
                    extension.run();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Cancel the file hasn't download and click Play again");
            }
        }

        
        
        public bool checkDoneAll()
        {
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                if (r.Cells[3].Value.ToString() == "Downloading...")
                {
                    /*Trả về false nếu có ít nhất 1 file trong table Download
                    có trạng thái Downloading*/
                    return false;
                }
            }
            //Trả về true nếu không có file nào có trạng thái Downloading
            return true;
        }

        //Hàm delete các part file tạm khi nhấn vào Stop
        //Hàm này phục vụ cho nút Cancel All
        /*
            Khi nhấn vào Stop
            --> Xét tất cả file trong thư mục Download
            --> File nào là file tạm (tên chứa temp$) thì tiến hành xóa file
         */
        public void DeleteOnCancelAll()
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(txtPath.Text);

                //Lấy tất cả file trong thư mục download
                FileInfo[] Files = d.GetFiles("*");
                string str = "";

                foreach (FileInfo file in Files)
                {
                    //Lấy tên file
                    str = file.Name;

                    //Nếu file là file tạm (có cữ temp$)
                    if (str.Contains("temp$"))
                    {
                        //Thì xóa file
                        file.Delete();
                    }
                }
            }
            //Trường hợp temp file không xóa được vì đang thao tác (chưa break kịp)
            catch (Exception)
            {
                MessageBox.Show("Please wait a second. Try again later.");
            }
        }

        //Hàm set Cancel file đang download
        //Hàm này phục vụ cho chức năng Cancel All
        /*
            Xét tất cả file trong table Download
            File nào đang Download thì set Cancel
         */
        public void SetCancelAll()
        {
            //Duyệt các file download trong table Download
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                //file nào có trạng thái Downloading hoặc Pause thì đặt trạng thái về Cancel
                if (r.Cells[3].Value.ToString() == "Downloading..."
                    || r.Cells[3].Value.ToString() == "Pause...")
                {
                    //Set trạng thái Cancel
                    r.Cells[3].Value = "Canceled";
                }
            }
        }

        //Hàm set Pause file đang download
        //Hàm này phục vụ cho chức năng Pause All
        /*
            Xét tất cả file trong table Download
            File nào đang Download thì set Pause
         */
        public void SetPauseAll()
        {
            //Duyệt các file download trong table Download
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                //file nào có trạng thái Downloading thì đặt trạng thái về Pause
                if (r.Cells[3].Value.ToString() == "Downloading...")
                {
                    //Set trạng thái Pause
                    r.Cells[3].Value = "Pause...";
                }
            }
        }

        //Hàm set Resume file đang download
        //Hàm này phục vụ cho chức năng Resume All
        /*
            Xét tất cả file trong table Download
            File nào đang Pause thì set Resume
         */
        public void SetResumeAll()
        {
            //Duyệt các file download trong table Download
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                //file nào có trạng thái Pause thì đặt trạng thái về Downloading
                if (r.Cells[3].Value.ToString() == "Pause...")
                {
                    //Set trạng thái Downloading
                    r.Cells[3].Value = "Downloading...";
                }
            }
        }

        //Nhấn vào nút Pause All
        private void btnPauseAll_Click(object sender, EventArgs e)
        {
            //set all status = 1 --> pause
            foreach (var key in ListStatus.Keys)
            {
                ListStatus[key] = 1;
            }

            //Set giao diện nút pause, resume, cancel
            btnPauseAll.Image = stopHide;
            btnResumeAll.Image = resume;
            btnCancelAll.Image = cancel;

            //Set nút pause -> disable, resume -> enable, cancel -> enable
            btnPauseAll.Enabled = false;
            btnResumeAll.Enabled = true;
            btnCancelAll.Enabled = true;

            //Hiểm thị Pause trên table Download
            SetPauseAll();

            //Thông báo
            MessageBox.Show("Pause All");
        }

        //Nhấn vào nút Resume All
        private void btnResumeAll_Click(object sender, EventArgs e)
        {
            //set all status = 0 --> download
            foreach (var key in ListStatus.Keys)
            {
                ListStatus[key] = 0;
            }

            //Set giao diện nút pause, resume, cancel
            btnResumeAll.Image = resumeHide;
            btnPauseAll.Image = stop;
            btnCancelAll.Image = cancel;

            //Set nút pause -> enable, resume -> disable, cancel -> enable
            btnResumeAll.Enabled = false;
            btnPauseAll.Enabled = true;
            btnCancelAll.Enabled = true;

            //Hiển thị trạng thái resume
            SetResumeAll();

            //Thông báo
            MessageBox.Show("Resume All");
        }

        //Nhấn vào nút Cancel All
        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            //set all status = 2 --> cancel
            foreach (var key in ListStatus.Keys)
            {
                ListStatus[key] = 2;
            }

            //Thông báo
            MessageBox.Show("Cancel All");

            //Set giao diện nút pause, resume, cancel
            btnCancelAll.Image = cancelHide;
            btnResumeAll.Image = resumeHide;
            btnPauseAll.Image = stopHide;

            //Set nút pause -> disable, resume -> disable, cancel -> disable
            btnResumeAll.Enabled = false;
            btnPauseAll.Enabled = false;
            btnCancelAll.Enabled = false;

            //Cho nghỉ 2s để thread, task tắt hoàn toàn
            Thread.Sleep(2000);

            //Xóa file tạm
            DeleteOnCancelAll();

            //Hiển thị Cancel trên table Download
            SetCancelAll();
        }

        //Hàm kiểm tra xem table Download còn file nào đang download hay không
        //Phục vụ cho xét nút PauseAll, ResumeAll
        //Trả về false Nếu còn ít nhất 1 file đang download
        public bool IsPauseAll()
        {
            //Duyệt các file download trong table Download
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                //file nào có trạng thái Downloading thì return false
                if (r.Cells[3].Value.ToString() == "Downloading...")
                {
                    return false;
                }
            }
            return true;
        }

        //Hàm kiểm tra xem table Download còn file nào đang pause hay không
        //Phục vụ cho xét nút PauseAll, ResumeAll
        //Trả về false Nếu còn ít nhất 1 file đang pause

        public bool IsResumeAll()
        {
            //Duyệt các file download trong table Download
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                //file nào có trạng thái Pause thì return false
                if (r.Cells[3].Value.ToString() == "Pause...")
                {
                    return false;
                }
            }
            return true;
        }

        //Hàm kiểm tra xem table Download còn file nào đang pause hoặc download hay không
        //Phục vụ cho xét nút CancelAll
        //Trả về false Nếu còn ít nhất 1 file đang pause hoặc downloading
        public bool IsCancelAll()
        {
            //Duyệt các file download trong table Download
            foreach (DataGridViewRow r in tblDownload.Rows)
            {
                //file nào có trạng thái Pause hoặc Download thì return false
                if (r.Cells[3].Value.ToString() == "Pause..."
                    || r.Cells[3].Value.ToString() == "Downloading...")
                {
                    return false;
                }
            }
            return true;
        }

        //Content Click trong bảng Download
        /*
            Gồm các thao tác khi nhấn Play, Stop: Pause, Resume, Cancel, Delete
         */
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Nút
            String playbtn = tblDownload.Columns[0].HeaderText;
            String stopbtn = tblDownload.Columns[12].HeaderText;
            String resumebtn = tblDownload.Columns[13].HeaderText;
            String cancelbtn = tblDownload.Columns[14].HeaderText;
            String deletebtn = tblDownload.Columns[15].HeaderText;

            var senderGrid = (DataGridView)sender;

            client = new WebClient();

            if (e.RowIndex != -1)
            {

                //Nhấn vào nút Play: Start download
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == playbtn)
                {

                    //Nếu file đang tải hoặc đang Pause thì không nhấn được Play
                    if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Downloading..."
                        || tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Pause...")
                    {
                        MessageBox.Show("You must wait for download or Cancel it first");
                    }
                    //Trường hợp ngược lại: nếu file chưa tải, file đã cancel thì mới được Play
                    else
                    {
                      
                        //Thông báo bắt đầu tải file
                        string filename = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                        Task t = Task.Factory.StartNew(() => MessageBox.Show("Start downloading " + filename));

                        //Nhấn vào nút Play sẽ set value = 0 --> Được download lại
                        //Với key là tên file
                        ListStatus[senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()] = 0;

                        //Lấy url index: index trong table Download
                        int urlindex = senderGrid.Rows[e.RowIndex].Cells[1].RowIndex;

                        //Lấy url
                        string url = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();

                        //Trường hợp: tải file youtube
                        //Sử dụng thư viện VideoLibrary
                        if (url.Contains("https://www.youtube.com/watch?"))
                        {
                            var youTube = YouTube.Default;
                            var video = youTube.GetVideo(url);
                            var linkyoutube = new Uri(video.Uri).ToString();
                            url = linkyoutube;
                        }
                     


                        //Tạo thread -> tiến hành download
                        Thread thread = new Thread(Download);

                        //Khởi tạo đối tượng UrlInd gồm (url index và url)
                        //Class UrlInd ở cuối file
                        UrlInd ui = new UrlInd(url, urlindex);

                        //Bắt đầu download
                        thread.Start(ui);
                    }
                    //Set giao diện pause, resume, cancel
                    btnPauseAll.Image = stop;
                    btnResumeAll.Image = resume;
                    btnCancelAll.Image = cancel;

                    //Enable nút PauseAll, CancelAll, CancelAll
                    btnPauseAll.Enabled = true;
                    btnCancelAll.Enabled = true;
                    btnResumeAll.Enabled = true;
                }

                //Nhấn vào nút Stop: Pause download
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == stopbtn)
                {
                    try
                    {
                        //Nếu file chưa được download thì phải nhấn nút Play trước
                        if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Not Start")
                        {
                            MessageBox.Show("Click Play Button First");
                        }
                        //Nếu file đang Pause --> thông báo
                        else if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Pause...")
                        {
                            MessageBox.Show("The file has paused downloading");
                        }
                        //Nếu file đã bị hủy --> thông báo
                        else if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Canceled")
                        {
                            MessageBox.Show("The file has been Canceled");
                        }
                        //Nếu đang tải --> Nhấn Stop được
                        else
                        {
                            //Nhấn vào nút Stop sẽ set value = 1
                            //Với key là tên file
                            ListStatus[senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()] = 1;

                            //Cập nhật trạng thái Pause
                            tblDownload.Rows[e.RowIndex].Cells[3].Value = "Pause...";

                            //Trường hợp không còn file đang download --> disable nút pauseAll
                            if (IsPauseAll())
                            {
                                btnPauseAll.Image = stopHide;
                                btnPauseAll.Enabled = false;
                            }
                            //Nếu còn 1 file đang chạy --> enable nút pauseAll
                            else
                            {
                                btnPauseAll.Image = stop;
                                btnPauseAll.Enabled = true;
                            }

                            //Trường hợp Không còn file đang pause --> disable nút ResumeAll
                            if (IsResumeAll())
                            {
                                btnResumeAll.Image = resumeHide;
                                btnResumeAll.Enabled = false;
                            }
                            //Nếu còn 1 file đang pause --> enable nút resumeAll
                            else
                            {
                                btnResumeAll.Image = resume;
                                btnResumeAll.Enabled = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong. Please Cancel it and try again.");
                    }
                }

                //Nhấn vào nút Resume: Resume download
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == resumebtn)
                {
                    try
                    {
                        //Nếu file chưa được download thì phải nhấn nút Play trước
                        if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Not Start")
                        {
                            MessageBox.Show("Click Play Button First");
                        }
                        //Nếu file đang Download --> thông báo
                        else if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Downloading...")
                        {
                            MessageBox.Show("The file is downloading");
                        }
                        //Nếu file đã bị hủy --> thông báo
                        else if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Canceled")
                        {
                            MessageBox.Show("The file has been Canceled. Click Play button to redownload");
                        }
                        //Nếu đang tải --> Nhấn Stop được
                        else
                        {
                            //Nhấn vào nút Resume sẽ set value = 0
                            //Với key là tên file
                            ListStatus[senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()] = 0;

                            //Cập nhật trạng thái Resume
                            tblDownload.Rows[e.RowIndex].Cells[3].Value = "Downloading...";


                            //Trường hợp không còn file đang pause --> disable nút ResumeAll
                            if (IsResumeAll())
                            {
                                btnResumeAll.Image = resumeHide;
                                btnResumeAll.Enabled = false;
                            }
                            //Nếu còn 1 file đang pause --> enable nút resumeAll
                            else
                            {
                                btnResumeAll.Image = resume;
                                btnResumeAll.Enabled = true;
                            }

                            //Trường hợp không còn file đang download --> disable nút pauseAll
                            if (IsPauseAll())
                            {
                                btnPauseAll.Image = stopHide;
                                btnPauseAll.Enabled = false;
                            }
                            //Nếu còn 1 file đang download --> enable nút pauseAll
                            else
                            {
                                btnPauseAll.Image = stop;
                                btnPauseAll.Enabled = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong. Please Cancel it and try again.");
                    }
                }
                //Nhấn vào nút Cancel: Cancel download
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Cancel")
                {
                    try
                    {
                        //Nếu file chưa được download thì phải nhấn nút Play trước
                        if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString() == "Not Start")
                        {
                            MessageBox.Show("Click Play Button First");
                        }
                        //Trường hợp còn lại
                        else
                        {
                            //Nhấn vào nút Cancel sẽ set value = 2
                            //Với key là tên file
                            ListStatus[senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()] = 2;

                            //Cập nhật trạng thái Canceled
                            senderGrid.Rows[e.RowIndex].Cells[3].Value = "Canceled";

                            //Thông báo Cancel
                            MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()
                                + " Canceled");

                            //Trường hợp đã nhấn Cancel hết --> Disable nút CancelAll, ResumeAll, PauseAll
                            if (IsCancelAll() == true)
                            {
                                btnPauseAll.Image = stopHide;
                                btnResumeAll.Image = resumeHide;
                                btnCancelAll.Image = cancelHide;

                                btnPauseAll.Enabled = false;
                                btnResumeAll.Enabled = false;
                                btnCancelAll.Enabled = false;
                            }
                            //Nếu như còn 1 file đang download hoặc đang pause --> enable nút cancel
                            else
                            {
                                btnCancelAll.Image = cancel;
                                btnCancelAll.Enabled = true;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong. Please Cancel it and try again.");
                    }
                }
                //Nhấn vào nút Delete
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == deletebtn)
                {
                    try
                    {
                        //Kiểm tra tất cả file tải xuống
                        if (!checkDoneAll())
                        {
                            //Nếu còn ít nhất 1 file đang tải thì thông báo 
                            MessageBox.Show("Please wait another file downloading or " +
                                "Cancel All first");
                        }
                        //Ngược lại, tất cả các file phải được tải xuống hoàn tất
                        //mới xóa được file
                        else
                        {
                            //Lấy tên file
                            string fileName = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                            //Lấy đường dẫn + tên file
                            string file = txtPath.Text + "\\" + fileName;

                            foreach (DataGridViewCell oneCell in tblDownload.SelectedCells)
                            {
                                if (oneCell.Selected)
                                {
                                    //Xác nhận xóa
                                    var confirmResult = MessageBox.Show("Are you sure delete '"
                                        + fileName + "' ?", "Confirm Delete",
                                                 MessageBoxButtons.YesNo);
                                    if (confirmResult == DialogResult.Yes)
                                    {
                                        /*
                                         Nếu file tải xuống Completed thì xóa trong bảng Download
                                        (giao diện) và xóa trong thư mục tải xuống
                                         */
                                        if (tblDownload.Rows[e.RowIndex].Cells[3].Value.ToString()
                                            == "Completed")
                                        {
                                            //Xóa trong giao diện
                                            tblDownload.Rows.RemoveAt(oneCell.RowIndex);

                                            //Xóa trong thư mục tải xuống
                                            File.Delete(file);

                                            //Xóa trong dictionary ListStatus
                                            ListStatus.Remove(fileName);
                                        }
                                        /*
                                        Ngược lại nếu chưa tải thì chỉ cần xóa trong giao diện
                                         */
                                        else
                                        {
                                            //Xóa trong giao diện
                                            tblDownload.Rows.RemoveAt(oneCell.RowIndex);

                                            //Xóa trong dictionary ListStatus
                                            ListStatus.Remove(fileName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //Bắt lỗi khi đổi thư mục download và file không còn tồn tại trong thư mục
                    catch (Exception)
                    {
                        MessageBox.Show("File doesn't exists");
                    }
                }
            }
        }


        //public class StartDownFile : Command
        //{
        //    FileDownloader file;
        //    public StartDownFile(FileDownloader file)
        //    {
        //        this.file = file;     
        //    }
        //    public void Execute()
        //    {
        //        file.StartExecute();
        //    }

        //    public void Undo()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}




        //Nhấn vào nút GetLink
        //Hàm này sử dụng để lấy đầy đủ thông tin của link --> hiển thị trên giao diện
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Biến count để các file tải về không bị trùng tên
                //Ví dụ tải Teamview 2 lần thì tên 2 file là Teamview(1).exe, Teamview(2).exe
                count++;

                //Lấy url
                string urlname = txtURL.Text;
                Uri uri = new Uri(urlname);

                //Khởi tạo filename, extension, videoUri (cho video youtube)
                string filename = "";
                string ext = "";
                var videoUri = "";
                YouTubeVideo video;

                //Trường hợp đường link là youtube
                if (urlname.Contains("https://www.youtube.com/watch?"))
                {

                    Task t = Task.Factory.StartNew(() => MessageBox.Show("Please wait a seconds." +
                        " Youtube is processing"));
                    //Sử dụng thư viện Youtube
                    var youTube = YouTube.Default;

                    video = youTube.GetVideo(urlname);

                    //Lấy fileName
                    filename = video.FullName;

                    //Lấy extension
                    ext = System.IO.Path.GetExtension(filename);

                    //Thêm biến count để tên không bị trùng
                    filename = filename.Replace(ext, "(" + count.ToString() + ")" + ext);

                    //Lấy link down video
                    videoUri = new Uri(video.Uri).ToString();

              
                }
                //Trường hợp còn lại
                else
                {
                    //Lấy file name
                    filename = System.IO.Path.GetFileName(uri.LocalPath);

                    //Lấy extension
                    ext = System.IO.Path.GetExtension(urlname);

                    //Nếu không có extension
                    if (ext == "")
                    {
                        //Trường hợp tải file trên github
                        if (urlname.Contains("https://github.com"))
                        {
                            //Nếu người dùng nhập vào link repo
                            //--> Cộng thêm đuôi /archive/refs/heads/master.zip để tải file
                            urlname = urlname + "/archive/refs/heads/master.zip";

                            //filename
                            filename = filename + "(" + count + ").zip";
                        }
                        //Trường hợp ngược lại: Tải file html
                        else
                        {
                            filename = filename + "(" + count.ToString() + ")" + ".html";
                        }
                    }
                    //Trường hợp có extension --> Tải file
                    else
                    {
                        filename = filename.Replace(ext, "(" + count.ToString() + ")" + ext);
                    }
                }

                //Thêm trạng thái tải file vào dictionary ListStatus
                ListStatus.Add(filename, 0);

                //Cập nhật thời gian bắt đầu tải
                string lastry = DateTime.Now.ToString();

                //Không nhập URL --> Hiển thị thông báo
                if (urlname == "")
                {
                    MessageBox.Show("Please Enter URL");
                    txtURL.Focus();
                }
                //Thư mục Download trống --> Hiển thị thông báo
                else if (txtPath.Text == "")
                {
                    MessageBox.Show("Please Choose Your Download Folder First");
                }
                //Trường hợp nhập link đúng
                else
                {
                    //Trường hợp link là github
                    if (urlname.Contains("https://github.com"))
                    {
                        Task t = Task.Factory.StartNew(() =>
                        {
                            MessageBox.Show("Please wait a second. Github is processing");
                        }
                        );

                        //openread URL
                        client.OpenRead(urlname);

                        //Vì github cần openread nhiều lần mới tải được nên sử dụng vòng lặp
                        //đến khi nào lấy được file để tải
                        double s = Convert.ToDouble(client.ResponseHeaders["Content-Length"]);

                        //Count: Lấy giới hạn openread để tránh bị lỗi
                        int count = 0;

                        //Nếu không lấy được file tải thì open read
                        while (s == 0)
                        {
                            //open read lại
                            client.OpenRead(urlname);

                            //count ++ --> để chắc chắn lấy được file download
                            count++;

                            //Lấy được file tải thì break
                            if (s != 0 || count == 7)
                                break;
                        }
                    }
                    //Trường hợp link là youtube --> đọc uri của video
                    else if (urlname.Contains("https://www.youtube.com/watch?"))
                    {
                        client.OpenRead(videoUri);
                    }
                    //Trường hợp còn lại
                    else
                    {
                        client.OpenRead(urlname);
                    }

                    //Lấy size của file download
                    double size = (Convert.ToDouble(client.ResponseHeaders["Content-Length"]) 
                        / 1048576);
                    
                    //Tổng MB của file
                    string total = $"{string.Format("{0:0.##}", size)} MB";
                    string speed = "0 Mbps";
                    string timeleft = "0 s";
                    
                    //Thêm file vào table Download
                    addItem(play, urlname, filename, "Not Start", total, speed, timeleft, lastry, 
                        "0%", "0%", "0%", "0%", stop, resume, cancel, delete);


                    //Clear ô get lick
                    txtURL.Text = "";
                }
            }
            catch (Exception)
            {
                //Bắt lỗi khi nhập sai link                                 
                MessageBox.Show("Please enter the right link");
            }
        }

        //Hàm tiến trình download file html WebClient
        public void Client_DownloadProgressChanged(object sender, 
            DownloadProgressChangedEventArgs e, string url, int ind)
        {
            if (url == tblDownload.Rows[ind].Cells[1].Value.ToString())
            {
                tblDownload.Invoke(new MethodInvoker(delegate ()
                {
                    double receive = double.Parse(e.BytesReceived.ToString()) / 1048576;
                    double total = double.Parse(e.TotalBytesToReceive.ToString()) / 1048576;
                    double percentage = receive / total * 100;
                    double speed = double.Parse(e.BytesReceived.ToString()) / 1024 / 1024;

                    string total1 = $"{string.Format("{0:0.##}", total)}";

                    tblDownload.Rows[ind].Cells[4].Value 
                        = $"{string.Format("{0:0.##}", total)} MB";
                    tblDownload.Rows[ind].Cells[8].Value 
                        = $"{string.Format("{0:0.##}", percentage)}%";
                }));
            }

        }

        //Nhấn vào nút Open để chọn thư mục download
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("Please Choose Your Download Folder or Set Default!");
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", txtPath.Text);
            }
        }



        //Lấy url để download file
        private String getURL()
        {
            var fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
            }
            return fbd.SelectedPath;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            txtPath.Text = getURL();
        }

        # region Những phần thuộc thao tác về giao diện
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.btnClose.BackColor = Color.LightGray;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.White;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            txtPath.Text = dir + @"DownloadFolder";
        }
        private void label3_MouseHover(object sender, EventArgs e)
        {
            this.lblPath.BackColor = Color.LightGray;
            Cursor = Cursors.Hand;
            toolTip1.SetToolTip(lblPath, "Click here to set Download Folder default");
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.lblPath.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            Cursor = Cursors.Default;
        }
        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtPath, "Click here to select your Download Folder");
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.btnMinimize.BackColor = Color.LightGray;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.btnMinimize.BackColor = Color.White;
        }
        private void btnPauseAll_MouseHover(object sender, EventArgs e)
        {
            btnPauseAll.BackColor = Color.LightGray;
            Cursor = Cursors.Hand;
        }
        private void btnPauseAll_MouseLeave(object sender, EventArgs e)
        {
            btnPauseAll.BackColor = Color.Transparent;
            Cursor = Cursors.Default;
        }
        private void btnResumeAll_MouseHover(object sender, EventArgs e)
        {
            btnResumeAll.BackColor = Color.LightGray;
            Cursor = Cursors.Hand;
        }

        private void btnResumeAll_MouseLeave(object sender, EventArgs e)
        {
            btnResumeAll.BackColor = Color.Transparent;
            Cursor = Cursors.Default;
        }

        private void btnCancelAll_MouseHover(object sender, EventArgs e)
        {
            btnCancelAll.BackColor = Color.LightGray;
            Cursor = Cursors.Hand;
        }

        private void btnCancelAll_MouseLeave(object sender, EventArgs e)
        {
            btnCancelAll.BackColor = Color.Transparent;
            Cursor = Cursors.Default;
        }

        #endregion

        #region Những phần không sử dụng
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IFactory.form = this;
            IFactory.view = tblDownload;
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        #endregion
    }

    public partial class OperationStrategy : Form{ }


}