using Microsoft.ML.Data;

namespace HousingAPI.Models;

public class ModelInput
{
    [LoadColumn(0)] 
    public float land_area { get; set; }
    [LoadColumn(1)] 
    public float sale_year { get; set; }
    [LoadColumn(2)] 
    public float num_bath { get; set; }
    [LoadColumn(3)] 
    public float num_bed { get; set; }
    [LoadColumn(4)] 
    public float num_parking { get; set; }
    [LoadColumn(5)] 
    public float km_from_cbd { get; set; }
    [LoadColumn(6)] 
    public float suburb_median_income { get; set; }
    [LoadColumn(7)] 
    public float cash_rate { get; set; }
    [LoadColumn(8)] 
    [ColumnName("Label")]
    public float purchase_price { get; set; }
}
