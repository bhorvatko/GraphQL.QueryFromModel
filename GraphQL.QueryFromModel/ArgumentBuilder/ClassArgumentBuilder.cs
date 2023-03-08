using GraphQL.QueryFromModel.Extensions;

namespace GraphQL.QueryFromModel.ArgumentBuilder
{
    internal class ClassArgumentBuilder : ArgumentBuilder
    {
        private readonly ArgumentBuilderFactory argumentBuilderFactory;

        public ClassArgumentBuilder(ArgumentBuilderFactory argumentBuilderFactory)
        {
            this.argumentBuilderFactory = argumentBuilderFactory;
        }

        public override bool ValidForType(Type type) => type.GetProperties().Any() && !type.IsValueType;

        public override string GetArgumentValue(object propertyValue, Type propertyType)
        {
            string result = "{";

            result += propertyValue
                .GetType()
                .GetProperties()
                .Select(p => argumentBuilderFactory.GetArgumentBuilder(p.PropertyType).GetArgumentString(p.GetValue(propertyValue)!, p.Name, propertyType))
                .ConcatenateStrings((str1, str2) => str1 + ", " + str2);

            result += "}";

            return result;
        }
    }
}
