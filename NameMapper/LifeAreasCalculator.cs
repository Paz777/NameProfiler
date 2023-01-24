using System;
using NameMapper.Model;

namespace NameMapper
{
	public class LifeAreasCalculator
	{
        LifeAreas la;
        public LifeAreasCalculator()
        {
            la = new LifeAreas();
        }

        public LifeAreas AllocateNumbersToLifeAreas(string numbers)
        {
            string numbersCopy = numbers;
            string WorldlyChallenges = "";
            string SpiritualChallenges = "";
            string WorldlyTalents = "";
            string SpiritualTalents = "";
            string WordlyGoals ="";
            string SpiritualGoals = "";
            int variableIndex = 0;
            foreach (string number in numbers.Split(' '))
            {
                variableIndex ++;
                if (variableIndex == 1) WorldlyChallenges += number + " ";
                else if (variableIndex == 2) SpiritualChallenges += number + " ";
                else if (variableIndex == 3) WorldlyTalents += number + " ";
                else if (variableIndex == 4) SpiritualTalents += number + " ";
                else if (variableIndex == 5) WordlyGoals += number + " ";
                else if (variableIndex == 6) { SpiritualGoals += number + " "; variableIndex = 0; }
            }
            int sum = 0;
            foreach(string number in WorldlyChallenges.Trim().Split(' '))
            {
                sum += int.Parse(number);
            }
            if (sum > 22) sum = sum.ToString().Sum(x => Int32.Parse(x.ToString()));
            WorldlyChallenges = sum.ToString() + "-" + ((sum.ToString().Length>1) ? sum.ToString().Sum(x => Int32.Parse(x.ToString())) : sum.ToString());
            sum = 0;
            foreach (string number in SpiritualChallenges.Trim().Split(' '))
            {
                sum += int.Parse(number);
            }
            if (sum > 22) sum =  sum.ToString().Sum(x=>Int32.Parse(x.ToString()));
            SpiritualChallenges = sum.ToString() + "-" + ((sum.ToString().Length > 1) ? sum.ToString().Sum(x => Int32.Parse(x.ToString())) : sum.ToString());
            sum = 0;
            foreach (string number in WorldlyTalents.Trim().Split(' '))
            {
                sum += int.Parse(number);
            }
            if (sum > 22) sum = sum.ToString().Sum(x => Int32.Parse(x.ToString()));
            WorldlyTalents = sum.ToString() + "-" + ((sum.ToString().Length > 1) ? sum.ToString().Sum(x => Int32.Parse(x.ToString())) : sum.ToString());
            sum = 0;
            foreach (string number in SpiritualTalents.Trim().Split(' '))
            {
                sum += int.Parse(number);
            }
            if (sum > 22) sum = sum.ToString().Sum(x => Int32.Parse(x.ToString()));
            SpiritualTalents = sum.ToString() + "-" + ((sum.ToString().Length > 1) ? sum.ToString().Sum(x => Int32.Parse(x.ToString())) : sum.ToString());
            sum = 0;
            foreach (string number in WordlyGoals.Trim().Split(' '))
            {
                sum += int.Parse(number);
            }
            if (sum > 22) sum = sum.ToString().Sum(x => Int32.Parse(x.ToString()));
            WordlyGoals = sum.ToString() + "-" + ((sum.ToString().Length > 1) ? sum.ToString().Sum(x => Int32.Parse(x.ToString())) : sum.ToString());
            sum = 0;
            foreach (string number in SpiritualGoals.Trim().Split(' '))
            {
                sum += int.Parse(number);
            }
            if (sum > 22) sum = sum.ToString().Sum(x => Int32.Parse(x.ToString()));
            SpiritualGoals = sum.ToString() + "-" + ((sum.ToString().Length > 1) ? sum.ToString().Sum(x => Int32.Parse(x.ToString())) : sum.ToString());

            la.WorldlyChallenges = WorldlyChallenges;
            la.SpiritualChallenges = SpiritualChallenges;
            la.WorldlyTalents = WorldlyTalents;
            la.SpiritualTalents = SpiritualTalents;
            la.WordlyGoals = WordlyGoals;
            la.SpiritualGoals = SpiritualGoals;

            return la;
        }
     }
}
