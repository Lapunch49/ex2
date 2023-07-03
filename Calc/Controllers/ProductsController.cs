using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Calc.Models;

namespace Calc.Controllers1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>(new[]
        {
            new Product(){Id=1,Name="Notebook", Price=100000},
            new Product(){Id=2,Name="Car", Price=2000000},
            new Product(){Id=3,Name="Apple",Price=30},
        });
        [HttpGet]
        public IEnumerable<Product> Get() => products;

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // 404 error
            }
            return Ok(product); // возвращает json-файл с инф-ей о товаре (сериализуем товар в json)
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            products.Remove(products.SingleOrDefault(p => p.Id == id));
            return Ok(new { Message = "Deleted successfully" }); // анонимный объект
        }
        private int NextProductId =>
            products.Count() == 0 ? 1 : products.Max(p => p.Id) + 1;
        [HttpGet("GetNextProduct")]
        public int GetNextProductId() // неважно IActionResult или string, т.к. все равно идет сериализация в строку
        {
            return NextProductId;
        }
        [HttpPost]
        public IActionResult Post(Product product) // товар берется из полей формы (д.б. параметры Name,Price)
        {
            if (!ModelState.IsValid) // валидация товара согласно модели (есть Name, Price)
            {
                return BadRequest(ModelState);
            }
            product.Id = NextProductId;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
        [HttpPost("AddProdust")]
        public IActionResult PostBody([FromBody] Product product) => // товар берется из json-файла (десериализуется в объект Product)
            Post(product);
        [HttpPut]
        public IActionResult Put(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var storedProduct = products.SingleOrDefault(p => p.Id == product.Id);
            if (storedProduct == null)
                return NotFound();
            storedProduct.Name = product.Name;
            storedProduct.Price = product.Price;
            return Ok(storedProduct);
        }
        [HttpPut("UpdateProduct")]
        public IActionResult PutBody([FromBody] Product product) => // товар берется из json-файла (десериализуется в объект Product)
            Put(product);


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
