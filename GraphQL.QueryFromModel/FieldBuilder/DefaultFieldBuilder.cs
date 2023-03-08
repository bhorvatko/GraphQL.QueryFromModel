using GraphQL.QueryFromModel.Extensions;

namespace GraphQL.QueryFromModel.FieldBuilder
{
    internal class DefaultFieldBuilder : IFieldBuilder
    {
        public bool ValidForFieldType(Type type) => true;

        public string GetField(string propertyName, Type propertyType) => propertyName.ToCamelCase();
    }
}
