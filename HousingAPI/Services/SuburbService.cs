using System.Text.Json;
using HousingAPI.Models;

namespace HousingAPI.Services;

public class SuburbService
{
    private List<SuburbStats> _data;

    public SuburbService()
    {
        var json = File.ReadAllText("../data/suburb_stats.json");
        var res = JsonSerializer.Deserialize<List<SuburbStats>>(json);
        if (res == null)
        {
            throw new Exception("Failed to load suburb stats data");
        }
        _data = res;
    }

    public SuburbStats? GetByName(string name)
    {
        return _data.FirstOrDefault(
            x => x.locality.ToLower() == name.ToLower()
        );
    }
}