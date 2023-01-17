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

    [TestCase("micheal", "mi8eal")]
    [TestCase("michealtz", "mi8eal18")]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value(string name, string nameConverted)
    {
        mapper.ConvertCombinationLetter(name).Should().Be(nameConverted);
    }

    [TestCase("Micheal", "mi8eal")]
    [TestCase("MicHeal", "mi8eal")]
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