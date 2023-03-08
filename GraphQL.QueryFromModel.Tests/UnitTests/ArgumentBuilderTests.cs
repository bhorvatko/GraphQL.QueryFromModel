using GraphQL.QueryFromModel.ArgumentBuilder;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace GraphQL.QueryFromModel.Tests.UnitTests
{
    public class ArgumentBuilderTests
    {
        private readonly ArgumentBuilderFactory argumentBuilderFactory = new ArgumentBuilderFactory();

        [Fact]
        public void GivenAString_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            string argument = "test";

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: \"test\"", argumentString);
        }

        [Fact]
        public void GivenADateTime_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            DateTime argument = new DateTime(2022, 08, 10);

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: \"10/08/2022 00:00:00\"", argumentString);
        }

        [Fact]
        public void GivenAnInteger_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            int argument = 10;

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: 10", argumentString);
        }

        [Fact]
        public void GivenANullableInteger_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            int? argument = 10;

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: 10", argumentString);
        }

        [Fact]
        public void GivenABoolean_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            bool argument = true;

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: true", argumentString);
        }

        [Fact]
        public void GivenAList_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            IEnumerable<string> argument = new List<string>()
            {
                "test1",
                "test2"
            };

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: [\"test1\", \"test2\"]", argumentString);
        }

        [Fact]
        public void GivenAComplexObject_BuildingTheArgument_ReturnsTheExpectedResult()
        {
            var argument = new
            {
                StrProp = "TestStr",
                IntProp = 10,
                ListProp = new List<bool>() { true, false }
            };

            string argumentString = GetArgumentString(argument);

            Assert.Equal("prop: {strProp: \"TestStr\", intProp: 10, listProp: [true, false]}", argumentString);
        }

        private string GetArgumentString(object argument)
            => argumentBuilderFactory.GetArgumentBuilder(argument.GetType()).GetArgumentString(argument, "prop", argument.GetType());

    }
}