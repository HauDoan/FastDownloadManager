using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastDownloadManager
{
    public class IFactory
    {
        private IFactory(){}

        public static Form1 form;
        public static DataGridView view;

        public static Extension getExtension(ExtensionType type , Uri uri, String url, int ind, String path, String fileName) {
            switch (type)
            {
                case ExtensionType.HTML:
                    return new Download_Web( uri, url, ind, path, fileName);
                case ExtensionType.FILE:
                    return new Download_File(uri, url, ind, path, fileName);
                default:
                    MessageBox.Show("something wrong");
                    return null;
            }
        }
    }
}
