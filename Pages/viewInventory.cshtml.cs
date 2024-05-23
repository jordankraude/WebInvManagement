using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using System.Collections.Generic;
using WebInvManagement.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebInvManagement.Pages
{
    [Authorize]
    public class ViewInventoryModel : PageModel
    {
        private readonly MongoDBService _mongoDBService;

        public ViewInventoryModel(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
            Products = new List<Product>(); // Initialize Products list
        }

        public List<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            var productCollection = _mongoDBService.GetCollection<Product>("products");
            Products = await productCollection.Find(_ => true).ToListAsync();
        }
    }
}
