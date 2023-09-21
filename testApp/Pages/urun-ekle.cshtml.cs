using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
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
            }
            ListProduct1.price = priceValue;

            if (ListProduct1.title.Length == 0 || ListProduct1.description.Length == 0 ||
                ListProduct1.ImageUrl.Length == 0 || ListProduct1.price == 0)
            {
                errorMessage = "Bütün alanlarýn doldurulmasý gerekiyor.";
                return;
            }

            try
            {
                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO [dbo].[products] " +
                        "([title], [description], [ImageUrl], [price]) VALUES " +
                        "(@title, @description, @ImageUrl, @price)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@title", ListProduct1.title);
                        command.Parameters.AddWithValue("@description", ListProduct1.description);
                        command.Parameters.AddWithValue("@ImageUrl", ListProduct1.ImageUrl);
                        command.Parameters.AddWithValue("@price", ListProduct1.price);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            succesMessage = "Yeni Sipariþ Eklendi";

            
        }
    }
}
