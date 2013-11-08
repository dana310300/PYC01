using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.Utilities.file
{
   public class FileContent
    {

       public static async Task<string> DownloadContentUrl(string url)
       {
           using (HttpClient client = new HttpClient() ) {
               string result = await client.GetStringAsync(url);
               return result;
           }
       }
    }
}
