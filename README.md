# GraphQL.QueryFromModel

Lets you build ready-to-use GraphQL queries by providing a model class of the response data and object containing argument values.

Supports complex and enumerable types in both the argument and query fields.

## Usage

```
public void BuildQuery()
{
	QueryBuilder queryBuilder = new QueryBuilder();

	string graphQlQuery = queryBuilder.BuildQuery<ResponseType>("myQuery", new ArgumentType() { Id = "786f664e-c470-466b-a4e7-3bd9e8bc703a" });

	// Resulting query is
	// query {
	//     myQuery(id: "786f664e-c470-466b-a4e7-3bd9e8bc703a") {
	//         name,
	//         numbers
	//     }
	// }
}

public class ResponseType
{
	public string Name { get; set; }
	public IEnumerable<int> Numbers { get; set; }
}

public class ArgumentType
{
	public string Id { get; set; }
}
```

