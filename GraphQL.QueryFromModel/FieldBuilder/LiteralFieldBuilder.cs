using GraphQL.QueryFromModel.Extensions;

namespace GraphQL.QueryFromModel.FieldBuilder
{
    internal class LiteralFieldBuilder : IFieldBuilder
    {
        public bool ValidForFieldType(Type type) 
            => type == typeof(string) || type == typeof(int) || type == typeof(DateTime) || type == typeof(bool);

        public string GetField(string propertyName, Type propertyType) => propertyName.ToCamelCase();
    }
}
