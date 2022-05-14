using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDownloadManager
{
    interface IFileBuilder
    {
        FileBuilder AddUrl(String url);
        FileBuilder AddStart(int start);
        FileBuilder AddLength(int length);
        FileBuilder AddPath(String  path);
        FileBuilder AddName(String name);
        FileBuilder AddIndex(int index);
        FileBuilder AddLoc(int loc);

        FileDownloader Build();

    }
}
