using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class StudentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"
                             select StudID, StudName, StudFather, StudMother, StudEmail,StudMobile,StudCollege,RoomNo ,convert(varchar(10),DOJ,120) as DOJ from Students
                            ";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HostelAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Student stud)
        {
            try
            {
                DataTable table = new DataTable();
                //string doj = stud.DOJ.ToString().Split(' ')[0];
                string query = "insert into Students values('" + stud.StudID + "','" + stud.StudName + "','" + stud.StudFather + "','" + stud.StudMother + "','" + stud.StudEmail + "','" + stud.StudMobile + "','" + stud.StudCollege + "','" + stud.RoomNo + "','" + stud.DOJ + "')";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HostelAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception)
            {

                return "Failed to Add";
            }
        }

        public string Put(Student stud)
        {
            try
            {
                DataTable table = new DataTable();

                //string doj = stud.DOJ.ToString().Split(' ')[0];
                string query = "update Students set StudName = '" + stud.StudName + "', StudFather='" + stud.StudFather + "', StudMother='" + stud.StudMother + "', StudEmail='" + stud.StudEmail + "', StudMobile='" + stud.StudMobile + "' , StudCollege='" + stud.StudCollege + "', DOJ='" + stud.DOJ + "' where StudID = " + stud.StudID + " ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HostelAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";
            }
            catch (Exception)
            {

                return "Failed to Update";
            }
        }
        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                string query = "delete from Students where StudID = " + id + " ";
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HostelAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";
            }
            catch (Exception)
            {

                return "Failed to Delete";
            }
        }
    }
}
