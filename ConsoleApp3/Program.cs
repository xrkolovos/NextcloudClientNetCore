using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DecaTec.WebDav;
using NextcloudClient.Exceptions;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        

        static async Task MainAsync()
        {
            //var xc = new WebDavClass();
            //await xc.RunAsync();

            string cloudUsr = "*********";
            string cloudPw = "******";
            string url = @"https://nextcloud.**********.gr/remote.php/webdav/";

            var nccl = new NextcloudClient.NextcloudClient(url, cloudUsr, cloudPw);

            var fff = await nccl.List("/");


            string pathToSave = @"c:\temp\nextcloud\";
            string docToSave = $"tmp432534534.docx";


            try
            {
            //    var cts = new CancellationTokenSource();
            //    IProgress<WebDavProgress> progress = new Progress<WebDavProgress>();

                FileStream dataToUpload = File.OpenRead(pathToSave + docToSave);
                dataToUpload.Position = 0;
                //var rr = await nccl.UploadWithProgressAsync("/", dataToUpload, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", progress, cts.Token);
                //var rr = await nccl.Upload("", "234fcdsg343e.docx", dataToUpload);
                //var rr = await nccl.Upload($"/{docToSave}", dataToUpload);

                var info = await nccl.GetResourceInfo("/", docToSave);
            }
            catch (ResponseError e2)
            {
                //ResponseErrorHandlerService.HandleException(e2);
            }

            Console.ReadLine();
        }
        

    }
}