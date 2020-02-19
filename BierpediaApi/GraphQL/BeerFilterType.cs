using Bierpedia.Api.Model;
using HotChocolate.Types.Filters;

namespace Bierpedia.Api.GraphQL {

	public class BeerFilterType : FilterInputType<Beer> {
		protected override void Configure(IFilterInputTypeDescriptor<Beer> descriptor) {
			descriptor.BindFieldsExplicitly()
				.Filter(t => t.Name)
				.BindFiltersExplicitly()
				.AllowContains().And()
				.AllowEquals();
		}
	}
}
