using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using static testApp.Pages.IndexModel;

namespace testApp.Pages
{
    public class urun_ozellikleriModel : PageModel
    {
        public ProductsInfo ListProduct2 = new ProductsInfo();
        public string successMessage = "Deðerler Hiç Dönmedi";
        public void OnGet()
        {
            string id = Request.Query["ürün_id"];
            

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
                                ListProduct2.id = "" + reader.GetInt32(0);
                                ListProduct2.title = reader.GetString(1);
                                ListProduct2.description = reader.GetString(2);
                                ListProduct2.ImageUrl = reader.GetString(3);
                                ListProduct2.price = reader.GetInt32(4);

                                successMessage = "Deðerler True Döndü";

                            }
                            else
                            {
                                successMessage = "Deðerler False Döndü";
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

        public void OnPost()
        {
            successMessage = "Deðerler POST edildi";
        }

    }
}
