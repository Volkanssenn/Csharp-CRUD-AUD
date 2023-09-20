using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;
using testApp.Pages.Clients;
using static testApp.Pages.IndexModel;

namespace testApp.Pages
{
    public class urun_ekleModel : PageModel
    {
        public ProductsInfo ListProduct1 = new ProductsInfo();
        public string succesMessage = "";
        public string errorMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            ListProduct1.title = Request.Form["Title"];
            ListProduct1.description = Request.Form["Description"];
            ListProduct1.ImageUrl = "images/" + Request.Form["URL"] + ".png";
            if (int.TryParse(Request.Form["price"], out int priceValue))
            {
                ListProduct1.price = priceValue;
                return;
            }
            ListProduct1.price = priceValue;
        }
    }
}
