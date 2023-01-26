using System;
using NameMapper.Model;

namespace NameMapper
{
	public class LifeAreasCalculator
	{
        LifeAreas lifeArea;
        const int SPECIAL_CASE_NO_19 = 19;
        const int SPECIAL_CASE_NO_22 = 22;
        const int RIGHT_HAND_NUMBER_DEFAULT_1 = 1;

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

        public string CalculateSoulDestiny(LifeAreas lifeAreas)
        {
            var wordlyChallenges = lifeAreas.WorldlyChallenges.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var spiritualChallenges = lifeAreas.SpiritualChallenges.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var wordlyTalents = lifeAreas.WorldlyTalents.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var spiritualTalents = lifeAreas.SpiritualTalents.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var wordlyGoals = lifeAreas.WordlyGoals.Split("-").Select(x => Int32.Parse(x)).ToArray();
            var spiritualGoals = lifeAreas.SpiritualGoals.Split("-").Select(x => Int32.Parse(x)).ToArray();

            var leftSoulDestinyTotal = wordlyChallenges[0] + spiritualChallenges[0] + wordlyTalents[0] + spiritualTalents[0] + wordlyGoals[0]
                + spiritualGoals[0];
            var rightSoulDestinyTotal = wordlyChallenges[1] + spiritualChallenges[1] + wordlyTalents[1] + spiritualTalents[1] + wordlyGoals[1]
                + spiritualGoals[1];

            var leftSoulDestinyNumber = RecalculateIfNumberGreaterThan22(leftSoulDestinyTotal);
            var rightSoulDestinyNumber = RecalculateIfNumberGreaterThan22(rightSoulDestinyTotal);

            return leftSoulDestinyNumber + "-" + (leftSoulDestinyNumber == SPECIAL_CASE_NO_19 ? RIGHT_HAND_NUMBER_DEFAULT_1 : rightSoulDestinyNumber);
        }

        public string CalculateDominantVibration(LifeAreas lifeAreas)
        {
            var lifeAreaNumbers = new List<int>();
            lifeAreaNumbers.AddRange(lifeAreas.WorldlyChallenges.Split("-").Select(x => Int32.Parse(x)));
            lifeAreaNumbers.AddRange(lifeAreas.SpiritualChallenges.Split("-").Select(x => Int32.Parse(x)));
            lifeAreaNumbers.AddRange(lifeAreas.WorldlyTalents.Split("-").Select(x => Int32.Parse(x)));
            lifeAreaNumbers.AddRange(lifeAreas.SpiritualTalents.Split("-").Select(x => Int32.Parse(x)));
            lifeAreaNumbers.AddRange(lifeAreas.WordlyGoals.Split("-").Select(x => Int32.Parse(x)));
            lifeAreaNumbers.AddRange(lifeAreas.SpiritualGoals.Split("-").Select(x => Int32.Parse(x)));
            lifeAreaNumbers.AddRange(lifeAreas.SoulDestiny.Split("-").Select(x => Int32.Parse(x)));

            return string.Join(",", lifeAreaNumbers.GroupBy(grp => grp).Where(grp => grp.Count() > 3).Select(x => x.Key).ToList());
        }

        private string CalculateLifeArea(string lifeAreas)
        {
            int sum = lifeAreas.Trim().Split(' ').Sum(x => Int32.Parse(x.ToString()));
            int lifeAreaNumber = RecalculateIfNumberGreaterThan22(sum);
            return lifeAreaNumber.ToString() + "-" + RecalculateIfNumberEqualTo19(lifeAreaNumber);
        }

        private int RecalculateIfNumberEqualTo19(int number)
        {
            return (number == SPECIAL_CASE_NO_19) ? RIGHT_HAND_NUMBER_DEFAULT_1 : number.ToString().Sum(x => Int32.Parse(x.ToString()));
        }

        private int RecalculateIfNumberGreaterThan22(int number)
        {
            return (number > SPECIAL_CASE_NO_22) ? number.ToString().Sum(x => Int32.Parse(x.ToString())) : number;
        }


    }
}
