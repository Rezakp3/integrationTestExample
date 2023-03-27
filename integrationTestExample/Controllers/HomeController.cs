using integrationTestExample.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace integrationTestExample.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product {
                Id = 1,
                Name = "Test 1",
                Description = "Test 1",
                Category = "Test 1",
                Price = 1000,
            },
            new Product {
                Id = 2,
                Name = "Test 2",
                Description = "Test 2",
                Category = "Test 2",
                Price = 2000,
            },
            new Product {
                Id = 3,
                Name = "Test 3",
                Description = "Test 3",
                Category = "Test 3",
                Price = 3000,
            },
            new Product {
                Id = 4,
                Name = "Test 4",
                Description = "Test 4",
                Category = "Test 4",
                Price = 4000,
            },
            new Product {
                Id = 5,
                Name = "Test 5",
                Description = "Test 5",
                Category = "Test 5",
                Price = 5000,
            }
        };

        [HttpGet]
        [ProducesResponseType(type: typeof(ObjectResult), statusCode: 200)]
        public async Task<IActionResult> GetAll()
        {
            CookieContainer a = new CookieContainer();
            var b = a.GetCookieHeader(new Uri("http://localhost/Home/GetAll"));
            var res = new StandardResult<List<Product>>
            {
                Message = "OK",
                Result = products,
                StatusCode = 302,
                Success = true
            };

            return StatusCode(res.StatusCode, res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(type: typeof(ObjectResult), statusCode: 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var res = new StandardResult<Product>
            {
                Message = "OK",
                Result = products.FirstOrDefault(x => x.Id == id),
                StatusCode = 302,
                Success = true
            };

            return StatusCode(res.StatusCode, res);
        }
    }
}
