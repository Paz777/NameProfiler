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

    [TestCase("abbah", "abb5", TestName = "Should_Convert_Combination_Letter_AB_To_Corresponding_Numerical_Value")]
    [TestCase("micheal", "mi8eal", TestName = "Should_Convert_Combination_Letter_MI_To_Corresponding_Numerical_Value")]
    [TestCase("whitney", "16itney", TestName = "Should_Convert_Combination_Letter_WH_To_Corresponding_Numerical_Value")]
    [TestCase("tzara", "18ara", TestName = "Should_Convert_Combination_Letter_TZ_To_Corresponding_Numerical_Value")]
    [TestCase("shanaya", "21anaya", TestName = "Should_Convert_Combination_Letter_SH_To_Corresponding_Numerical_Value")]
    [TestCase("talar", "22lar", TestName = "Should_Convert_Combination_Letter_TA_To_Corresponding_Numerical_Value")]
    [TestCase("annabeth", "annabe22", TestName = "Should_Convert_Combination_Letter_AN_To_Corresponding_Numerical_Value")]
    [TestCase("michealtz", "mi8eal18", TestName = "Should_Convert_Combination_Letter_MI_And_TZ_To_Corresponding_Numerical_Value")]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("1234", "1234", TestName = "Should_Not_Convert_Numerical_Value")]
    [TestCase("", "", TestName = "Should_Not_Convert_Empty_String")]
    [TestCase("talar 45%", "22lar 45%", TestName = "Should_Not_Convert_Other_Invalid_Characters")]
    [TestCase(null, null, TestName = "Should_Not_Convert_Null")]
    public void Should_Not_Convert_Invalid_Values(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("Micheal", "mi8eal")]
    [TestCase("MicHeAl", "mi8eal")]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value_With_Name_Using_Capital_Letters(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    //Indrabp
    [TestCase("Phillip","Philli12")]
    [TestCase("Pam", "Pa12")]
    [TestCase("Indrabp", "Indrab12")]
    public void Should_Convert_Last_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertLastLetter(name).Should().Be(nameConverted);
    }

    //mi8eal
    [Test]
    public void Should_Convert_Single_Letter_To_Corresponding_Numerical_Value()
    {
        mapper.ConvertSingleLetter("paz").Should().Be("17 1 7");
    }
}