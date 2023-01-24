using System;
using NameMapper.Model;

namespace NameMapper
{
	public class LifeAreasCalculator
	{
        LifeAreas lifeArea;
        public LifeAreasCalculator()
        {
            lifeArea = new LifeAreas();
        }

        public LifeAreas AllocateNumbersToLifeAreas(string numbers)
        {
            string WorldlyChallenges = "";
            string SpiritualChallenges = "";
            string WorldlyTalents = "";
            string SpiritualTalents = "";
            string WordlyGoals ="";
            string SpiritualGoals = "";
            int lifeAreaPosition = 0;

            foreach (string number in numbers.Split(' '))
            {
                lifeAreaPosition ++;
                switch (lifeAreaPosition)
                {
                    case 1: WorldlyChallenges += number + " "; break;
                    case 2: SpiritualChallenges += number + " "; break;
                    case 3: WorldlyTalents += number + " "; break;
                    case 4: SpiritualTalents += number + " "; break;
                    case 5: WordlyGoals += number + " "; break;
                    case 6: SpiritualGoals += number + " "; lifeAreaPosition = 0; break;
                };
            }

            lifeArea.WorldlyChallenges = CalculateLifeArea(WorldlyChallenges);
            lifeArea.SpiritualChallenges = CalculateLifeArea(SpiritualChallenges);
            lifeArea.WorldlyTalents = CalculateLifeArea(WorldlyTalents);
            lifeArea.SpiritualTalents = CalculateLifeArea(SpiritualTalents);
            lifeArea.WordlyGoals = CalculateLifeArea(WordlyGoals);
            lifeArea.SpiritualGoals = CalculateLifeArea(SpiritualGoals);

            return lifeArea;
        }

        private string CalculateLifeArea(string lifeArea)
        {
            int sum = lifeArea.Trim().Split(' ').Sum(x => Int32.Parse(x.ToString()));
            if (sum > 22)
                sum = sum.ToString().Sum(x => Int32.Parse(x.ToString()));
            return sum.ToString() + "-" + sum.ToString().Sum(x => Int32.Parse(x.ToString()));
        }
    }
}
