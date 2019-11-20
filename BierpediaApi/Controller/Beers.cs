using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bierpedia.Api.Mapping;
using Microsoft.AspNetCore.Routing;

namespace Bierpedia.Api.Controller {
	public class Beers : BeerpediaApiController {
		private readonly ApiContext apiContext;
		private readonly LinkGenerator linkGenerator;
		public Beers(ApiContext apiContext, LinkGenerator linkGenerator) {
			this.apiContext = apiContext;
			this.linkGenerator = linkGenerator;
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DTO.Beer>>> List() =>
			await apiContext.Beers.Take(10).ToDTO(this.Url).ToListAsync();

		[HttpGet("{slug}")]
		public async Task<ActionResult<DTO.Beer>> Get(string slug) {
			return await apiContext.Beers.Where(b => b.Slug == slug)
				.ToDTO(this.Url)
				.SingleAsync();
		}

		[HttpGet("{slug}/breweries")]
		public async Task<ActionResult<IEnumerable<DTO.Brewery>>> Breweries(string slug) =>
			 await apiContext.Beers
				.Include(beer => beer.BeerBreweries)
				.ThenInclude(bb => bb.Brewery)
				.ThenInclude(brewery => brewery.Country)
				.Where(beer => beer.Slug == slug)
				.SelectMany(beer => beer.BeerBreweries)
				.Select(bb => bb.Brewery)
				.ToDTO(this.Url)
				.ToListAsync();

		[HttpGet("{slug}/beerTypes")]
		public async Task<ActionResult<IEnumerable<DTO.BeerType>>> BeerTypes(string slug) =>
			 await apiContext.Beers
				.Include(beer => beer.BeerBeerTypes)
				.ThenInclude(bb => bb.BeerType)
				.ThenInclude(bt => bt.Parent)
				.Where(beer => beer.Slug == slug)
				.SelectMany(beer => beer.BeerBeerTypes)
				.Select(bb => bb.BeerType)
				.ToDTO(this.Url)
				.ToListAsync();
	}
}
