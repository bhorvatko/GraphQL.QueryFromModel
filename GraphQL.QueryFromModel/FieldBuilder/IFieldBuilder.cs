namespace GraphQL.QueryFromModel.FieldBuilder
{
    public interface IFieldBuilder
    {
        bool ValidForFieldType(Type type);
        string GetField(string propertyName, Type propertyType);
    }
}
