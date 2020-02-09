using System.Linq;
using Bierpedia.Api.Model;
using GraphQL.Types;

namespace Bierpedia.Api.GraphQL.GraphQLTypes {
	public class BeerType : ObjectGraphType<Beer> {
		public BeerType() {
			Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
			Field(x => x.Name).Description("Name property from the owner object.");
			Field(x => x.Slug).Description("Slug property from the owner object.");
			Field(name: "Breweries",
				type: typeof(ListGraphType<BreweryType>),
				resolve: context => context.Source.BeerBreweries.Select(bb => bb.Brewery));
			Field(name: "BeerTypes",
				type: typeof(ListGraphType<BeerTypeType>),
				resolve: context => context.Source.BeerBeerTypes.Select(bbt => bbt.BeerType));
		}
	}
}
