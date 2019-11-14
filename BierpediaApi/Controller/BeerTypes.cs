using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bierpedia.Api.Mapping;

namespace Bierpedia.Api.Controller {

	public class BeerTypes : BeerpediaApiController {
		private readonly ApiContext apiContext;
		public BeerTypes(ApiContext apiContext) {
			this.apiContext = apiContext;
		}
		
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DTO.BeerType>>> Get() => 
			await apiContext.BeerTypes.ToDTO(this.Url).ToListAsync();

		[HttpGet("{id}")]
		public async Task<ActionResult<DTO.BeerType>> Get(int id) {
			return await apiContext.BeerTypes.Where(b => b.Id == id)
				.ToDTO(this.Url).SingleAsync();
		}
	}
}
