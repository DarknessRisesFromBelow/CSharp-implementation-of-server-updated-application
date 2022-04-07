using System.Linq;

namespace TestApplication.Utility
{
	class StringSplitter
	{
		public static List<string> Split(string input)
		{
			//replace unnecesarry stuff that got added whuke retrieving request.
			input = input.Replace("[", "").Replace("]", "").Replace("'","");
			
			//setup of everything needed
			List<string> items = new();
			string item = "";
			item+=input[0];

			//loop over every character in the string
			for(int i = 0; i < input.Length; i++)
			{	
				// if its a coma we shall end the string and add it to the items list
				if(input[i] == ',')
				{
					items.Add(item);
					item = "";
				}

				//if its a space after a coma then ignore it
				else if(i != 0 && input[i-1] != ',' && input[i] != ' ')
				{
					item+=input[i];
				}
			}
			// make sure that last item is in item list.
			items.Add(item);

			return items;
		}
	}
}