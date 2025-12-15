namespace MovieHub.Models.Series
{
    public class SeriesDetail
    {
     public int Id { get; set; }    

     public string Description { get; set; }    
     
     public int SeriesId { get; set; }  

     public TvSeries TvSeries { get; set; }   


    }
}
