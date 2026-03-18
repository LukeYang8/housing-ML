namespace HousingAPI.Models;

public class SuburbStats
{
    public required string locality { get; set; }
    public double avg_price { get; set; }
    public double median_price { get; set; }
    public int num_sales { get; set; }   

}
