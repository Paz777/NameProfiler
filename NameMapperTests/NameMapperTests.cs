using NUnit.Framework;
using NameMapper;
using NameMapper.Model;
using FluentAssertions;

namespace NameMapperTests;

public class Tests
{
    NameMapping mapper;

    [SetUp]
    public void Setup()
    {
        mapper = new NameMapping();
    }

    [TestCase("abbah", "a b b 5", TestName = "Should_Convert_Combination_Letter_AH_To_Corresponding_Numerical_Value")]
    [TestCase("micheal", "m i 8 e a l", TestName = "Should_Convert_Combination_Letter_CH_To_Corresponding_Numerical_Value")]
    [TestCase("whitney", "16 i t n e y", TestName = "Should_Convert_Combination_Letter_WH_To_Corresponding_Numerical_Value")]
    [TestCase("tzara", "18 a r a", TestName = "Should_Convert_Combination_Letter_TZ_To_Corresponding_Numerical_Value")]
    [TestCase("shanaya", "21 a n a y a", TestName = "Should_Convert_Combination_Letter_SH_To_Corresponding_Numerical_Value")]
    [TestCase("talar", "22 l a r", TestName = "Should_Convert_Combination_Letter_TA_To_Corresponding_Numerical_Value")]
    [TestCase("annabeth", "a n n a b e 22", TestName = "Should_Convert_Combination_Letter_AN_To_Corresponding_Numerical_Value")]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("michealtz", "m i 8 e a l 18", TestName = "Should_Convert_Combination_Letter_MI_And_TZ_To_Corresponding_Numerical_Value")]
    public void Should_Convert_Combination_Letter_Twice_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("1234", "1 2 3 4", TestName = "Should_Not_Convert_Numerical_Value")]
    [TestCase("", "", TestName = "Should_Not_Convert_Empty_String")]
    [TestCase("%$£", "% $ £", TestName = "Should_Not_Convert_Other_Invalid_Characters")]
    [TestCase(null, null, TestName = "Should_Not_Convert_Null")]
    public void Should_Not_Convert_Invalid_Values(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("Micheal", "m i 8 e a l", TestName = "Should_Convert_When_Using_Capital_Letters")]
    [TestCase("MicHeAl", "m i 8 e a l", TestName = "Should_Convert_When_Using_Capital_Letters_In_Middle_Of_Name")]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value_With_Name_Using_Capital_Letters(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("p h i l l i p", "p h i l l i 12", TestName = "Should_Convert_Last_Letter_P_Not_The_First_Letter_To_Corresponding_Numerical_Value")]
    [TestCase("p a m", "p a 12", TestName = "Should_Convert_Last_Letter_M_To_Corresponding_Numerical_Value")]
    [TestCase("i n d r 5 p", "i n d r 5 12", TestName = "Should_Convert_Last_Letter_P_Not_Other_Numbers_To_Corresponding_Numerical_Value")]
    public void Should_Convert_Last_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertLastLetter(name).Should().Be(nameConverted);
    }

    [TestCase("m i 8 e a l", "13 10 8 5 1 12", TestName = "Should_Convert_All_Single_Letters_Not_Numbers_To_Corresponding_Numerical_Value")]
    [TestCase("m i 22 e a l", "13 10 22 5 1 12", TestName = "Should_Convert_All_Single_Letters_Not_Double_Digit_Numbers_To_Corresponding_Numerical_Value")]
    [TestCase("p a z", "17 1 7", TestName = "Should_Convert_All_Single_Letters_To_Corresponding_Numerical_Value")]
    public void Should_Convert_Single_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertSingleLetter(name).Should().Be(nameConverted);
    }

    [TestCase("13 10 8 1 5 12 6 10 12 12 10 1 13 15 1 13 17 15 6 14", "11-2", "13-4", "21-3", "8-8", "5-5", "10-1", TestName = "Should_Allocate_Numbers_Sequentially_To_The_Corresponding_Life_Areas_And_Calculate_For_Micheal")]
    [TestCase("1 12 1 14 10 6 14 1 22 1 14 6 16 12 4 13 1 14", "4-4", "7-7", "9-9", "10-1", "7-7", "8-8", TestName = "Should_Allocate_Numbers_Sequentially_To_The_Corresponding_Life_Areas_And_Calculate_For_Alan")]
    public void Should_Allocate_Numbers_Sequentially_To_The_Corresponding_Life_Areas_And_Calculate(string numbers, string worldlyChallenges,
        string spiritualChallenges, string worldlyTalents, string spiritualTalents, string wordlyGoals, string spiritualGoals)
    {
        LifeAreas lifeAreas1 = new LifeAreas();
        LifeAreasCalculator lifeAreasCalculator1 = new LifeAreasCalculator();

        lifeAreas1 = lifeAreasCalculator1.AllocateNumbersToLifeAreas(numbers);
        lifeAreas1.WorldlyChallenges.Should().Be(worldlyChallenges);
        lifeAreas1.SpiritualChallenges.Should().Be(spiritualChallenges);
        lifeAreas1.WorldlyTalents.Should().Be(worldlyTalents);
        lifeAreas1.SpiritualTalents.Should().Be(spiritualTalents);
        lifeAreas1.WordlyGoals.Should().Be(wordlyGoals);
        lifeAreas1.SpiritualGoals.Should().Be(spiritualGoals);
    }
}