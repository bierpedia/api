using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class BreweryType : EntityType<Brewery> {
		
		protected override void Configure(IObjectTypeDescriptor<Brewery> descriptor) {
			base.Configure(descriptor);
			descriptor.Field(b => b.CountryId).Ignore();
		}
	}
}

