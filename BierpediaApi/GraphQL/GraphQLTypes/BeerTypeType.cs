using Bierpedia.Api.Model;
using GraphQL.Types;

namespace Bierpedia.Api.GraphQL.GraphQLTypes {
	public class BeerTypeType : ObjectGraphType<Bierpedia.Api.Model.BeerType> {
		public BeerTypeType() {
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
			Field(x => x.Name).Description("Name property from the owner object.");
			Field(x => x.Slug).Description("Slug property from the owner object.");
		}
	}
}
