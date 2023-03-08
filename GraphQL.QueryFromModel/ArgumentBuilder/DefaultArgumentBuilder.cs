namespace GraphQL.QueryFromModel.ArgumentBuilder
{
    internal class DefaultArgumentBuilder : ArgumentBuilder
    {
        public override bool ValidForType(Type type) => true;

        public override string GetArgumentValue(object propertyValue, Type propertyType) => $"\"{propertyValue}\"";
    }
}
