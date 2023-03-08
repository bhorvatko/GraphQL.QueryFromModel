namespace GraphQL.QueryFromModel.ArgumentBuilder
{
    internal class PrimitiveArgumentBuilder : ArgumentBuilder
    {
        public override bool ValidForType(Type type) => type == typeof(int) || type == typeof(bool);

        public override string GetArgumentValue(object propertyValue, Type propertyType) => $"{propertyValue.ToString()!.ToLower()}";
    }
}
