namespace GraphQL.QueryFromModel.FieldBuilder
{
    internal class NullableFieldBuilder : IFieldBuilder
    {
        private readonly FieldBuilderFactory fieldBuilderFactory;

        public NullableFieldBuilder(FieldBuilderFactory fieldBuilderFactory) 
        { 
            this.fieldBuilderFactory = fieldBuilderFactory;
        }

        public bool ValidForFieldType(Type type) => Nullable.GetUnderlyingType(type) != null;

        public string GetField(string propertyName, Type propertyType)
        {
            Type genericTypeParam = propertyType.GetGenericArguments().First();

            return fieldBuilderFactory.GetFieldBuilder(genericTypeParam).GetField(propertyName, genericTypeParam);
        }
    }
}
