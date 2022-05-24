<!--THÔNG TIN PROJECT-->
<br>
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="assets/logo.png" alt="Logo" width="80" height="80">
  </a>
  <h1 align="center">TIỂU LUẬN</h1>
   <h3>Áp dụng Design Pattern vào ứng dụng</h3>
<br>

</div>
    <br>
    <br>
    <br>
    <br>
<p>
        <div >
            <p style="line-height: 1.0" dir ="rtl">
                <i>Giảng viên:</i><b> Thầy Đặng Huỳnh Trung Tín</b>
            </p>
            <p style="line-height: 1.0"dir ="rtl">
                <i>Người thực hiện:</i>
                    <b>Đoàn Nguyễn Văn Hậu - 51800747</b>
            </p>
            <p style="line-height: 1.0" dir ="rtl">
                    <b>Nguyễn Trường Khương Duy - 51800371 </b>
            </p>
        </div>
</p>
<br>

<!-- MỤC LỤC -->
# Mục lục

  1. [Giới thiệu](#1-giới-thiệu)<br>
   
  2. [Yêu cầu:](#2-yêu-cầu) <br>
    2.1 [Hướng dẫn cài đặt VideoLibrary (Nuget Package) (*)](#hướng-dẫn-cài-đặt-videolibrary-nuget-package-)<br>
    
  3. [Cách thực thi ứng dụng:](#3-cách-thực-thi-ứng-dụng)<br>
    3.1 [Trực tiếp: (Sau khi tải về)](#trực-tiếp-sau-khi-tải-về)<br>
    3.2 [Gián tiếp: (GitHub)](#gián-tiếp-github)<br>
  4. [Kiến thức cơ bản:](#4-kiến-thức-cơ-bản)<br>
      4.1 [Builder Pattern](#builder-pattern)
        - [Giới thiệu](#giới-thiệu-builder-pattern)
        - [Lý do áp dụng](#lý-do-áp-dụng-builder-pattern)
        - [Thông tin ứng dụng Pattern](#thông-tin-ứng-dụng-builder-pattern)
        - [Folder Structure Builder pattern:](#folder-structure-builder-pattern)
        - [Kết quả triển khai](#kết-quả-triển-khai-builder-pattern)

      4.2 [Factory Method](#factory-method)
        - [Giới thiệu](#giới-thiệu-factory-method)
        - [Lý do áp dụng](#lý-do-áp-dụng-factory-method)
        - [Thông tin ứng dụng](#thông-tin-ứng-dụng-factory-method)
        - [Kết quả triển khai](#kết-quả-triển-khai-factory-method)

  5. [Thông tin người phát triển:](#5-thông-tin-người-phát-triển)

<!--GIỚI THIỆU PROJECT-->
# 1. Giới thiệu

![app](https://i.imgur.com/VH7hNxi.png)
**Chức năng:**

* Ứng dụng FastDownloadManager dùng để download các file từ link nhập vào.
* Có thể download nhiều file cùng một lúc.
* Ứng dụng đa luồng vào việc chia nhỏ các file thành từng phần (Task) để download trong thread.


<!-- YÊU CẦU PROJECT-->
# 2. Yêu cầu

![vsstudio](/assets/vsstudio.png)

Sử dụng Visual Studio để chạy ứng dụng.
Sau khi download project, khởi chạy bình thường. Nếu gặp lỗi về thư viện VideoLibrary thì thực hiện theo hướng dẫn bên dưới **(*)**.
<!--HƯỚNG DẪN CÀI ĐẶT THƯ VIỆN-->

#### Hướng dẫn cài đặt VideoLibrary (Nuget Package) (*)

Cài đặt **VideoLibrary** trong NuGet Package (Nếu NuGet Package project ko tương thích với Visual Studio hiện hành):

- Sau khi mở project lên. Click chuột phải vào project trên thanh **Solution Explorer**.
- Sau đó, chọn **"Manage NuGet Packages..."**.

  - Tại giao diện đó, kiểm tra tại **"Installed"**. Nếu thư viện **VideoLibrary** đã được cài đặt thì gỡ rồi cài đặt lại.
  - Nếu chưa cài đặt thì chọn vào **"Browse"**. Nhập **VideoLibrary** vào thanh tìm kiếm. Chọn thư viện cùng tên rồi **"Install"**.



<!-- HƯỚNG DẪN KHỞI CHẠY PROJECT-->
# 3. Cách thực thi ứng dụng:

<!-- KHỞI CHẠY TRỰC TIẾP PROJECT-->
### Trực tiếp: (Sau khi tải về)

  - Truy cập đường Link **https://github.com/TDTU-IT-DP/FastDownloadManager**
  - Sau đó, chọn nút **Code** -> **Download ZIP**.
  - Kế tiếp, chúng ta click chuột phải extract file **"FastDownloadManager-main.zip"**
  - Mở thư mục vừa extract ra rồi làm theo hướng dẫn bên dưới.
  - Sau đó, follow theo đường dẫn sau để mở ứng dụng:
    - Chọn folder ``FastDownloadManager`` -> ``bin`` -> ``Debug`` -> ``net5.0-windows``. 
    - Cuối cùng chọn mở file: ``FastDownloadManager.exe`` 
  - Giao diện hệ thống sẽ xuất hiện.
  ![hd-mo-tu-github-4](/assets/hd-mo-tu-github-4.png)

<!-- KHỞI CHẠY GIÁN TIẾP PROJECT-->
#### Gián tiếp: (GitHub)

  - Truy cập đường Link **https://github.com/TDTU-IT-DP/FastDownloadManager**
  - Sau đó, chọn nút **Code** -> **Open with Visual Studio**.
  - Thông báo sẽ xuất hiện, chúng ta chọn **"Mở Microsoft Visual Studio Web Protocol Handler Selector"**.
  - Rồi giao diện của Microsoft Visual Studio sẽ xuất hiện như hình dưới.

  ![hd-mo-tu-github-1](/assets/hd-mo-tu-github-1.png)
  - Chờ đến khi project chạy hoàn toàn xuất hiện giao diện như hình.
  ![hd-mo-tu-github-1](/assets/hd-mo-tu-github-1_ghrjzxho7.png)
  - Nội dung project sẽ xuất hiện. Ta chọn vào nút **"FastDownloadManager"**
  ![hd-mo-tu-github-3](/assets/hd-mo-tu-github-3.png)
  - Giao diện hệ thống sẽ xuất hiện.
  ![hd-mo-tu-github-4](/assets/hd-mo-tu-github-4.png)
  

<!-- GIỚI THIỆU, LÝ DO ÁP DỤNG PATTERN VÀO PROJECT-->
# 4. Kiến thức cơ bản

### Builder Pattern

#### Giới thiệu Builder Pattern

>''Builder is a creational design pattern that separate the construction of a complex object from its representation so that the same construction process can create different representations.

Builder pattern thuộc trong một những Creational pattern. Là mẫu thiết kế được tạo ra để xây dựng cho đối tượng phức tạp với nhiều tham số, phương thức. Bằng cách sử dụng đối tượng đơn giản, tiếp cận từng bước vào đối tượng phức tạp thông qua việc xây dựng đối tượng độc lập để cụ thể hóa đối tượng phức tạp.

#### Lý do áp dụng Builder Pattern

- Có quá nhiều tham số được truyền vào constructor của Object.
- Việc khởi tạo đối tượng với nhiều tham số khiến cả người lập trình trực tiếp cũng tốn nhiều thời gian và khó cho cả người kế thừa hệ thống.
- Giúp mọi người dễ dàng hiểu cách các parameters được truyền vào một constructor.

#### Thông tin ứng dụng Builder Pattern

Object **FileDownloader** là đối tượng khởi tạo trong **Builder pattern**. Tại đây, thay vì khởi tạo trực tiếp thì ta gọi thông qua Interface **IFileBuilder**. Tạo một lớp kế thừa  **IFileBuilder**, tại đây có tất cả các phương thức dùng để tạo ra parameters của  **FileDownloader**.

##### Folder Structure Builder pattern

- `FileDownloader`: đối tượng được Builder khởi tạo.
- `IFileBuilder`: (interface) chứa các phương thức khởi tạo parameters của `FileDownloader`.
- `FileDownloader`: lớp kế thừa `IFileBuilder` khởi tạo parameters trong các hàm override và gán giá trị vào đối tượng `FileDownloader`.

```cs
 public class FileDownloader 
    {
      //Class FileDownloader
        //Một file lớn được chia ra làm nhiều file nhỏ để download
        //Thông tin của các file nhỏ (part nhỏ)
        //Start: Vị trí bắt đầu tải của từng file part nhỏ
        //Length: Size của file part nhỏ
        //Url: đường link download của file
        //Path: đường dẫn thư mục download
        //Name: Tên file download
        //Ind: index của file download trong bảng Download
        //partT: thứ tự của các file part nhỏ
        public int Start { get ; set ; }
        public int Length { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public int Ind { get; set; }
        public int PartT { get; set; }
        public FileDownloader(string url, int start, int length, string p, string n, int i, int loc)
        {
            Url = url;
            Start = start;
            Length = length;
            Path = p;
            Name = n;
            Ind = i;
            PartT = loc;
        }
    }
```

#### Kết quả triển khai Builder Pattern

**Trước khi áp dụng Pattern:**

```cs
        //Khởi tạo đối tượng FileDownloader chứa thông tin
        List<FileDownloader> filewonloadersList = new List<FileDownloader>();

        //Thêm thông tin các parts vào filewonloadersList
        //Thêm 3 part đầu
        for (int i = 0; i < parts - 1; i++)
        {
        filewonloadersList.Add(new FileDownloader(url, i * eachSize, eachSize,
                       txtPath.Text, fileName, ind, i + 1));
        }
        //Có quá nhiều parameters được thêm vào mỗi khi khởi tạo Object
        //Khó cho việc đọc code, không biết giá trị thêm vào mang ý nghĩa gì.
```

**Sau khi áp dụng Pattern:**

```cs
        List<FileDownloader> filewonloadersList = new List<FileDownloader>();


        for (int i = 0; i < parts - 1; i++)
        {
        filewonloadersList.Add(new FileBuilder()
                                          .AddUrl(url)
                                          .AddStart(i * eachSize)
                                          .AddLength(eachSize)
                                          .AddPath(txtPath.Text)
                                          .AddName(fileName)
                                          .AddIndex(ind)
                                          .AddLoc(i + 1)
                                          .Build());
        }
        //Dễ dàng thêm vào các giá trị mà không phụ thuộc vào vị trí
        //Biết giá trị thêm vào là gì.
```
<!-- CLASS DIAGRAM BUILDER PATTERN-->
![BuilderDiagram](/assets/BuilderDiagram.png)

### Factory Method

#### Giới thiệu Factory Method

>''Factory Method is a creational design pattern that Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

Factory Method Design Pattern hay gọi ngắn gọn là Factory Pattern là một trong những Pattern thuộc nhóm Creational Design Pattern. Nhiệm vụ của Factory Pattern là quản lý và trả về các đối tượng theo yêu cầu, giúp cho việc khởi tạo đổi tượng một cách linh hoạt hơn.

#### Lý do áp dụng Factory Method

- Trong phương thức Download có 2 trường hợp là download file HTML và các file thường (video, git,..)
- 2 cách download khác biệt nhau nhưng đều chung đầu vào
- Dễ dàng mở rộng phương thức download khác trong tương lai

#### Thông tin ứng dụng Factory Method

- `Extension`: (Super Class) chứa các phương thức khởi tạo parameters.
- `Download_File , Download_Web`: (Sub Class) implement các phương thức của **super class** theo chức năng của nó.
- `ExtensionType`: Chứa các loại file hỗ trợ download.
- `IFactory`: Class chịu trách nhiệm khởi tạo các **sub Class** dựa trên tham số đầu vào

```cs
public interface Extension{
  public void run();
}

class Download_Web : Extension
{
  String url;
  int ind;
  String path;
  String fileName;
  Uri uri;
  DataGridView view = IFactory.view;
  Form1 form = IFactory.form;
      
  public Download_Web(Uri uri, String url, int ind, String path, String fileName)
  {
      this.uri = uri;
      this.url = url;
      this.ind = ind;
      this.path = path;
      this.fileName = fileName;
  }

  public void run() {
    WebClient client = new WebClient();
    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler((sender, e) => form.Client_DownloadProgressChanged(sender, e, url, ind));
    //download file async
    client.DownloadFileAsync(uri, path + "/" + fileName);
    
    //Chờ đến khi tải xong
    while (view.Rows[ind].Cells[8].Value.ToString() != "100%")
    {
        Thread.Sleep(100);
    }
    
    if (view.Rows[ind].Cells[8].Value.ToString() == "100%")
    {
      view.Rows[ind].Cells[3].Value = "Completed";
      view.Rows[ind].Cells[8].Value = "Done";
      view.Rows[ind].Cells[9].Value = "Done";
      view.Rows[ind].Cells[10].Value = "Done";
      view.Rows[ind].Cells[11].Value = "Done";
      view.Rows[ind].Cells[5].Value = "0 Mbps";
      view.Rows[ind].Cells[6].Value = "0 s";
      MessageBox.Show(view.Rows[ind].Cells[2].Value.ToString() + " Completed");
    }
  }
}

class Download_File : Extension
{
  WebClient client = new WebClient();
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
              double estimatedTime = (float)bytesRead / (elapsedTime.TotalSeconds * 1048576);

              //Hiển thị tốc độ download
              view.Rows[ind].Cells[5].Value = $"{string.Format("{0:0.#}", estimatedTime)}" + " Mbps";

              /*
                
                Tính thời gian còn lại
                = 4*(Tổng byte - Số byte đã đọc)/(tốc độ tải hiện tại x 1048576)

                */
              double remainTime = Math.Round((downloader.Length - sum) / (estimatedTime * 1048576), 0);

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

public class IFactory
{
  private IFactory(){}

  public static Form1 form;
  public static DataGridView view;

  public static Extension getExtension(ExtensionType type , Uri uri, String url, int ind, String path, String fileName) {
    switch (type)
    {
        case ExtensionType.HTML:
            return new Download_Web(uri, url, ind, path, fileName);
        case ExtensionType.FILE:
            return new Download_File(uri, url, ind, path, fileName);
        default:
            MessageBox.Show("something wrong");
            return null;
    }
  }
}

public enum ExtensionType
{
  FILE, HTML
}
  
```
#### Kết quả triển khai Factory Method:
**Trước khi áp dụng**
```cs
 //TH1: Nếu là file html sẽ download bằng WebClient
if (ext == "" && !url.Contains("youtube.com"))
{
    //download bằng WebClient
    //Hiển thị progress change
    client.DownloadProgressChanged += new
        DownloadProgressChangedEventHandler((sender, e) =>
        Client_DownloadProgressChanged(sender, e, url, ind));
    //download file async
    client.DownloadFileAsync(uri, txtPath.Text + "/" + fileName);

    //Chờ đến khi tải xong
    while (tblDownload.Rows[ind].Cells[8].Value.ToString() != "100%")
    {
        Thread.Sleep(100);
    }

    //Cập nhật trạng thái khi tải xong
    if (tblDownload.Rows[ind].Cells[8].Value.ToString() == "100%")
    {
        tblDownload.Rows[ind].Cells[3].Value = "Completed";
        tblDownload.Rows[ind].Cells[8].Value = "Done";
        tblDownload.Rows[ind].Cells[9].Value = "Done";
        tblDownload.Rows[ind].Cells[10].Value = "Done";
        tblDownload.Rows[ind].Cells[11].Value = "Done";
        tblDownload.Rows[ind].Cells[5].Value = "0 Mbps";
        tblDownload.Rows[ind].Cells[6].Value = "0 s";
        MessageBox.Show(tblDownload.Rows[ind].Cells[2].Value.ToString() + " Completed");

    }
}

//TH2: Ngược lại --> Chia nhỏ file để download
else
{

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
                              .AddPath(txtPath.Text)
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
                        .AddPath(txtPath.Text)
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
  if (ListStatus[filewonloadersList[0].Name] == 2)
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
      tblDownload.Rows[ind].Cells[3].Value = "Completed";
      tblDownload.Rows[ind].Cells[8].Value = "Done";
      tblDownload.Rows[ind].Cells[9].Value = "Done";
      tblDownload.Rows[ind].Cells[10].Value = "Done";
      tblDownload.Rows[ind].Cells[11].Value = "Done";
      tblDownload.Rows[ind].Cells[5].Value = "0 Mbps";
      tblDownload.Rows[ind].Cells[6].Value = "0 s";
      //Hiển thị thông báo tải thành công
      MessageBox.Show(filewonloadersList[0].Name + ": Completed");

  }
}
```
**Sau khi áp dụng**
```cs
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
```

<!-- CLASS DIAGRAM FACTORY METHOD-->
![FactoryDiagram](/assets/FactoryDiagram.png)

# 5. Thông tin người phát triển:

- LÊ THÀNH ĐẠT (bạn học).
- NGUYỄN NGỌC KHA (bạn học).
