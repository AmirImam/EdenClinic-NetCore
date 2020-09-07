/*
*
* Generated At 9/7/2020 9:10:31 AM
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
    public class PatientInfoController : ControllerBase
    {
		public PatientInfoController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: PatientInfo
		[HttpGet]
		[EnableQuery]
        public IQueryable<PatientInfo> Get()
        {
            return context.PatientInfoes;
        }

        // GET: PatientInfo/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<PatientInfo> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.PatientInfoes.Where(patientinfo => patientinfo.PatientInfoID == key));
        }



		// POST: PatientInfo/
        [HttpPost]
		public IActionResult Post(PatientInfo patientinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.PatientInfoes.Add(patientinfo);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(patientinfo);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: PatientInfo(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, PatientInfo patientinfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.PatientInfoes.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.PatientInfoes.Local.FirstOrDefault(it => it.PatientInfoID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(patientinfo).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(patientinfo);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: PatientInfo(5)
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
					PatientInfo patientinfo = context.PatientInfoes.Find(key);
                    if (patientinfo == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.PatientInfoes.Local.FirstOrDefault(it => it.PatientInfoID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(patientinfo).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(patientinfo);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/PatientInfo/PostRange")]
        public IActionResult PostRange(IEnumerable<PatientInfo> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.PatientInfoes.AddRange(range);
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
        [Route("/api/PatientInfo/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<PatientInfo> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.PatientInfoes.RemoveRange(range);
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
        [Route("/api/PatientInfo/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM PatientInfo WHERE {condition}";

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