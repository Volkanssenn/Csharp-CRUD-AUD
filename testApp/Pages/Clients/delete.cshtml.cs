using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace testApp.Pages.Clients
{
    public class deleteModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public void OnGet()
        {
            string id = Request.Query["id"];

            try
            {
                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients " +
                        "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                    }
                }

            }
            catch (Exception)
            {
            }

            try
            {

                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM clients " +
                        "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id); // ID parametresini ekleyin
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Silme iþlemi baþarýlý oldu
                            Response.Redirect("../showDb");
                        }
                        else
                        {
                            Response.Redirect("../clients/create");
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            Response.Redirect("../showDb");
        }
        public void OnPost()
        {

            try
            {
                string id = Request.Form["id"]; // Ýstekten id deðerini alýn

                string connectionString = "Data Source=KAIS;Initial Catalog=testArea;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM clients " +
                        "WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id); // ID parametresini ekleyin
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Silme iþlemi baþarýlý oldu
                            Response.Redirect("../showDb");
                        }
                        else
                        {
                            // Belirtilen ID ile eþleþen satýr bulunamadý
                            // Uygun bir hata mesajý gösterebilirsiniz
                            Response.Redirect("../clients/create");
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }
            Response.Redirect("../showDb");
        }
    }
   
}
