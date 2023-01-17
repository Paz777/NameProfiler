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

    [TestCase("Micheal", "mi8eal")]
    [TestCase("MicHeAl", "mi8eal")]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value_With_Name_Using_Capital_Letters(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [Test]
    public void Should_Convert_Single_Letter_To_Corresponding_Numerical_Value()
    {
        mapper.ConvertSingleLetter("paz").Should().Be("17 1 7");
    }
}