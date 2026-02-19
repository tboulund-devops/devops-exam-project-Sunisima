namespace Movie_Data_API.Services.DTOCollection.MoviesDTOs
{
    public class DisplayReviewDTO
    {
        public int Review_ID { get; set; }
        public int Movie_ID { get; set; }
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
