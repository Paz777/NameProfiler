using NUnit.Framework;
using NameMapper;
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

    [TestCase("p h i l l i p","p h i l l i 12")]
    [TestCase("p a m", "p a 12")]
    [TestCase("i n d r a b p", "i n d r a b 12")]
    public void Should_Convert_Last_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertLastLetter(name).Should().Be(nameConverted);
    }

    [TestCase("m i 8 e a l","13 10 8 5 1 12")]
    [TestCase("m i 1 e a l", "13 10 1 5 1 12")]
    //[TestCase("mi3eal", "13 10 3 5 1 12")]
    //[TestCase("mi5eal", "13 10 5 5 1 12")]
    //[TestCase("mi13eal", "13 10 13 5 1 12")]
    [TestCase("m i 22 e a l", "13 10 22 5 1 12")]
    [TestCase("p a z","17 1 7")]
    public void Should_Convert_Single_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertSingleLetter(name).Should().Be(nameConverted);
    }
}