using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace testApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public List<ProductsInfo> ListProduct = new List<ProductsInfo>();


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
                                ProductsInfo productInfo = new ProductsInfo();
                                productInfo.id = "" + reader.GetInt32(0);
                                productInfo.title = reader.GetString(1);
                                productInfo.description = reader.GetString(2);
                                productInfo.ImageUrl = reader.GetString(3);

                                ListProduct.Add(productInfo);
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

            
        }

        public class ProductsInfo
        {
            public string id;
            public string title;
            public string description;
            public string ImageUrl;
            public int price;
        }


    }
}