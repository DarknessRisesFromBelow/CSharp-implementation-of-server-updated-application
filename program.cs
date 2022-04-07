using TestApplication.Client;
using TestApplication.Utility;


//run a client.
Client c = new();
List<string> strings = StringSplitter.Split(c.Execute("Your Server's IP here"));
Console.Write(strings.Count);


//loop over every item in strings list. each one is a path to a file.
for(int i = 0; i < strings.Count; i++)
{	
	//then we make sure that it absolutely is a valid name for a file
	if(strings[i][0]!= '.' && strings[i].Contains("."))
		//then we retrieve the file.
		Client.MakeFile("", strings[i], Client.GetFile("Your Server's IP here", strings[i]));
}


