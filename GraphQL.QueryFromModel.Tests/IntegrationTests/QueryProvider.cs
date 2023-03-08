using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.QueryFromModel.Tests.IntegrationTests
{
    internal static class QueryProvider
    {
        public static string GetQuery(string name)
            => File.ReadAllText(Path.Combine("IntegrationTests", "Queries", name + ".txt")).NormalizeQuery();
    }
}
