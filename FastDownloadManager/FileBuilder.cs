using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDownloadManager
{
     class FileBuilder : IFileBuilder
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public int Ind { get; set; }
        public int PartT { get; set; }

        public FileBuilder AddIndex(int index)
        {
            Ind = index;
            return this;
        }

        public FileBuilder AddLength(int length)
        {
            Length = length;
            return this;
        }

        public FileBuilder AddLoc(int loc)
        {
            PartT = loc;
            return this;
        }

        public FileBuilder AddName(string name)
        {
            Name = name;
            return this;

        }

        public FileBuilder AddPath(string path)
        {
            Path = path;
            return this;
        }

        public FileBuilder AddStart(int start)
        {
            Start = start;
            return this;
        }

        public FileBuilder AddUrl(string url)
        {
            Url = url;
            return this;
        }

        public FileDownloader Build()
        {
            return new FileDownloader(Url, Start, Length, Path, Name, Ind, PartT);
        }
    }
}
