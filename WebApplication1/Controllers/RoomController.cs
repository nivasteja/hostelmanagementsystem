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
    public class RoomController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query =  @"
                            select RoomNo, RoomActivity, RoomStatus from dbo.Rooms
                            ";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HostelAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(Room rm)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
                                insert into Rooms values('" + rm.RoomNo + "','" + rm.RoomActivity + "','" + rm.RoomStatus + "')";
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

        public string Put(Room rm)
        {
            try
            {
                DataTable table = new DataTable();
                string query = "update Rooms set RoomActivity = '" + rm.RoomActivity + "', RoomStatus='" + rm.RoomStatus + "' where RoomNo = " + rm.RoomNo + " ";
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

                string query = "delete from Rooms where RoomNo = "+id+" ";
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
