/*
*
* Generated At 9/7/2020 9:10:29 AM
* Specific template for EdenClinic
*/
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EdenClinic.Models;

namespace EdenClinic.Server.Controllers
{
	[Route("[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
		public DiagnosisController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: Diagnosis
		[HttpGet]
		[EnableQuery]
        public IQueryable<Diagnosis> Get()
        {
            return context.Diagnoses;
        }

        // GET: Diagnosis/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<Diagnosis> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.Diagnoses.Where(diagnosis => diagnosis.DiagnosisID == key));
        }



		// POST: Diagnosis/
        [HttpPost]
		public IActionResult Post(Diagnosis diagnosis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.Diagnoses.Add(diagnosis);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(diagnosis);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: Diagnosis(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, Diagnosis diagnosis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.Diagnoses.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.Diagnoses.Local.FirstOrDefault(it => it.DiagnosisID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(diagnosis).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(diagnosis);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: Diagnosis(5)
        [HttpDelete]
		public IActionResult Delete([FromODataUri]Guid key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
					Diagnosis diagnosis = context.Diagnoses.Find(key);
                    if (diagnosis == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.Diagnoses.Local.FirstOrDefault(it => it.DiagnosisID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(diagnosis).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(diagnosis);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/Diagnosis/PostRange")]
        public IActionResult PostRange(IEnumerable<Diagnosis> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Diagnoses.AddRange(range);
                    context.SaveChanges();
                    transaction.Commit();
                    return Ok(range);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex);
                }
            }
        }


		[HttpPost]
        [Route("/api/Diagnosis/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<Diagnosis> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.Diagnoses.RemoveRange(range);
                    context.SaveChanges();
                    transaction.Commit();
                    return Ok(range);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex);
                }
            }
        }

        [HttpGet]
        [Route("/api/Diagnosis/Average")]
        public IEnumerable<GenericModel> Average(string caller, ODataQueryOptions value)
        {
            string column = value.RawValues.Select;
            string condition = value.RawValues.Filter == null ? "1 = 1" : value.RawValues.Filter
                .Replace("eq", "=")
                .Replace("ne", "<>")
                .Replace("gt", ">")
                .Replace("lt", "<")
                .Replace("ge", ">=")
                .Replace("le", "<=");
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM Diagnosis WHERE {condition}";

            SqlConnection connection = new SqlConnection(context.Database.GetDbConnection().ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            DataTable table = new DataTable();
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
            connection.Dispose();
            command.Dispose();
            var result = table.Rows[0]["Value"];
            return new List<GenericModel>() { new GenericModel() { Value = result.ToString() } };
        }
		#endregion
    }
}