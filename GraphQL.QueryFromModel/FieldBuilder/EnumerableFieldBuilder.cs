using System.Collections;

namespace GraphQL.QueryFromModel.FieldBuilder
{
    internal class EnumerableFieldBuilder : IFieldBuilder
    {
        private readonly FieldBuilderFactory fieldBuilderFactory;

        public EnumerableFieldBuilder(FieldBuilderFactory fieldBuilderFactory)
        {
            this.fieldBuilderFactory = fieldBuilderFactory;
        }

        public bool ValidForFieldType(Type type) => type.IsAssignableTo(typeof(IEnumerable));

        public string GetField(string propertyName, Type propertyType)
        {
            Type genericTypeParam = propertyType.GetGenericArguments().First();

            return fieldBuilderFactory.GetFieldBuilder(genericTypeParam).GetField(propertyName, genericTypeParam);
        }
    }
}
