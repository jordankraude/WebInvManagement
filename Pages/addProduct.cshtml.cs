using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebInvManagement.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace WebInvManagement.Pages
{
    [Authorize]
    public class AddProductModel : PageModel
    {
        private readonly MongoDBService _mongoDBService;

        public AddProductModel(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [BindProperty]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Weight is required")]
        public double Weight { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Barcode is required")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Barcode must be a 9-digit number")]
        public long Barcode { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Retrieve form values using Request.Form
            var name = Request.Form["Name"];
            var description = Request.Form["Description"];
            var price = Request.Form["Price"];
            var quantity = Request.Form["Quantity"];
            var weight = Request.Form["Weight"];
            var barcode = Request.Form["Barcode"];

            // Validate form values (if needed)
            // For example:
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(price) || string.IsNullOrEmpty(quantity) ||
                string.IsNullOrEmpty(weight) || string.IsNullOrEmpty(barcode))
            {
                ModelState.AddModelError(string.Empty, "All fields are required.");
                return Page();
            }

            // Convert form values to appropriate data types
            if (!double.TryParse(price, out double parsedPrice) ||
                !int.TryParse(quantity, out int parsedQuantity) ||
                !double.TryParse(weight, out double parsedWeight) ||
                !long.TryParse(barcode, out long parsedBarcode))
            {
                ModelState.AddModelError(string.Empty, "Invalid input. Please check the values and try again.");
                return Page();
            }

            // Create a new instance of Product
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = parsedPrice,
                Quantity = parsedQuantity,
                Weight = parsedWeight,
                Barcode = parsedBarcode
            };

            // Access MongoDB service and insert the product into the collection
            var productCollection = _mongoDBService.GetCollection<Product>("products");
            await productCollection.InsertOneAsync(product);

            // Redirect to the view inventory page after successful insertion
            return RedirectToPage("/ViewInventory");
        }
    }
}
