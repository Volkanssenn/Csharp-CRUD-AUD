using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace testApp.Pages
{
    public class urun_silModel : PageModel
    {
        public string errorMessage = "";
        public void OnGet()
        {
            string id = Request.Query["urun_id"];

            try
            {
                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM products " +
                        "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            try
            {

                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM products " +
                        "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id); // ID parametresini ekleyin
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Silme iþlemi baþarýlý oldu
                            Response.Redirect("urunler");
                        }
                        else
                        {
                            Response.Redirect("urun-ekle");
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void OnPost()
        {

        }
    }
}
