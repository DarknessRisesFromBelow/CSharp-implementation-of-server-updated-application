using System;
using System.Net;
using System.IO;


namespace TestApplication.Utility.Requests
{
	class requestHandler
	{
		public static string GET(string URL)
		{
			WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(URL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);


            return(objReader.ReadToEnd());
		}
	}
}