
namespace HotelListing.API.Controllers
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateOnly PublishedDate { get; set; }

        public Book() { 
        
        } // Parameterless constructor for deserialization
    }
}