namespace Bierpedia.Api.Model {
	public class Rating {
		public int Id { get; set; }

		public Beer Beer { get; set; }

		public int Grade { get; set; }
		
	}
}
