using System.Linq;

namespace NameMapper
{
	public class NameMapping
	{
		Dictionary<string, int> combinationLetters = new Dictionary<string, int>()
		{
			{"ah",5},
            {"ch",8},
            {"wh",16},
            {"tz",18},
            {"sh",21},
            {"ta",22},
            {"th",22},
        };

		public string ConvertCombinationLetter(string name)
		{
            for (int i = 0; i < name.Length - 1; i++)
            {
                string nameLetters = name[i] + "" + name[i + 1];
                nameLetters = nameLetters.ToLower();
                if (combinationLetters.ContainsKey(nameLetters))
                {
                    name = name.Replace(nameLetters, combinationLetters[nameLetters].ToString());
                }
            }
            Console.WriteLine("Hello world " + name);
            return name;

        }
    }
}

