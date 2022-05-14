using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDownloadManager
{
    public class UrlInd
    {
        //Class UrlInd
        //Url: đường link của file download
        //Ind: index của file download trong bảng Download
        public string url;
        public int ind;
        public UrlInd(string u, int i)
        {
            url = u;
            ind = i;
        }
        
    }
}
