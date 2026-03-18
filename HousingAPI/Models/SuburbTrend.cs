namespace HousingAPI.Models;

public class SuburbTrend
{
    public required string locality { get; set; }
    public int sale_year { get; set; }
    public double average_price { get; set; }
    public double median_price { get; set; }
    public int num_sales { get; set; }   

}
