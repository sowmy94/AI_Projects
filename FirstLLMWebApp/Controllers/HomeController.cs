using FirstLLMWebApp.Models;
using FirstLLMWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstLLMWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly OpenAIService _openAIService;

        public HomeController()
        {
            _openAIService = new OpenAIService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ask(string userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                ViewBag.Response = "Please enter a message!";
            }
            else
            {
                string reply = await _openAIService.GetChatResponse(userMessage);
                ViewBag.Response = reply;
            }

            ViewBag.UserMessage = userMessage;
            return View("Index");
        }
    }
}
