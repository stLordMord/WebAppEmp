using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEmp.Models;

namespace WebAppEmp.Controllers
{
    public class EmployeeController : Controller
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";

        public ActionResult Index()
        {
            DataTable dtblEmployees = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT Employees.EmployeeId, Employees.Surname, Employees.Name, Employees.Patronymic, Employees.StartDate, Employees.Post, Companies.CompanyName FROM Employees INNER JOIN Companies ON Employees.CompanyId=Companies.CompanyId", sqlCon);
                sqlDA.Fill(dtblEmployees);
            }
            return View(dtblEmployees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            string line = "";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "Select CompanyName From Companies";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader Reader = sqlCmd.ExecuteReader();
                while (Reader.Read())
                {
                    string s = Reader.GetString(0);
                    line += s + ',';
                }
                Reader.Close();
                sqlCon.Close();
            }

            ViewBag.Companies = line.Split(',').ToList();

            return View(new EmployeeModel());
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                int ComId = 0;
                sqlCon.Open();
                string query = "INSERT INTO Employees VALUES(@Surname, @Name, @Patronymic, @StartDate, @Post, @CompanyId)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Surname", employeeModel.Surname);
                sqlCmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                sqlCmd.Parameters.AddWithValue("@Patronymic", employeeModel.Patronymic);
                sqlCmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                sqlCmd.Parameters.AddWithValue("@Post", employeeModel.Post);

                string query1 = String.Format("Select CompanyId From Companies WHERE CompanyName=N'{0}'", employeeModel.CompanyId);
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                SqlDataReader Reader = sqlCmd1.ExecuteReader();
                while (Reader.Read())
                {
                    ComId = Reader.GetInt32(0);
                }
                Reader.Close();

                sqlCmd.Parameters.AddWithValue("@CompanyId", ComId);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeModel epmloyeeModel = new EmployeeModel();
            DataTable dtblEmployee = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT Employees.EmployeeId, Employees.Surname, Employees.Name, Employees.Patronymic, Employees.StartDate, Employees.Post, Companies.CompanyName  FROM Employees INNER JOIN Companies ON Employees.CompanyId=Companies.CompanyId AND EmployeeId=@EmployeeId";
                SqlDataAdapter sqlDA = new SqlDataAdapter(query, sqlCon);
                sqlDA.SelectCommand.Parameters.AddWithValue(@"EmployeeId", id);
                sqlDA.Fill(dtblEmployee);
            }
            if (dtblEmployee.Rows.Count == 1)
            {
                epmloyeeModel.EmployeeId = Convert.ToInt32(dtblEmployee.Rows[0][0].ToString());
                epmloyeeModel.Surname = dtblEmployee.Rows[0][1].ToString();
                epmloyeeModel.Name = dtblEmployee.Rows[0][2].ToString();
                epmloyeeModel.Patronymic = dtblEmployee.Rows[0][3].ToString();
                epmloyeeModel.StartDate = Convert.ToDateTime(dtblEmployee.Rows[0][4].ToString());
                epmloyeeModel.Post = dtblEmployee.Rows[0][5].ToString();
                epmloyeeModel.CompanyId = dtblEmployee.Rows[0][6].ToString();
                return View(epmloyeeModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                int ComId = 0;
                sqlCon.Open();
                string query = "UPDATE Employees SET Surname=@Surname, Name=@Name, Patronymic=@Patronymic, StartDate=@StartDate, Post=@Post, CompanyId=@CompanyId WHERE EmployeeId=@EmployeeId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@EmployeeId", employeeModel.EmployeeId);
                sqlCmd.Parameters.AddWithValue("@Surname", employeeModel.Surname);
                sqlCmd.Parameters.AddWithValue("@Name", employeeModel.Name);
                sqlCmd.Parameters.AddWithValue("@Patronymic", employeeModel.Patronymic);
                sqlCmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                sqlCmd.Parameters.AddWithValue("@Post", employeeModel.Post);

                string query1 = String.Format("Select CompanyId From Companies WHERE CompanyName=N'{0}'", employeeModel.CompanyId);
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                SqlDataReader Reader = sqlCmd1.ExecuteReader();
                while (Reader.Read())
                {
                    ComId = Reader.GetInt32(0);
                }
                Reader.Close();

                sqlCmd.Parameters.AddWithValue("@CompanyId", ComId);

                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Employees WHERE EmployeeId=@EmployeeId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@EmployeeId", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
