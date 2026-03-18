using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class SuburbAverageController : Controller
{
    // 
    // GET: /SuburbAverage/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /SuburbAverage/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}