using TestApplication.Utility.Requests;
using System;
using Microsoft.Win32;

namespace TestApplication.Client
{
    class Connect
    {
        public static string GET(string ip, int port, string options)
        {
            string uri = "http://" + ip + ":"+port+"/" + options;
            return requestHandler.GET(uri);    
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

            options = options + version;
			// Send a Get Request using a method made above
    		return (Connect.GET(ip, 8080, options));
           
       
    	}

    	public static string GetFile() => requestHandler.GET("http://localhost:8000/RunClient.py");
    }
}