using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class StyleType : EntityType<Style> {
		
		protected override void Configure(IObjectTypeDescriptor<Style> descriptor) {
			base.Configure(descriptor);
			descriptor.Field(b => b.ParentId).Ignore();
		}
	}
}

