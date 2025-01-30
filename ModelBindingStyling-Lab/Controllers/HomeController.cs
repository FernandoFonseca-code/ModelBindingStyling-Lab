using Microsoft.AspNetCore.Mvc;
using ModelBindingStyling_Lab.Models;
using System.Diagnostics;

namespace ModelBindingStyling_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            IEnumerable<UserProfile> users = GetUserProfileData();
            return View(users);
        }

        public IActionResult PrinterList()
        {
            IEnumerable<ThreeDPrinters> printers = GetPrinterList();
            return View(printers);
        }

        /// <summary>
        /// Returns a list of 3d printers with test data for use
        /// on a view to practice modelbinding
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ThreeDPrinters> GetPrinterList()
        {
            return new List<ThreeDPrinters>()
            {
                new ThreeDPrinters 
                {
                    BuildVolume = "180 x 180 x 180 mm",
                    Price = 499.99,
                    SKU = "SMLPRINTER7",
                    Title = "The mini printer"
                },
                new ThreeDPrinters 
                {
                    BuildVolume = "300 x 300 x 300 mm",
                    Price = 899.99,
                    SKU = "MEDPRINTER12",
                    Title = "Mega Printer"
                },
                new ThreeDPrinters 
                {
                    BuildVolume = "360 x 360 x 360 mm",
                    Price = 999.99,
                    SKU = "MEDPRINTER12P",
                    Title = "Mega Printer Plus"
                },
                new ThreeDPrinters 
                {
                    BuildVolume = "360 x 360 x 500 mm",
                    Price = 899.99,
                    SKU = "GIGANTOR10",
                    Title = "Mega Printer"
                }
            };
        }

        /// <summary>
        /// This method returns hardcoded data for a UserProfile
        /// to use with modelbinding on a view
        /// </summary>
        private static IEnumerable<UserProfile> GetUserProfileData()
        {
            return new List<UserProfile>
            {
                new UserProfile
                {
                    DateOfBirth = new DateOnly(1815, 7, 1),
                    Email = "First.Programmer@gmail.com",
                    FullName = "Ada Lovelace",
                    GitHubUrl = "https://github.com/Octocat",
                    ImageUrl = "https://placehold.co/150",
                    PhoneNumber = "(253) 555-1234",
                    UserProfileId = 10,
                    SkilledLanguages = new List<string> { "C#", "Java", "C++" }
                },
                new UserProfile
                {
                    DateOfBirth = new DateOnly(1956, 10, 28),
                    Email = "Bill.Gates@microsoft.com",
                    FullName = "Bill Gates",
                    GitHubUrl = "https://github.com/BillGates",
                    ImageUrl = "https://placehold.co/150",
                    PhoneNumber = "(425) 555-5678",
                    UserProfileId = 20,
                    SkilledLanguages = new List<string> { "BASIC", "C", "C#" }
                },
                new UserProfile
                {
                DateOfBirth = new DateOnly(1975, 6, 28),
                Email = "Elon.Musk@tesla.com",
                FullName = "Elon Musk",
                GitHubUrl = "https://github.com/ElonMusk",
                ImageUrl = "https://placehold.co/150",
                PhoneNumber = "(310) 555-7890",
                UserProfileId = 30,
                SkilledLanguages = new List<string> { "Python", "C++", "JavaScript" }
                }
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}