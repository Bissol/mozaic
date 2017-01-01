using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;

namespace mozaic
{
    class WebUploader
    {
        const string urlBase = "http://www.debarena.com/moz/php/";
        const string key = "7B9C8653-72EA-4CBC-BF86-41DE96A7C112";

        public async static Task<string> createFolder(string folderName)
        {
            /*var builder = new UriBuilder(urlBase + "makeDirectory.php");
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["dir"] = folderName;
            query["key"] = key;
            builder.Query = query.ToString();
            string url = builder.ToString();*/

            using (var client = new HttpClient())
            {
                var s = await client.GetStringAsync(urlBase + "makeDirectory.php/?dir=" + folderName + "&key=" + key);
                return s;
            }
        }

        public async static Task<string> getUploadedTileNames(string remoteDir)
        {
            using (var client = new HttpClient())
            {
                var s = await client.GetStringAsync(urlBase + "getTileList.php/?dir=" + remoteDir + "&key=" + key);
                return s;
            }
        }

        public async static Task<string> uploadTile(string tileLocalPath, string remoteDir, string remoteName)
        {
            var builder = new UriBuilder(urlBase + "uploadTile.php");
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["dir"] = remoteDir;
            query["key"] = key;
            query["name"] = remoteName;
            builder.Query = query.ToString();
            string url = builder.ToString();

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "binary/octet-stream");
                byte[] result = client.UploadFile(url, "POST", tileLocalPath);

                string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                return s;
            }

            /*HttpContent stringContentDir = new StringContent(remoteDir);
            HttpContent stringContentId = new StringContent(remoteName);
            HttpContent stringContentKey = new StringContent(key);

            Stream tileContent = File.OpenRead(tileLocalPath);
            HttpContent fileStreamContent = new StreamContent(tileContent);
            //HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContentKey, "key", "key");
                formData.Add(stringContentDir, "folder", "folder");
                formData.Add(stringContentId, "name", "name");
                formData.Add(fileStreamContent, "file1", "file1");
                //formData.Add(bytesContent, "file2", "file2");
                var response = client.PostAsync(url, formData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStringAsync();
                //return response.Content.ReadAsStreamAsync().Result;
            }*/
        }

        public async static Task<string> uploadColorData(string cdataPath, string remoteDir, string remoteName)
        {
            var builder = new UriBuilder(urlBase + "uploadTile.php");
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["dir"] = remoteDir;
            query["key"] = key;
            query["name"] = remoteName;
            builder.Query = query.ToString();
            string url = builder.ToString();

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "binary/octet-stream");
                byte[] result = client.UploadFile(url, "POST", cdataPath);

                string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                return s;
            }
        }
   }
}
