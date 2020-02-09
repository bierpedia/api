using GraphQL.Types;

namespace Bierpedia.Api.GraphQL.GraphQLTypes {

	public enum Direction {
		ASC,
		DESC
	}

	public class OrderBy<T> where T : System.Enum {

		public T Field { get; set; }
		public Direction Direction { get; set; }
	}

	public class OrderByType<T> : InputObjectGraphType<OrderBy<T>> where T : System.Enum {

		public OrderByType() {
			Field<EnumerationGraphType<T>>().Name("Field");
			Field<EnumerationGraphType<Direction>>().Name("Direction");
		}
	}
}
