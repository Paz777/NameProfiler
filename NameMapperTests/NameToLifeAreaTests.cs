using System;
using NameMapper;
using NameMapper.Model;
using NUnit.Framework;
using FluentAssertions;

namespace NameMapperTests
{
	public class NameToLifeAreaTests
	{
        NameMapping nameMapping1;
        LifeAreasCalculator lifeAreasCalculator1;
        LifeAreas lifeAreas1;

        [SetUp]
        public void Setup()
        {
            nameMapping1 = new NameMapping();
            lifeAreasCalculator1 = new LifeAreasCalculator();
            lifeAreas1 = new LifeAreas();
        }

        [TestCase("Paz Sonagara", "18-9", "4-4", "8-8", "8-8", "7-7", "14-5", "14-5", "8")]
        public void S1hould_Convert_Full_Name_To_All_Life_Areas(string name, string worldlyChallenges, string spiritualChallenges, string worldlyTalents,
        string spiritualTalents, string wordlyGoals, string spiritualGoals, string soulDestiny, string dominantVibration)
        {
            var nameConvertCombinationLetters = nameMapping1.ConvertCombinationLetter(name);
            var nameConvertLastLetters = nameMapping1.ConvertLastLetter(nameConvertCombinationLetters);
            var nameConvertSingleLetters = nameMapping1.ConvertSingleLetter(nameConvertLastLetters);
            lifeAreas1 = lifeAreasCalculator1.AllocateNumbersToLifeAreas(nameConvertSingleLetters);
            lifeAreas1.SoulDestiny = lifeAreasCalculator1.CalculateSoulDestiny(lifeAreas1);
            lifeAreas1.DominantVibration = lifeAreasCalculator1.CalculateDominantVibration(lifeAreas1);

            lifeAreas1.WorldlyChallenges.Should().Be(worldlyChallenges);
            lifeAreas1.SpiritualChallenges.Should().Be(spiritualChallenges);
            lifeAreas1.WorldlyTalents.Should().Be(worldlyTalents);
            lifeAreas1.SpiritualTalents.Should().Be(spiritualTalents);
            lifeAreas1.WordlyGoals.Should().Be(wordlyGoals);
            lifeAreas1.SpiritualGoals.Should().Be(spiritualGoals);
            lifeAreas1.SoulDestiny.Should().Be(soulDestiny);
            lifeAreas1.DominantVibration.Should().Be(dominantVibration);


        }
    }
}

