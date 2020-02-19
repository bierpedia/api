using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class CountryType : EntityType<Country> {
		
		protected override void Configure(IObjectTypeDescriptor<Country> descriptor) {
			
		}
	}
}

