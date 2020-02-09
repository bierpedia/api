using Bierpedia.Api.Model;
using GraphQL.Types;

namespace Bierpedia.Api.GraphQL.GraphQLTypes {
	public class BreweryType : ObjectGraphType<Brewery> {
		public BreweryType() {
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
			Field(x => x.Name).Description("Name property from the owner object.");
			Field(x => x.Slug).Description("Slug property from the owner object.");
		}
	}
}
