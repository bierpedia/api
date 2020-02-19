using System;
using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class BeerType : EntityType<Beer> {
		
		protected override void Configure(IObjectTypeDescriptor<Beer> descriptor) {
			base.Configure(descriptor);
			descriptor.Field(b => b.BeerStyles).Ignore();
			descriptor.Field(b => b.BeerBreweries).Ignore();
			descriptor.Field("breweries").Type<NonNullType<ListType<NonNullType<BreweryType>>>>().Resolver(ctx => {
				return ctx.Parent<Beer>().BeerBreweries.Select(bb => bb.Brewery);
			});
			descriptor.Field("styles").Type<NonNullType<ListType<NonNullType<StyleType>>>>().Resolver(ctx => {
				return ctx.Parent<Beer>().BeerStyles.Select(bb => bb.Style);
			});
		}
	}
}

