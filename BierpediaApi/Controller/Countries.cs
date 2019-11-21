using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bierpedia.Api.Mapping;

namespace Bierpedia.Api.Controller {

	public class Countries : BeerpediaApiController {
		private readonly ApiContext apiContext;
		public Countries(ApiContext apiContext) {
			this.apiContext = apiContext;
		}
		
		[HttpGet]
		public async Task<ActionResult<IList<DTO.Country>>> Get() {
			return await apiContext.Countries.ToDTO(this.Url).ToListAsync();
		}


		[HttpGet("{slug}")]
		public async Task<ActionResult<DTO.Country>> Get(string slug) {
			return await apiContext.Countries.Where(country => country.Slug == slug)
				.ToDTO(this.Url).SingleAsync();
		}
	}
}
