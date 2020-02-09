using Bierpedia.Api.GraphQL.Queries;
using GraphQL;
using GraphQL.Types;

namespace Bierpedia.Api.GraphQL {
	public class AppSchema : Schema {
		public AppSchema(BeerQuery beerQuery) {
				Query = beerQuery;
		}
	}
}
