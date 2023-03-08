using GraphQL.QueryFromModel.Extensions;

namespace GraphQL.QueryFromModel.ArgumentBuilder
{
    public abstract class ArgumentBuilder
    {
        public abstract bool ValidForType(Type type);

        public abstract string GetArgumentValue(object propertyValue, Type propertyType);

        public string GetArgumentString(object propertyValue, string propertyName, Type propertyType)
            => $"{propertyName.ToCamelCase()}: {GetArgumentValue(propertyValue, propertyType)}";
    }
}
