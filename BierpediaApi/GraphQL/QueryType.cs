using System.Linq;
using System.Collections.Generic;
using Bierpedia.Api.Model;
using HotChocolate;
using HotChocolate.Types.Relay;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class QueryType
		: ObjectType<Query> {

		protected override void Configure(IObjectTypeDescriptor<Query> descriptor) {
			descriptor.Field(t => t.GetBeers(default!)).Type<NonNullType<ListType<BeerType>>>()
				.UsePaging<BeerType>()
				.UseFiltering<BeerFilterType>()
				.UseSorting();

			descriptor.Field(t => t.GetBreweries(default!)).Type<NonNullType<ListType<BreweryType>>>()
				.UsePaging<BreweryType>();
		}
	}
}
