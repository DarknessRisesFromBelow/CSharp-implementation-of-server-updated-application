using System;
using Microsoft.Win32;
using System.Net;
using System.IO;

namespace TestApplication
{
    class Connect
    {
        public static string GET(string ip, string options, int version)
        {
            string uri = "http://" + ip + ":8080"+"/" + options + version;
            return HttpGet(uri);    
        } 

        static string HttpGet(string remoteUri)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            byte[] data = client.DownloadData (remoteUri);
            string s = data.ToString();

            return s;
        }
    }

    class Client
    {
    	public string Execute()
    	{
    		string ip = "your server's IP here";
    		string options = "Update";
    		RegistryKey ParentKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Version");  
        	int version = 0;
			//if it does exist, retrieve the stored values  
			if (ParentKey != null)  
			{  
    			version = int.Parse(ParentKey.GetValue("version").ToString());  
    			ParentKey.Close();  
			} 
			// otherwise, store 0 as version and move on
			else
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Version"); 
				key.SetValue("version", "0");  
				version = 0;
			}
			// Send a Get Request using a method made above
    		return (Connect.GET(ip, options, version));
           
       
    	}
    }
}