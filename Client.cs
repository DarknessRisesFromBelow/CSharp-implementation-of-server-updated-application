using TestApplication.Utility.Requests;
using System;
using System.IO;
using Microsoft.Win32;
using System.Text;  

namespace TestApplication.Client
{
    class Client
    {
    	//ip = your server's IP
    	public string Execute(string ip)
    	{
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
    		return (GetUpdateState(ip, version));
           
       
    	}

    	public static string GetUpdateState(string ip, int version) => requestHandler.GET("http://" + ip + ":8080/update"+version);

    	public static string GetFile(string ip, string FileName) => requestHandler.GET("http://" + ip + ":8080/" + FileName);

    	public static int MakeFile(string path, string name, string content)
    	{
    		path = path + name;
    		if (File.Exists(path))  
        	{  
            	File.Delete(path);  
        	} 
        	FileStream fs = File.Create(path);
        	fs.Write(new UTF8Encoding(true).GetBytes(content)); 
        	fs.Flush();
        	fs.Close();
        	return 0;
    	}
    }
}