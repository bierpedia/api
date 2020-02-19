using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class CountryType : ObjectType<Country> {
		
		protected override void Configure(IObjectTypeDescriptor<Country> descriptor) {
			descriptor.Field(b => b.Id).Ignore();
		}
	}
}

