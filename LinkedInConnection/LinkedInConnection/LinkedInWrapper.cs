using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedIn.NET;
using System.Net.Http;

namespace LinkedInConnection
{
    public class LinkedInWrapper
    {
        public static string  Authenticate()
        {
            LinkedInClient cli = new LinkedInClient("772zhp34kzq7zq", "egWBwcHlsa0CdGvC");
            LinkedIn.NET.Options.LinkedInAuthorizationOptions opt = new LinkedIn.NET.Options.LinkedInAuthorizationOptions();
            opt.Permissions = LinkedInPermissions.BasicProfile;
            opt.RedirectUrl = "https://192.168.0.26:9090/api/Home/SayHi";
            opt.State = "apple";
            string url = cli.GetAuthorizationUrl(opt);
            HttpClient hc = new HttpClient();
            string result=hc.GetStringAsync(url).Result;
            //System.IO.File.WriteAllText(@"C:\Users\raome\Desktop\Page.html", result);
            //System.Diagnostics.Process.Start(@"C:\Users\raome\Desktop\Page.html");
            
            //cli.GetAccessToken("AQSfizApWxG0YYF5FUfKMrSK4Nx0ZDO1ycQv1ggaID8NDn_ZU0Cj3vEpAwE8fGEwnMAojJ0RraQObi7wJHP5sKgsypDM2SzHsuxmkbmtnYEaeAjHNkE",
            //                     "https://192.168.0.26:9090/api/Home/SayHi");
          
            
            return url;
           
            
        }
        
    }
}
