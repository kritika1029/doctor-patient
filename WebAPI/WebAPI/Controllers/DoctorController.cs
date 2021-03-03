using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using API.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public DoctorController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        //[Route("login")]
        [HttpGet("{email}/{password}")]
        public JsonResult Get(string email, string password)
        {
            string query = @" select * from dbo.DoctorDB where DocEmail = '"
                + email
                + @"'and DocPassword = '"
                + password
                + @"'";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KMNAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(Doctor doc)
        {
            string query = @" update dbo.DoctorDB set 
                            DocMobile = '" + doc.DocMobile + @"'
                            where DocId = " + doc.DocId + @"
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KMNAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Changes Made");
        }

        [HttpPost]
        public JsonResult Post(Doctor doc)
        {
            string query = @" insert into dbo.DoctorDB 
                            (DocName, DocField, DocMobile, DocEmail, DocPassword, DateOfJoinig, DocPicName)
                            values
                            (
                            '" + doc.DocName + @"'
                            ,'" + doc.DocField + @"'
                            ,'" + doc.DocMobile + @"'
                            ,'" + doc.DocEmail + @"'
                            ,'" + doc.DocPassword + @"'
                            ,'" + doc.DateOfJoining + @"'
                            ,'" + doc.DocPicName + @"'
                            )";                         

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KMNAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Succesfully");
        }

        [Route("DocPic")]
        [HttpPost]
        public JsonResult Prescription()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                //string filename = "Prescription_"++".png";
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [Route("id")]
        [HttpGet]
        public JsonResult GetById(Doctor doc)
        {
            string query = @" select * from dbo.DoctorDB where DocId = "+ doc.DocId + @"";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KMNAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [Route("field")]
        [HttpGet]
        public JsonResult GetByField(Doctor doc)
        {
            string query = @" select * from dbo.DoctorDB where DocField = '" + doc.DocField + @"'";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KMNAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [Route("fieldlist")]
        [HttpGet]
        public JsonResult GetAllField()
        {
            string query = @" select distinct DocField from dbo.DoctorDB";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("KMNAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}