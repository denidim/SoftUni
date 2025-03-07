﻿using BasicWebServer.Demo.Models;
using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controller;
using BasicWebServer.Server.HTTP;
using System.Linq;
using System.Text;
using System.Web;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string FileName = "content.txt";

        public HomeController(Request request) : base(request)
        {
                
        }

        [HttpGet]
        public Response Index() => Text("Hello from the server!");

        public Response Student(string name, int age) => Text($"I'm {name} and I'm {age} years old");

        public Response Redirect() => Redirect("https://softuni.org");

        public Response Html() => View();

        [HttpPost]
        public Response HtmlFormPost()
        {
            var name = this.Request.Form["Name"];
            var age = this.Request.Form["Age"];

            var model = new FormViewModel()
            {
                Name = name,
                Age = int.Parse(age)
            };

            return View(model);
        }

        public Response Content() => View();

        public Response DownloadContent() => File(FileName);

        public Response Cookies()
        {
            if (this.Request.Cookies.Any(c => c.Name != BasicWebServer.Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table");
                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            var bodyText = "";

            var sessionExists = Request.Session.ContainsKey(Server.HTTP.Session.SessionCurrentDateKey);

            if (sessionExists)
            {
                var currentDate = Request.Session[Server.HTTP.Session.SessionCurrentDateKey];
                bodyText = $"stored date: {currentDate}!";
            }
            else
            {
                bodyText = "Current date stored!";
            }

            return Text(bodyText);
        }
    }
}
