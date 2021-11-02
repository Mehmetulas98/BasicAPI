using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Fake;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("[controller]/api")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<User> _users = FakeData.GetUsers(20);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // Üretilen listeyi döndüren GET.
        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }
        // İsim bilgisine gçre GET
        [HttpGet("{name}")]
        public User Get(string name)
        {
            var user = _users.FirstOrDefault(x => x.FirstName == name);
            return user;

        }
        // Gönderilen kısımı listeye ekleyen kısım.
        [HttpPost]
        public  User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }
        // İstenilen şeyi güncelleyen kısım.
        [HttpPut]
        public List<User> Put([FromBody] User user)
        {
            var _user = _users.FirstOrDefault(x => x.FirstName == user.FirstName);
            _user.FirstName = user.FirstName;
            _user.Surname = user.Surname;
            return _users;

        }
        // Silen Delete
        [HttpDelete]
        public List<User> Delete([FromBody] User user)
        {
            var _user = _users.FirstOrDefault(x => x.FirstName == user.FirstName);
            _users.Remove(_user);
            return _users;

        }

        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
