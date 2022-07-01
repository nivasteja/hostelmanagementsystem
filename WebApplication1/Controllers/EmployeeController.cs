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
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"
                              select EmpID, EmpName, EmpMobile, EmpEmail, EmpAge, EmpDesignation from employees
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

        public string Post(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"
                                insert into Employees values('"+emp.EmpID+"','"+emp.EmpName+"','"+emp.EmpMobile+"','"+emp.EmpEmail+"','"+emp.EmpAge+"','"+emp.EmpDesignation+"')";
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

        public string Put(Employee emp)
        {
            try
            {
                DataTable table = new DataTable();
                string query = "update Employees set EmpName = '" + emp.EmpName + "', EmpMobile='" + emp.EmpMobile + "', EmpEmail='" + emp.EmpEmail + "', EmpAge='" + emp.EmpAge + "', EmpDesignation='" + emp.EmpDesignation + "'  where EmpID = " + emp.EmpID + " ";
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

                string query = "delete from Employees where EmpID = " + id + " ";
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
