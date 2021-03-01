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
    public class PatientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public PatientController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        [Route("login")]
        public JsonResult Get(Patient patient)
        {
            string query = @"select * from dbo.PatientDB where PatientId = '"
                + patient.PatientId
                + @"'and PatientDOB = '"
                + patient.PatientDOB
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
        public JsonResult Put(Patient patient)
        {
            string query = @" update dbo.PatientDB set 
                            DiagnosisSummary = '" + patient.DiagnosisSummary + @"'
                            ,RoomNumber = '" + patient.RoomNumber + @"'
                            ,BedNumber = '" + patient.BedNumber + @"'
                            ,PatientActive = " + patient.PatientActive + @"
                            ,PrescriptionPicName = '" + patient.PrescriptionPicName + @"'
                            where PatientID = " + patient.PatientId + @"
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
        public JsonResult Post(Patient patient)
        {
            string query = @" insert into dbo.PatientDB 
                            (PatientName, DiagnosisSummary, RoomNumber, BedNumber, PatientMobile, PatientDOB, AssignedDocId, AssignedDocname, PatientActive, PrescriptionPicName)
                            values
                            (
                            '" + patient.PatientName + @"'
                            ,'" + patient.DiagnosisSummary + @"'
                            ," + patient.RoomNumber + @"
                            ," + patient.BedNumber + @"
                            ,'" + patient.PatientMobile + @"
                            ,'" + patient.PatientDOB + @"'
                            ," + patient.AssignedDocId + @"
                            ,'" + patient.AssignedDocname + @"'
                            ," + patient.PatientActive + @"
                            ,'" + patient.PrescriptionPicName + @"'
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

        [Route("Prescription")]
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
        public JsonResult GetById(Patient patient)
        {
            string query = @" select * from dbo.PatientDB where PatientId = " + patient.PatientId + @"";

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

        [Route("roomnumber")]
        [HttpGet]
        public JsonResult GetByRoom(Patient patient)
        {
            string query = @" select * from dbo.PatientDB where RoomNumber = " + patient.RoomNumber + @"";

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