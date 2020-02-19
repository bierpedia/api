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
			descriptor.Field(b => b.Ratings).Ignore();
			descriptor.Field("breweries").Type<NonNullType<ListType<NonNullType<BreweryType>>>>().Resolver(ctx => {
				return ctx.Parent<Beer>().BeerBreweries.Select(bb => bb.Brewery);
			});
			descriptor.Field("styles").Type<NonNullType<ListType<NonNullType<StyleType>>>>().Resolver(ctx => {
				return ctx.Parent<Beer>().BeerStyles.Select(bb => bb.Style);
			});
			descriptor.Field(b => b.AverageGrade).Type<NonNullType<DecimalType>>().Resolver( (ctx) => 
				Math.Round(Convert.ToDecimal(ctx.Parent<Beer>().AverageGrade), 2));
			descriptor.Field("ratingCount").Type<NonNullType<IntType>>().Resolver( (ctx) =>
				ctx.Parent<Beer>().Ratings.Count);
		}
	}
}

