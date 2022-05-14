using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Threading;


namespace FastDownloadManager
{
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
}
