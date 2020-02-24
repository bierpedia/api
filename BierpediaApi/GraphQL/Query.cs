using System.Linq;
using System.Collections.Generic;
using Bierpedia.Api.Model;
using HotChocolate;
using HotChocolate.Types.Relay;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace Bierpedia.Api.GraphQL {
	public class Query {

		public IEnumerable<Beer> GetBeers([Service] ApiContext apiContext){ 
			return apiContext.Beers.Include(beer => beer.BeerBreweries)
				.ThenInclude(bb => bb.Brewery)
				.Include(beer => beer.BeerStyles)
				.ThenInclude(bt => bt.Style)
				.Include(b => b.Ratings);
		}

		public Beer GetBeer([Service] ApiContext apiContext, string slug){
			return apiContext.Beers.Where(b => b.Slug == slug).SingleOrDefault();
		}

		public IEnumerable<Brewery> GetBreweries([Service] ApiContext apiContext){ 
			return apiContext.Breweries.Include(b => b.Country);
		}
	}
}
