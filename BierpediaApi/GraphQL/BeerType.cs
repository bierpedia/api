using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class BeerType : ObjectType<Beer> {
		
		protected override void Configure(IObjectTypeDescriptor<Beer> descriptor) {
			descriptor.Field(b => b.Id).Ignore();
			descriptor.Field(b => b.BeerStyles).Ignore();
			descriptor.Field(b => b.BeerBreweries).Ignore();
			descriptor.Field("breweries").Type<NonNullType<ListType<ObjectType<Brewery>>>>().Resolver(ctx => {
				return ctx.Parent<Beer>().BeerBreweries.Select(bb => bb.Brewery);
			});
			descriptor.Field("styles").Type<NonNullType<ListType<ObjectType<Model.Style>>>>().Resolver(ctx => {
				return ctx.Parent<Beer>().BeerStyles.Select(bb => bb.Style);
			});
		}
	}
}

