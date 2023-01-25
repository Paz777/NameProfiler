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

        public string CalculateSoulDestiny(LifeAreas lifeArea)
        {
            var wordlyChallenges = lifeArea.WorldlyChallenges.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var spiritualChallenges = lifeArea.SpiritualChallenges.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var wordlyTalents = lifeArea.WorldlyTalents.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var spiritualTalents = lifeArea.SpiritualTalents.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var wordlyGoals = lifeArea.WordlyGoals.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var spiritualGoals = lifeArea.SpiritualGoals.Split("-").Select(x => Int32.Parse(x)).ToArray();

            var leftSoulDestinyTotal = wordlyChallenges[0] + spiritualChallenges[0] + wordlyTalents[0] + spiritualTalents[0] + wordlyGoals[0] + spiritualGoals[0];
            var rightSoulDestinyTotal = wordlyChallenges[1] + spiritualChallenges[1] + wordlyTalents[1] + spiritualTalents[1] + wordlyGoals[1] + spiritualGoals[1];

            var leftSoulDestinyNumber = RecalculateIfNumberGreaterThan22(leftSoulDestinyTotal);
            var rightSoulDestinyNumber = RecalculateIfNumberGreaterThan22(rightSoulDestinyTotal);

            return leftSoulDestinyNumber + "-" + rightSoulDestinyNumber;
        }

        private string CalculateLifeArea(string lifeArea)
        {
            int sum = lifeArea.Trim().Split(' ').Sum(x => Int32.Parse(x.ToString()));
            int lifeAreaNumber = RecalculateIfNumberGreaterThan22(sum);
            return lifeAreaNumber.ToString() + "-" + RecalculateIfNumberEqualTo19(lifeAreaNumber);
        }

        private int RecalculateIfNumberEqualTo19(int number)
        {
            return (number == 19) ? 1 : number.ToString().Sum(x => Int32.Parse(x.ToString()));
        }

        private int RecalculateIfNumberGreaterThan22(int number)
        {
            return (number > 22) ? number.ToString().Sum(x => Int32.Parse(x.ToString())) : number;
        }
    }
}
