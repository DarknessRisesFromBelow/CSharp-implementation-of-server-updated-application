using System;
using System.Net;
using System.IO;

namespace TestApplication
{
    class Connect
    {

        public static string GET(string ip, string options, int version)
        {
            string uri = ip + "/" + options + version;
            return this.HttpGet(uri);    
        } 

        public string HttpGet(string URI)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }
    }

    class Client
    {
    	static void Main(string[] args)
    	{
    		string ip = "insert your IP here";
    		string options = "Update";
    		RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Version");  
        	int version = 0;
			//if it does exist, retrieve the stored values  
			if (key != null)  
			{  
    			version = key.GetValue("version");  
    			key.Close();  
			} 
			// otherwise, store 0 as version and move on
			else
			{
				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Version"); 
				key.SetValue("version", "0");  
				version = 0;
			}
			// Send a Get Request using a method made above
    		Connect.GET(ip, options, version);
    	}
    }
}