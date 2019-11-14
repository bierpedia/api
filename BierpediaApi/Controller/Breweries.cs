using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bierpedia.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bierpedia.Api.Mapping;

namespace Bierpedia.Api.Controller {

	public class Breweries : BeerpediaApiController {
		private readonly ApiContext apiContext;
		public Breweries(ApiContext apiContext) {
			this.apiContext = apiContext;
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DTO.Brewery>>> Get() => 
			await apiContext.Breweries.ToDTO(this.Url).ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<DTO.Brewery>> Get(int id) {
			return await apiContext.Breweries.Where(b => b.Id == id)
				.ToDTO(this.Url).SingleAsync();
		}
	}
}
