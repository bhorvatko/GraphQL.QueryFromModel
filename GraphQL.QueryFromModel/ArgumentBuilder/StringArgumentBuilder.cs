namespace GraphQL.QueryFromModel.ArgumentBuilder
{
    internal class StringArgumentBuilder : ArgumentBuilder
    {
        public override bool ValidForType(Type type) => type == typeof(string);

        public override string GetArgumentValue(object propertyValue, Type propertyType) => $"\"{propertyValue}\"";
    }
}
