using System.Linq;
using Bierpedia.Api.Model;
using HotChocolate.Types;

namespace Bierpedia.Api.GraphQL {
	public class EntityType<T> : ObjectType<T> where T : Entity {
		
		protected override void Configure(IObjectTypeDescriptor<T> descriptor) {
			descriptor.Field(e => e.Description).Description("The description of the entity. Can contain html.");
			descriptor.Field(e => e.Slug).Type<IdType>().Description("The slug and ID of this entity.");
			descriptor.Field(e => e.Name).Description("The name of this entity.");
		}
	}
}

