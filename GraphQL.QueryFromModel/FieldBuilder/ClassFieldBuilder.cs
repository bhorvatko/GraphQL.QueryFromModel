using GraphQL.QueryFromModel.Extensions;

namespace GraphQL.QueryFromModel.FieldBuilder
{
    internal class ClassFieldBuilder : IFieldBuilder
    {
        private readonly FieldBuilderFactory fieldBuilderFactory;

        public ClassFieldBuilder(FieldBuilderFactory fieldBuilderFactory)
        {
            this.fieldBuilderFactory = fieldBuilderFactory;
        }

        public bool ValidForFieldType(Type type) => type.GetProperties().Any();

        public string GetField(string propertyName, Type propertyType)
        {
            string result = propertyName.ToCamelCase() + " {";

            result += propertyType
                .GetProperties()
                .Select(p => fieldBuilderFactory.GetFieldBuilder(p.PropertyType).GetField(p.Name, p.PropertyType))
                .ConcatenateStrings((str1, str2) => str1 + ", " + str2);

            result += "}";

            return result;
        }
    }
}
