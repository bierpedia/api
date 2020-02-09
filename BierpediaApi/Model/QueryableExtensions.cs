using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Bierpedia.Api.Model {
	public static class QueryableExtensions {
		public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int perPage) {
			return queryable.Skip((page-1) * perPage).Take(perPage);
		}

		public static IQueryable<Beer> OffsetPaginate(this IQueryable<Beer> queryable, int offset, int limit) {
			return queryable.Skip(offset).Take(limit);
		}

		public static IIncludableQueryable<Beer, Country> IncludeBreweries(this IQueryable<Model.Beer> queryable) {
			return queryable.Include(beer => beer.BeerBreweries)
				.ThenInclude(bb => bb.Brewery)
				.ThenInclude(brewery => brewery.Country);
		}

		public static IIncludableQueryable<Beer, BeerType> IncludeBeerTypes(this IQueryable<Model.Beer> queryable) {
			return queryable.Include(beer => beer.BeerBeerTypes)
				.ThenInclude(bbt => bbt.BeerType)
				.ThenInclude(bt => bt.Parent);
		}
	}
}
