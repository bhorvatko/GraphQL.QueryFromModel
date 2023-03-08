using GraphQL.QueryFromModel.Tests.IntegrationTests.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.QueryFromModel.Tests.IntegrationTests
{
    public class QueryBuilderTests
    {
        private readonly QueryBuilder queryBuilder = new QueryBuilder();

        [Theory]
        [InlineData("query01", typeof(ComplexType))]
        public void GivenAQueryTypeWithoutArguments_GeneratingAQuery_ReturnsTheExpectedResult(string queryName, Type queryType)
        {
            string expectedQuery = QueryProvider.GetQuery(queryName);

            string result = queryBuilder.BuildQuery(queryName, queryType);

            Assert.Equal(expectedQuery, result.NormalizeQuery());
        }

        [Theory]
        [InlineData("query02", typeof(SimpleType), typeof(ComplexType))]
        [InlineData("query03", typeof(ComplexType), typeof(ComplexType))]
        public void GivenAQueryTypeWithArguments_GeneratingAQuery_ReturnsTheExpectedResult(string queryName, Type queryType, Type argumentObjectType)
        {
            string expectedQuery = QueryProvider.GetQuery(queryName);
            object argumentObject = CreateArgumentObject(argumentObjectType);

            string result = queryBuilder.BuildQuery(queryName, argumentObject, queryType);

            Assert.Equal(expectedQuery, result.NormalizeQuery());
        }


        [Theory]
        [InlineData("query04", typeof(ComplexType))]
        public void GivenAnArgumentObjectWithoutAQueryType_GeneratingAMutation_ReturnsTheExpectedResult(string queryName, Type argumentObjectType)
        {
            string expectedQuery = QueryProvider.GetQuery(queryName);
            object argumentObject = CreateArgumentObject(argumentObjectType);

            string result = queryBuilder.BuildMutation(queryName, argumentObject);

            Assert.Equal(expectedQuery, result.NormalizeQuery());
        }

        private object CreateArgumentObject(Type argumentObjectType) => Activator.CreateInstance(argumentObjectType)!;
    }
}
