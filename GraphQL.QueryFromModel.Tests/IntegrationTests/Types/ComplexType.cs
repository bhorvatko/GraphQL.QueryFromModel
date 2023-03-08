using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.QueryFromModel.Tests.IntegrationTests.Types
{
    internal class ComplexType
    {
        public Guid GuidProp { get; set; } = Guid.Parse("9bdf204b-a119-4a3d-82f5-d40172e6385b");
        public string StringProp { get; set; } = "StringPropValue";
        public int? IntProp { get; set; } = 10;
        public IEnumerable<NestedClass01> EnumerableProp { get; set; } = new List<NestedClass01>() { new NestedClass01(), new NestedClass01() };
    }

    internal class NestedClass01
    {
        public string NestedStringProp { get; set; } = "NestedStringProp";
        public bool NestedBoolProp { get; set; } = true;
    }
}
