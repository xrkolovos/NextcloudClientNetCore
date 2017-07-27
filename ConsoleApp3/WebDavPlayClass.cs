using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DecaTec.WebDav;
//using porta;

namespace ConsoleApp3
{
    public class WebDavPlayClass
    {
        public async Task<bool> RunAsync()
        {
            string cloudUsr = "*******";
            string cloudPw = "****";
            string url = @"https://nextcloud.*****.gr/remote.php/webdav/";
            string pathToSave = @"c:\temp\nextcloud\";
            string docToSave = $"{pathToSave}tmp432534534.docx";
            try
            {
                // Basic authentication required
                var credentials = new NetworkCredential(cloudUsr, cloudPw);
                var webDavSession = new WebDavSession(@"https://nextcloud.egritosgroup.gr/remote.php/webdav/", credentials);
                //// OR without authentication
                //var client = new WebDAVClient.Client(new NetworkCredential());
                var items = await webDavSession.ListAsync(@"/");

                FileStream dataToUpload = File.OpenRead(docToSave);
                var uri = new Uri(@"https://nextcloud.egritosgroup.gr/remote.php/webdav/");
                var rrr = await webDavSession.UploadFileAsync(items[1], "asdasdasd.docx", dataToUpload);
            }
            catch (Exception e_cld)
            {
                Console.WriteLine("An error occurred: '{0}'", e_cld);
            }

            return true;
        }
    }
}
