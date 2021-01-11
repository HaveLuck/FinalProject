using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebBigBlog.Models
{
    public class TopicDBAccessLayer
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-GCS137FJ;Initial Catalog=LearnData;Integrated Security=True");
        public int AddNewTopic(TopicModel model)
        {
            int res = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("add_new_topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name_topic", model.Name_Topic);
                cmd.Parameters.AddWithValue("@description_topic", model.Description_Topic);
                 res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            catch (Exception objEx)
            {
                if (con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                throw objEx;
            }
        }   
        public List<TopicModel> GetListTopic()
        {
            List<TopicModel> lstmodel = new List<TopicModel>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Topic_Get_List_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TopicModel objStud = new TopicModel();
                            objStud.ID = Convert.ToInt32(reader["ID"]);
                            objStud.Name_Topic = Convert.ToString(reader["Name_Topic"]);
                            objStud.Description_Topic = Convert.ToString(reader["Description_Topic"]);
                            lstmodel.Add(objStud);
                        }
                    }
                }
                
                con.Close();
                return lstmodel;
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
        public int EditTopic(TopicModel model)
        {
            int res = 0;
            try
            {   
                con.Open();
                SqlCommand cmd = new SqlCommand("Topic_Edit_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.ID);
                cmd.Parameters.AddWithValue("@NameTopic", model.Name_Topic);
                cmd.Parameters.AddWithValue("@DescriptionTopic", model.Description_Topic);
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
        public TopicModel GetTopicByID(int id)
        {
            TopicModel obj = new TopicModel();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Topic_Get_Topic_By_ID", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (con)
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            obj.ID = Convert.ToInt32(reader["ID"]);
                            obj.Name_Topic = Convert.ToString(reader["Name_Topic"]);
                            obj.Description_Topic = Convert.ToString(reader["Description_Topic"]);
                        }
                    }
                }
                con.Close();
                return obj;
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
        public int DeleteTopic(int Id)
        {
            int res = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Topic_Delete_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            catch (Exception objEX)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw objEX;
            }
        }
    }
}
