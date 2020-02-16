using System.Collections.Immutable;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bierpedia.Api.GraphQL.Extensions;
using Bierpedia.Api.GraphQL.GraphQLTypes;
using Bierpedia.Api.Model;
using GraphQL.Builders;
using GraphQL.Types;
using GraphQL.Types.Relay.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace Bierpedia.Api.GraphQL.Queries {

	public class BeersQuery : ObjectGraphType {
		private const string ARGUMENT_ORDER_BY = "orderBy";
		private const string ARGUMENT_FILTER = "filter";
		public BeersQuery(ApiContext apiContext) {
			this.Connection<GraphQLTypes.BeerType>()
				.Name("beers")
				.Description("Gets pages of beers.")
				.Unidirectional()
				.Argument<OrderByType<BeerOrder>>(ARGUMENT_ORDER_BY, "Order of the results")
				.Argument<StringGraphType>(ARGUMENT_FILTER, "Filter by something")
				// Set the maximum size of a page, use .ReturnAll() to set no maximum size.
				.PageSize(10)
				.ResolveAsync(context => ResolveConnection(apiContext, context));
		}

		public enum BeerOrder {
			Name,
			Rating,
			PersonalRating,
		}

		private async static Task<object> ResolveConnection(ApiContext apiContext, ResolveConnectionContext<object> context) {
			var first = context.First.Value;

			// offset is 0 if we cannot parse context.After or it is missing
			Int32.TryParse(context.After, out int offset);
			var sortBy = context.GetArgument<OrderBy<BeerOrder>>(ARGUMENT_ORDER_BY);
			var filter = context.GetArgument<string>(ARGUMENT_FILTER);

			
			IQueryable<Beer> query = apiContext.Beers
				.IncludeBreweries()
				.IncludeBeerTypes();

			if (!string.IsNullOrEmpty(filter)) {
				query = query.Where(b => EF.Functions.ILike(b.Name, $"%{filter}%"));
			}

			var countTask = await query.CountAsync();
			var result = query.OrderBy(sortBy)
				.OffsetPaginate(offset, first)
				.ToListAsync();

			return new Connection<Beer>() {
				Edges = (await result).Select((x, index) =>
						new Edge<Beer>() {
							Cursor = ToCursor(offset + index),
							Node = x
						})
					.ToList(),
				PageInfo = new PageInfo() {
					HasNextPage = offset < countTask,
					HasPreviousPage = offset > 0,
					StartCursor = ToCursor(offset),
					EndCursor = ToCursor(offset + context.PageSize.Value),
				},
				TotalCount = countTask,
			};
		}

		// We cannot really use actual cursor based pagination here. The reason is, that BeerQuerys have multiple possible sort and filter arguments and
		// we would need for aech of those a unique sequential column. Especially when sorting by rating this isimpossible to achieve.
		// However offset based pagination should not be a problem since beers do not get addded that often.
		public static string ToCursor(int offset) {
			return offset.ToString();
		}
	}
}
