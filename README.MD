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
        <div style="text-align: right">
            <p style="line-height: 1.0">
                <i>Giảng viên:</i><b> Thầy Đặng Huỳnh Trung Tín</b>
            </p>
            <p style="line-height:1.0">
                <i>Người thực hiện:</i>
                    <b>Đoàn Nguyễn Văn Hậu - 51800747</b>
            </p>
            <p style="line-height:1.0">
                    <b>Nguyễn Trường Khương Duy - 51800371 </b>
            </p>
        </div>
</p>
<br>

<!-- MỤC LỤC -->
# Mục lục
  - [A. Giới thiệu](#a-giới-thiệu)
  - [B. Yêu cầu:](#b-yêu-cầu)
        - [Hướng dẫn cài đặt VideoLibrary (Nuget Package) (*)](#hướng-dẫn-cài-đặt-videolibrary-nuget-package-)
  - [C. Cách thực thi ứng dụng:](#c-cách-thực-thi-ứng-dụng)
        - [Trực tiếp: (Sau khi tải về)](#trực-tiếp-sau-khi-tải-về)
        - [Gián tiếp: (GitHub)](#gián-tiếp-github)
  - [D. Kiến thức cơ bản:](#d-kiến-thức-cơ-bản)
      - [Builder Pattern:](#builder-pattern)
        - [Giới thiệu:](#giới-thiệu)
        - [Lý do áp dụng:](#lý-do-áp-dụng)
        - [Thông tin ứng dụng Pattern:](#thông-tin-ứng-dụng-pattern)
          - [Folder Structure Builder pattern:](#folder-structure-builder-pattern)
        - [Kết quả triển khai:](#kết-quả-triển-khai)
      - [Pattern 2:](#pattern-2)
        - [Giới thiệu:](#giới-thiệu-1)
        - [Lý do áp dụng:](#lý-do-áp-dụng-1)
        - [Thông tin ứng dụng Pattern:](#thông-tin-ứng-dụng-pattern-1)
        - [Kết quả triển khai:](#kết-quả-triển-khai-1)
    - [Thông tin người phát triển:](#thông-tin-người-phát-triển)
<br>


<!--GIỚI THIỆU PROJECT-->
# A. Giới thiệu

![app](https://i.imgur.com/VH7hNxi.png)
**Chức năng:**

* Ứng dụng FastDownloadManager dùng để download các file từ link nhập vào.
* Có thể download nhiều file cùng một lúc.
* Ứng dụng đa luồng vào việc chia nhỏ các file thành từng phần (Task) để download trong thread.


<!-- YÊU CẦU PROJECT-->
# B. Yêu cầu: 

![vsstudio](/assets/vsstudio.png)

Sử dụng Visual Studio để chạy ứng dụng.
Sau khi download project, khởi chạy bình thường. Nếu gặp lỗi về thư viện VideoLibrary thì thực hiện theo hướng dẫn bên dưới **(*)**.
<!--HƯỚNG DẪN CÀI ĐẶT THƯ VIỆN-->
#### Hướng dẫn cài đặt VideoLibrary (Nuget Package) (*)

Cài đặt **VideoLibrary** trong NuGet Package (Nếu NuGet Package project ko tương thích với Visual Studio hiện hành):

* Sau khi mở project lên. Click chuột phải vào project trên thanh **Solution Explorer**.
* Sau đó, chọn **"Manage NuGet Packages..."**.
    - Tại giao diện đó, kiểm tra tại **"Installed"**. Nếu thư viện **VideoLibrary** đã được cài đặt thì gỡ rồi cài đặt lại.
    - Nếu chưa cài đặt thì chọn vào **"Browse"**. Nhập **VideoLibrary** vào thanh tìm kiếm. Chọn thư viện cùng tên rồi **"Install"**.



<!-- HƯỚNG DẪN KHỞI CHẠY PROJECT-->
# C. Cách thực thi ứng dụng:

<!-- KHỞI CHẠY TRỰC TIẾP PROJECT-->
#### Trực tiếp: (Sau khi tải về)

  - Truy cập đường Link **https://github.com/TDTU-IT-DP/FastDownloadManager**
  - Sau đó, chọn nút **Code** -> **Download ZIP**.
  - Kế tiếp, chúng ta click chuột phải extract file **"FastDownloadManager-main.zip"**
  - Tìm trong các file vừa extract có tên file là:  **"FastDownloadManager.sln"**. Click chuột trái 2 lần vào file.
  - Nội dung project sẽ xuất hiện. Ta chọn vào nút **"FastDownloadManager"**
  ![hd-mo-tu-github-3](/assets/hd-mo-tu-github-3.png)
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
# D. Kiến thức cơ bản:
### Builder Pattern:

#### Giới thiệu:
>''Builder is a creational design pattern that separate the construction of a complex object from its representation so that the same construction process can create different representations.

Builder pattern thuộc trong một những Creational pattern. Là mẫu thiết kế được tạo ra để xây dựng cho đối tượng phức tạp với nhiều tham số, phương thức. Bằng cách sử dụng đối tượng đơn giản, tiếp cận từng bước vào đối tượng phức tạp thông qua việc xây dựng đối tượng độc lập để cụ thể hóa đối tượng phức tạp.

#### Lý do áp dụng: 
- Có quá nhiều tham số được truyền vào constructor của Object.
- Việc khởi tạo đối tượng với nhiều tham số khiến cả người lập trình trực tiếp cũng tốn nhiều thời gian và khó cho cả người kế thừa hệ thống.
- Giúp mọi người dễ dàng hiểu cách các parameters được truyền vào một constructor.

#### Thông tin ứng dụng Pattern:
Object **FileDownloader** là đối tượng khởi tạo trong **Builder pattern**. Tại đây, thay vì khởi tạo trực tiếp thì ta gọi thông qua Interface **IFileBuilder**. Tạo một lớp kế thừa  **IFileBuilder**, tại đây có tất cả các phương thức dùng để tạo ra parameters của  **FileDownloader**.

##### Folder Structure Builder pattern:
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
#### Kết quả triển khai:
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

###  Pattern 2:

#### Giới thiệu:
#### Lý do áp dụng: 
#### Thông tin ứng dụng Pattern:
#### Kết quả triển khai:

# Thông tin người phát triển:
LÊ THÀNH ĐẠT - 51802095
NGUYỄN NGỌC KHA - 51802083
