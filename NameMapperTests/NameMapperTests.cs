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

    [Test]
    public void Should_Convert_Combination_Letter_To_Corresponding_Numerical_Value()
    {
        mapper.ConvertCombinationLetter("micheal").Should().Be("mi8eal");
    }
}