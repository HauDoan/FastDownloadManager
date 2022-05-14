using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDownloadManager
{
    public class FileDownloader 
    {

        //Class FileDownloader
        //Một file lớn được chia ra làm nhiều file nhỏ để download
        //Thông tin của các file nhỏ (part nhỏ)
        //Start: Vị trí bắt đầu tải của từng file part nhỏ
        //Count: Tổng length của file part nhỏ
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
        public FileDownloader(string url, int start, int length, string p,
            string n, int i, int loc)
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
}
