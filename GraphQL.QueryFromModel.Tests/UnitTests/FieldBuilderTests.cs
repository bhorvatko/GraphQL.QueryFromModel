using GraphQL.QueryFromModel.ArgumentBuilder;
using GraphQL.QueryFromModel.FieldBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.QueryFromModel.Tests.UnitTests
{
    public class FieldBuilderTests
    {
        private FieldBuilderFactory fieldBuilderFactory = new FieldBuilderFactory();

        [Fact]
        public void GivenALiteralType_BuildingTheField_ReturnsTheExpectedResult()
        {
            string argument = string.Empty;

            string fieldString = GetFieldString(argument);

            Assert.Equal("prop", fieldString);
        }

        [Fact]
        public void GivenAnEnumerableOfLiterals_BuildingTheField_ReturnsTheExpectedResult()
        {
            IEnumerable<string> argument = new List<string>() { "Test1", "Test2" };

            string fieldString = GetFieldString(argument);

            Assert.Equal("prop", fieldString);
        }

        [Fact]
        public void GivenAComplexType_BuildingTheField_ReturnsTheExpectedResult()
        {
            var argument = new { StrProp = "StrTest", IntProp = 1 };

            string fieldString = GetFieldString(argument);

            Assert.Equal("prop {strProp, intProp}", fieldString);
        }

        private string GetFieldString(object argument)
            => fieldBuilderFactory.GetFieldBuilder(argument.GetType()).GetField("Prop", argument.GetType());
    }
}
