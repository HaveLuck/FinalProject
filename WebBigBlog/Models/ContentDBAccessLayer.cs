using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebBigBlog.Models
{
    public class ContentDBAccessLayer
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GCS137FJ;Initial Catalog=LearnData;Integrated Security=True");
        public int AddNewContent(ContentModel model)
        {
            int res = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Content_Add_News", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Author", model.AuthorID);
                cmd.Parameters.AddWithValue("@Content", model.Content);
                cmd.Parameters.AddWithValue("@Tittle", model.Tittle);
                cmd.Parameters.AddWithValue("@TopicID", model.Topic_ID);
                res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            catch (Exception objEx)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw objEx;
            }
        }
        public ContentModel GetAnPost(int id)
        {
            ContentModel obj = new ContentModel();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Content_Get_Post", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        obj.Tittle = Convert.ToString(reader["Tittle"]);
                        obj.Content = Convert.ToString(reader["Content"]);
                    }
                }
                return obj;
            }
            catch (Exception objEx)
            {

                throw objEx;
            }
        }
    }
}
