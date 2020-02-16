using System;
using System.Linq;
using Bierpedia.Api.GraphQL.GraphQLTypes;
using Bierpedia.Api.Model;
using static Bierpedia.Api.GraphQL.Queries.BeersQuery;

namespace Bierpedia.Api.GraphQL.Extensions {

	public static class BeerExtensions {
		public static IOrderedQueryable<Beer> OrderBy(this IQueryable<Beer> query, OrderBy<BeerOrder> orderBy) =>
			(orderBy.Field, orderBy.Direction) switch {
				(BeerOrder.Name, Direction.ASC) => query.OrderBy(b => b.Name),
				(BeerOrder.Name, Direction.DESC) => query.OrderByDescending(b => b.Name),
				_ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(orderBy.Field)),
			};
	}
}
