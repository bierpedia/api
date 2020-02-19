using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class BreweryType : ObjectType<Brewery> {
		
		protected override void Configure(IObjectTypeDescriptor<Brewery> descriptor) {
			descriptor.Field(b => b.Id).Ignore();
			descriptor.Field(b => b.CountryId).Ignore();
			descriptor.Field(b => b.Country).Type<NonNullType<CountryType>>();
		}
	}
}

