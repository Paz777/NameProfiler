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
            for (int i = 0; i < name.Length - 1; i++)
            {
                string nameLetters = name[i] + "" + name[i + 1];
                nameLetters = nameLetters.ToLower();
                if (combinationLetters.ContainsKey(nameLetters))
                {
                    name = name.Replace(nameLetters, combinationLetters[nameLetters].ToString());
                }
            }
            return name;
        }

        public string ConvertSingleLetter(string name)
        {
            return string.Join(" ", name.Select(letter => singleLetters[letter.ToString()]));
        }
    }
}

