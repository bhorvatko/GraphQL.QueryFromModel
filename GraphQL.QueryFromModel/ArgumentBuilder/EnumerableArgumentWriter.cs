using GraphQL.QueryFromModel.Extensions;
using System.Collections;

namespace GraphQL.QueryFromModel.ArgumentBuilder
{
    internal class EnumerableArgumentBuilder : ArgumentBuilder
    {
        private readonly ArgumentBuilderFactory argumentBuilderFactory;

        public EnumerableArgumentBuilder(ArgumentBuilderFactory argumentBuilderFactory)
        {
            this.argumentBuilderFactory = argumentBuilderFactory;
        }

        public override bool ValidForType(Type type) => type.IsAssignableTo(typeof(IEnumerable));

        public override string GetArgumentValue(object propertyValue, Type propertyType)
        {
            string result = "[";

            result += ((IEnumerable)propertyValue)
                .Cast<object>()
                .Select(e => argumentBuilderFactory.GetArgumentBuilder(e.GetType()).GetArgumentValue(e, propertyType))
                .ConcatenateStrings((str1, str2) => str1 + ", " + str2);

            result += "]";

            return result;
        }
    }
}
