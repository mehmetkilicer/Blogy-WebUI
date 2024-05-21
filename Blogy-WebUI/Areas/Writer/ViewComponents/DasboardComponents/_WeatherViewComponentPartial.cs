using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Security.Policy;
using Blogy_WebUI.Areas.Writer.Models;

namespace Blogy_WebUI.Areas.Writer.ViewComponents.DasboardComponents
{
    public class _WeatherViewComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/forecast.json?q=%C4%B0stanbul&days=7"),
                Headers =
    {
        { "X-RapidAPI-Key", "446818c186mshe0aae32f305d125p1f4bc6jsn6f0a5bd24c48" },
        { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeaherViewModel>(body);
                return View(values);
            }
        }
    }
}
