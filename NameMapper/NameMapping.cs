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

        Dictionary<string, int> lastLetter = new Dictionary<string, int>()
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
            if (!string.IsNullOrEmpty(name))
            {
                var spacedName = string.Join("", name.Select(letter => letter + " ").ToArray()).ToLower().Trim();
                for (int i = 0; i < spacedName.Length - 2; i++)
                {
                    string nameLetters = spacedName[i] + "" + spacedName[i + 2];
                    if (combinationLetters.ContainsKey(nameLetters))
                    {
                        spacedName = spacedName.Replace(spacedName[i] + " " + spacedName[i + 2], combinationLetters[nameLetters].ToString());
                    }
                }
                name = spacedName;
            }
            return name;
        }

        public string ConvertLastLetter(string name)
        {
            return name.Substring(0, name.Length - 1) + lastLetter[name.Last().ToString()].ToString();
        }

        public string ConvertSingleLetter(string name)
        {
            return string.Join(" ", name.Select(letter => Char.IsDigit(letter) ? letter-48: singleLetters[letter.ToString()]));
        }
    }
}

