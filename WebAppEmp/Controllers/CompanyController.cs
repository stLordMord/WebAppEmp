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
    public class CompanyController : Controller
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True";

        public ActionResult Index()
        {
            DataTable dtblCompanies = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter("SELECT * FROM Companies", sqlCon);
                sqlDA.Fill(dtblCompanies);
            }
            return View(dtblCompanies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CompanyModel());
        }

        [HttpPost]
        public ActionResult Create(CompanyModel companyModel)
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Companies VALUES(@Name, @Size, @Form)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Name", companyModel.Name);
                sqlCmd.Parameters.AddWithValue("@Size", companyModel.Size);
                sqlCmd.Parameters.AddWithValue("@Form", companyModel.Form);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CompanyModel companyModel = new CompanyModel();
            DataTable dtblCompany = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Companies WHERE CompanyId=@CompanyId";
                SqlDataAdapter sqlDA = new SqlDataAdapter(query, sqlCon);
                sqlDA.SelectCommand.Parameters.AddWithValue(@"CompanyId", id);
                sqlDA.Fill(dtblCompany);
            }
            if(dtblCompany.Rows.Count == 1)
            {
                companyModel.CompanyId = Convert.ToInt32(dtblCompany.Rows[0][0].ToString());
                companyModel.Name = dtblCompany.Rows[0][1].ToString();
                companyModel.Size = Convert.ToInt32(dtblCompany.Rows[0][2].ToString());
                companyModel.Form = dtblCompany.Rows[0][3].ToString();
                return View(companyModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(CompanyModel companyModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Companies SET Name=@Name, Size=@Size, Form=@Form WHERE CompanyId=@CompanyId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CompanyId", companyModel.CompanyId);
                sqlCmd.Parameters.AddWithValue("@Name", companyModel.Name);
                sqlCmd.Parameters.AddWithValue("@Size", companyModel.Size);
                sqlCmd.Parameters.AddWithValue("@Form", companyModel.Form);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Companies WHERE CompanyId=@CompanyId";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@CompanyId", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

    }
}
