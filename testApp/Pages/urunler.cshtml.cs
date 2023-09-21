using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static testApp.Pages.IndexModel;

namespace testApp.Pages
{
    public class urunlerModel : PageModel
    {
        public List<ProductsInfo> ListProduct = new List<ProductsInfo>();
        public string errorMessage = "";
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM products";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductsInfo productsInfo = new ProductsInfo();
                                productsInfo.id = "" + reader.GetInt32(0);
                                productsInfo.title = reader.GetString(1);
                                productsInfo.description = reader.GetString(2);
                                productsInfo.ImageUrl = reader.GetString(3);
                                productsInfo.price = reader.GetInt32(4);

                                ListProduct.Add(productsInfo);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString);
            }
        }
    }
}
