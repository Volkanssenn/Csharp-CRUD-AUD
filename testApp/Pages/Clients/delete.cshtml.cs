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
                            // Silme i�lemi ba�ar�l� oldu
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
                string id = Request.Form["id"]; // �stekten id de�erini al�n

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
                            // Silme i�lemi ba�ar�l� oldu
                            Response.Redirect("../showDb");
                        }
                        else
                        {
                            // Belirtilen ID ile e�le�en sat�r bulunamad�
                            // Uygun bir hata mesaj� g�sterebilirsiniz
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
