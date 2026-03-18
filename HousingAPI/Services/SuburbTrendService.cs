using System.Text.Json;
using HousingAPI.Models;

namespace HousingAPI.Services;

public class SuburbTrendService
{
    private List<SuburbTrend> _data;

    public SuburbTrendService()
    {
        var json = File.ReadAllText("../data/suburb_trends.json");
        var res = JsonSerializer.Deserialize<List<SuburbTrend>>(json);
        if (res == null)
        {
            throw new Exception("Failed to load suburb trends data");
        }
        _data = res;
    }

    public List<SuburbTrend> GetByName(string name)
    {
        var res = _data.Where(x => x.locality.ToLower() == name.ToLower()).ToList();
        return res;
    }


    public List<SuburbTrend> GetByNameAndYear(string name, int year)
    {
        var res = _data.Where(x => x.locality.ToLower() == name.ToLower() && x.sale_year == year).ToList();
        return res;
    }

}