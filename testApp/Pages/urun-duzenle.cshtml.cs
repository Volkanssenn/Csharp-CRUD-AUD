using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using testApp.Pages.Clients;
using static testApp.Pages.IndexModel;

namespace testApp.Pages
{
    public class urun_duzenleModel : PageModel
    {
        public string errorMessage = "";
        public string successMessage = "";
        public ProductsInfo ListProduct = new ProductsInfo();

        public void OnGet()
        {
            string id = Request.Query["urun_id"];

            try
            {
                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM products WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ListProduct.id = "" + reader.GetInt32(0);
                                ListProduct.title = reader.GetString(1);
                                ListProduct.description = reader.GetString(2);
                                ListProduct.ImageUrl = reader.GetString(3);
                                ListProduct.price = reader.GetInt32(4);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {

            ListProduct.id = Request.Form["id"];
            ListProduct.title = Request.Form["title"];
            ListProduct.description = Request.Form["description"];
            ListProduct.ImageUrl = Request.Form["URL"];
            if (int.TryParse(Request.Form["price"], out int priceValue))
            {
                ListProduct.price = priceValue;
            }
            ListProduct.price = priceValue;


            if (ListProduct.title.Length == 0 || ListProduct.description.Length == 0 ||
                ListProduct.ImageUrl.Length == 0 || ListProduct.price == 0)
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
                    string sql = "UPDATE products " +
                        "SET title=@title, description=@description, ImageUrl=@ImageUrl, price=@price " +
                        "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("title", ListProduct.title);
                        command.Parameters.AddWithValue("description", ListProduct.description);
                        command.Parameters.AddWithValue("ImageUrl", ListProduct.ImageUrl);
                        command.Parameters.AddWithValue("price", ListProduct.price);
                        command.Parameters.AddWithValue("id", ListProduct.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("urunler");

        }
    }    
}

