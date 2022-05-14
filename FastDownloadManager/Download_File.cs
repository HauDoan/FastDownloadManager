using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastDownloadManager
{
    class Download_File : Extension
    {
        
        String url;
        int ind;
        String path;
        String fileName;
        Uri uri;
        
        DataGridView view = IFactory.view;
        Form1 form = IFactory.form;


        public Download_File(Uri uri, String url, int ind, String path, String fileName)
        {
            this.url = url;
            this.ind = ind;
            this.path = path;
            this.fileName = fileName;
            this.uri = uri;
        }

        public async void run()
        {
            WebClient client = new WebClient();

            //Trường hợp là link youtube
            if (url.Contains("googlevideo.com"))
            {
                //read url
                client.OpenRead(url);

                //Phòng khi read uri không được
                for (int i = 0; i < 6; i++)
                {
                    //open read lại
                    client.OpenRead(url);
                }
            }
            //Trường hợp ngược lại
            else
            {
                //read uri
                client.OpenRead(uri);

                //Phòng khi read uri không được
                for (int i = 0; i < 6; i++)
                {
                    //open read lại
                    client.OpenRead(uri);
                }
            }

            //Lấy Content Length
            int totalLength = Convert.ToInt32(client.ResponseHeaders["Content-Length"]);

            //Tạo 4 part nhỏ (Cài đặt của nhóm)
            var parts = 4;

            //Length của 3 part nhỏ đầu
            int eachSize = totalLength / parts;

            //Length của part nhỏ thứ 4
            int lastPartSize = eachSize + (totalLength % parts);


            //Khởi tạo đối tượng FileDownloader chứa thông tin
            List<FileDownloader> filewonloadersList = new List<FileDownloader>();

            //Thêm thông tin các parts vào filewonloadersList
            //Thêm 3 part đầu
            for (int i = 0; i < parts - 1; i++)
            {
                filewonloadersList.Add(new FileBuilder()
                                        .AddUrl(url)
                                        .AddStart(i * eachSize)
                                        .AddLength(eachSize)
                                        .AddPath(path)
                                        .AddName(fileName)
                                        .AddIndex(ind)
                                        .AddLoc(i + 1)
                                        .Build());
                //filewonloadersList.Add(new FileDownloader(url, i * eachSize, eachSize,
                //    txtPath.Text, fileName, ind, i + 1));
            }


            //Thêm part 4
            filewonloadersList.Add(new FileBuilder()
                              .AddUrl(url)
                              .AddStart((parts - 1) * eachSize)
                              .AddLength(lastPartSize)
                              .AddPath(path)
                              .AddName(fileName)
                              .AddIndex(ind)
                              .AddLoc(4)
                              .Build());

            //filewonloadersList.Add(new FileDownloader(url, (parts - 1) * eachSize,
            //    lastPartSize, txtPath.Text, fileName, ind, 4));

            /*
                Xóa file tạm bị trùng: Trường hợp người dùng vô tình tắt ứng dụng
                nhưng file tạm vẫn còn thì --> Xóa file tạm trước
            */
            try
            {
                //Xóa file tạm
                Del(filewonloadersList);
            }
            catch (Exception)
            {
                //do nothing
                MessageBox.Show("Please try again.");
            }

            //Tạo 4 tasks để tải 4 part nhỏ
            Task t1 = DownloadPart(filewonloadersList[0]);
            Task t2 = DownloadPart(filewonloadersList[1]);
            Task t3 = DownloadPart(filewonloadersList[2]);
            Task t4 = DownloadPart(filewonloadersList[3]);

            //Đợi 4 part nhỏ được tải xong
            await Task.WhenAll(t1, t2, t3, t4);

            /*
                Kiểm tra file có bị Cancel hay chưa
                ListStatus[filewonloadersList[0].name] == 2 --> Cancel
            */
            if (form.ListStatus[filewonloadersList[0].Name] == 2)
            {
                //Xóa file tạm
                Del(filewonloadersList);
            }
            //Quá trình tải xuống không bị Cancel
            //--> Tải file thành công
            //--> Gộp file và xóa File Tạm
            else
            {
                //Lấy tên file đã download
                string fn = filewonloadersList[0].Path + "\\" + filewonloadersList[0].Name;

                //Gộp lại thành file lớn
                Copy(fn, filewonloadersList);

                //Xóa file tạm
                Del(filewonloadersList);

                //Hiển thị trạng thái file đã hoàn thành download trong bảng Download
                view.Rows[ind].Cells[3].Value = "Completed";
                view.Rows[ind].Cells[8].Value = "Done";
                view.Rows[ind].Cells[9].Value = "Done";
                view.Rows[ind].Cells[10].Value = "Done";
                view.Rows[ind].Cells[11].Value = "Done";
                view.Rows[ind].Cells[5].Value = "0 Mbps";
                view.Rows[ind].Cells[6].Value = "0 s";
                //Hiển thị thông báo tải thành công
                MessageBox.Show(filewonloadersList[0].Name + ": Completed");
            }
        }


        //Hàm tải về từng part nhỏ của file lớn
        /*
            Từ thông tin part nhỏ (FileDownloader)
            --> Sử dụng HttpWebRequest để thực hiện download
            --> Tạo file tạm (đường dẫn + temp$ + vị trí bắt đầu của part nhỏ + tên file)
            --> Dùng vòng lặp để readAsync; writeAsync file tạm
            --> Hiển thị % tải xuống của part
         */        
        public async Task DownloadPart(FileDownloader downloader)
        {
            try
            {
                //Lấy index trong table của file download
                var ind = downloader.Ind;

                //Create request, get response url
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(downloader.Url);
                //Add range cho phần request của các part nhỏ
                req.AddRange(downloader.Start, downloader.Start + downloader.Length - 1);
                var response = await req.GetResponseAsync();

                //Bắt đầu tải
                using (var reponseStream = response.GetResponseStream())
                {
                    /*Tạo file tạm (part nhỏ của file lớn), có thêm temp$ trong tên để đánh
                    dấu file tạm*/
                    string fileName = downloader.Path + "/" + "temp$" + downloader.Start
                        + downloader.Name;
                    using (var fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
                    {
                        //Buffer
                        var buffer = new byte[1024];

                        //Byte read
                        int bytesRead = 0;

                        //Sum byte read
                        int sum = 0;

                        //Tạo biến count và sử dụng vòng lặp
                        //để tăng thời gian cập nhật giữa các lần --> dễ đọc
                        int count = 0;

                        do
                        {
                            //Chức năng Pause, Cancel, PauseAll, CancelAll
                            //***Stop: Pause, PauseAll
                            //Khi nhấn vào nút Pause hoặc PauseAll thì cho task sleep
                            //ListStatus[downloader.name] == 1 --> Sleep task có fileName:downloader.name
                            while (form.ListStatus[downloader.Name] == 1)
                            {
                                Thread.Sleep(100);

                                //Trường hợp đang Pause thì nhấn Cancel --> break
                                if (form.ListStatus[downloader.Name] == 2)
                                {
                                    break;
                                }
                            }

                            //***Khi nhấn vào Cancel hoặc CancelAll thì break task
                            //ListStatus[downloader.name] == 2 --> break task có filename:downloader.name
                            if (form.ListStatus[downloader.Name] == 2)
                            {
                                break;
                            }

                            //Tăng count
                            count++;

                            //Khởi tạo thời gian ban đầu
                            DateTime startTime = DateTime.Now;

                            //**Tính speed download, time remaining, total time
                            //count % 3000 = 0: kéo dài thời gian update hiển thị
                            //giữa các lần --> dễ đọc
                            if ((count % 2000 == 0 || count == 5))
                            {
                                //Bắt đầu do thời gian
                                startTime = DateTime.Now;
                            }

                            //Đọc file từ trang web
                            bytesRead = await reponseStream.ReadAsync(buffer, 0, 1024);

                            //Viết ra file tạm
                            await fs.WriteAsync(buffer, 0, bytesRead);
                            await fs.FlushAsync();

                            //Tính tổng byte đã read
                            sum += bytesRead;

                            //Trường hợp link là github
                            if (view.Rows[ind].Cells[1].Value.ToString().Contains("https://github.com"))
                            {
                                //Hiển thị % download ra table Download
                                view.Rows[ind].Cells[downloader.PartT + 7].Value
                                = $"{string.Format("{0:0.#}", (float)sum * 25.0 / (float)downloader.Length)}%";
                            }
                            //Trường hợp file thường
                            else
                            {
                                //Hiển thị % download ra table Download
                                view.Rows[ind].Cells[downloader.PartT + 7].Value
                                    = $"{string.Format("{0:0.#}", (float)sum * 100.0 / (float)downloader.Length)}%";
                            }

                            //**Tính speed download, time remaining, total time
                            //Sử dụng cả 4 part nhỏ để update speed, ...
                            //Vì nếu 1 part được tải xong thì 3 part kia vẫn còn update
                            if ((count % 2000 == 0 || count == 5))
                            {
                                //Tổng thời gian của lần đo
                                TimeSpan elapsedTime = DateTime.Now - startTime;

                                //Đổi byte thành MB: 1048576 = 1024 x 1024
                                /*
                                 
                                Tính tốc độ download: Mbps
                                = tổng byte đọc trong khoảng thời gian / (thời gian x 1048576)
                                
                                */
                                //MessageBox.Show(elapsedTime.TotalSeconds.ToString());
                                double estimatedTime = (float)bytesRead
                                    / (elapsedTime.TotalSeconds * 1048576);

                                //Hiển thị tốc độ download
                                view.Rows[ind].Cells[5].Value =
                                    $"{string.Format("{0:0.#}", estimatedTime)}" + " Mbps";

                                /*
                                 
                                 Tính thời gian còn lại
                                 = 4*(Tổng byte - Số byte đã đọc)/(tốc độ tải hiện tại x 1048576)

                                 */
                                double remainTime = Math.Round((downloader.Length
                                     - sum) / (estimatedTime * 1048576), 0);

                                //Hiển thị thời gian tải còn lại
                                view.Rows[ind].Cells[6].Value = 4 * remainTime + " s";

                                //Nếu thời gian > 60 s ----> Đổi sang minute
                                if (remainTime * 4 > 60)
                                {
                                    view.Rows[ind].Cells[6].Value = Math.Round((remainTime / 15), 0) + " m";
                                }
                            }
                        } while (bytesRead > 0);
                        fs.Close();
                    }
                }
            }
            /*
                Trường hợp chương trình dừng đột ngột mà các file tạm của lần download trước
                chưa được xóa --> Xuất lỗi
            */
            catch (Exception)
            {
                //Thông báo 
                MessageBox.Show("Please try again");
            }
        }
        //File được chia thành những part nhỏ để tải về
        //Hàm này sử dụng để gộp những part nhỏ thành file lớn
        /*
            Tham số truyền vào gồm tên file hoàn chỉnh, và danh sách thông tin của các part nhỏ
            Từ thông tin các part nhỏ
            --> lấy đường dẫn và tên của file tạm
            --> Thực hiện copy file tạm và ghi vào file hoàn chỉnh
         */
        public void Copy(string fn, List<FileDownloader> l)
        {
            try
            {
                //Tạo file hoàn chỉnh
                //Filemode create: Nếu đã tải xuống 1 lần và nhấn Play lần nữa
                //thì sẽ ghi đè lên file cũ
                using var fs2 = new FileStream(fn, FileMode.Create, FileAccess.Write);
                foreach (var item in l)
                {
                    //Lấy tên file tạm
                    string file = item.Path + "\\" + "temp$" + item.Start + item.Name;

                    //Đọc file tạm
                    using var fs = new FileStream(file, FileMode.Open, FileAccess.Read);

                    //Ghi vào file hoàn chỉnh
                    fs.CopyTo(fs2);
                }
            }
            //Trường hợp file tạm vô tình bị xóa
            catch (Exception)
            {
                MessageBox.Show("The temp files had been deleted. Please try again.");
            }
        }

        //Hàm xóa các part tạm khi gộp các part nhỏ xong
        /*
            Tham số truyền vào là danh sách thông tin của các part nhỏ
            Từ thông tin các part nhỏ
            --> Lấy đường dẫn và tên file tạm
            --> Thực hiện xóa file tạm
         */
        public void Del(List<FileDownloader> l)
        {
            try
            {
                foreach (var item in l)
                {
                    //Lấy tên file tạm
                    string file = item.Path + "\\" + "temp$" + item.Start + item.Name;

                    //Xóa file tạm
                    File.Delete(file);
                }
            }
            //Trường hợp file tạm vô tình bị xóa
            catch (Exception)
            {
                MessageBox.Show("The temp files doesn't exists.");
            }
        }

        //Hàm kiểm tra tất cả file tải về trong table Download đã hoàn thành hay chưa
        /*
            Xét trong table Download nếu có bất kì file nào có trạng thái Downloading thì
            trả về False, nếu không có file nào có trạng thái Downloading thì trả về True
         */
    }
}
