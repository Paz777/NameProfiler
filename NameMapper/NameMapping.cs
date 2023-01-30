using System.Diagnostics.Metrics;
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

        Dictionary<string, int> lastLetters = new Dictionary<string, int>()
        {
            {"m",12},
            {"p",12},
        };

        Dictionary<string, int> singleLetters = new Dictionary<string, int>()
        {
            {"a",1},
            {"b",2},
            {"c",11},
            {"d",4},
            {"e",5},
            {"f",18},
            {"g",3},
            {"h",5},
            {"i",10},
            {"j",10},
            {"k",19},
            {"l",12},
            {"m",13},
            {"n",14},
            {"o",6},
            {"p",17},
            {"q",19},
            {"r",20},
            {"s",15},
            {"t",9},
            {"u",6},
            {"v",6},
            {"w",6},
            {"x",15},
            {"y",16},
            {"z",7},
        };

        public string ConvertCombinationLetter(string name)
		{
            var nameWithSpaces = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                nameWithSpaces = string.Join("", name.Where(x => x != ' ').ToArray());
                nameWithSpaces = string.Join("", nameWithSpaces.Select(x => x + " ").ToArray()).ToLower().Trim();
                for (int i = 0; i < nameWithSpaces.Length - 2; i++)
                {
                    var combinedLetters = nameWithSpaces[i] + "" + nameWithSpaces[i + 2];
                    if (combinationLetters.ContainsKey(combinedLetters))
                    {
                        nameWithSpaces = nameWithSpaces.Replace(nameWithSpaces[i] + " " + nameWithSpaces[i + 2], combinationLetters[combinedLetters].ToString());
                    }
                }
                return nameWithSpaces;
            }
            return name;
        }

        public string ConvertLastLetter(string name)
        {
            if (lastLetters.ContainsKey(name.Last().ToString()))
            {
                return name.Substring(0, name.Length - 1) + lastLetters[name.Last().ToString()].ToString();
            }
            return name;   
        }

        public string ConvertSingleLetter(string name)
        {
            var convertedName = "";
            var nameSplit = name.Split(" ");
            for (int i = 0; i < nameSplit.Length; i++)
            {
                if (int.TryParse(nameSplit[i], out int number))
                {
                    convertedName += nameSplit[i] + " ";
                }
                else if (nameSplit[i] != " ")
                {
                    convertedName += singleLetters[nameSplit[i]] + " ";
                }
            }
            return convertedName.Trim();
        }
    }
}

