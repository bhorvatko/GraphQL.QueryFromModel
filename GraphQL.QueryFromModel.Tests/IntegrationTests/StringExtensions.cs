using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.QueryFromModel.Tests.IntegrationTests
{
    internal static class StringExtensions
    {
        public static string NormalizeQuery(this string query) 
            => query.Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
    }
}
