/*
*
* Generated At 9/7/2020 9:10:30 AM
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
    public class MedicalHistoryController : ControllerBase
    {
		public MedicalHistoryController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: MedicalHistory
		[HttpGet]
		[EnableQuery]
        public IQueryable<MedicalHistory> Get()
        {
            return context.MedicalHistories;
        }

        // GET: MedicalHistory/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<MedicalHistory> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.MedicalHistories.Where(medicalhistory => medicalhistory.MedicalHistoryID == key));
        }



		// POST: MedicalHistory/
        [HttpPost]
		public IActionResult Post(MedicalHistory medicalhistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalHistories.Add(medicalhistory);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalhistory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: MedicalHistory(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, MedicalHistory medicalhistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.MedicalHistories.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalHistories.Local.FirstOrDefault(it => it.MedicalHistoryID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(medicalhistory).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalhistory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: MedicalHistory(5)
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
					MedicalHistory medicalhistory = context.MedicalHistories.Find(key);
                    if (medicalhistory == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalHistories.Local.FirstOrDefault(it => it.MedicalHistoryID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(medicalhistory).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalhistory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/MedicalHistory/PostRange")]
        public IActionResult PostRange(IEnumerable<MedicalHistory> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalHistories.AddRange(range);
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
        [Route("/api/MedicalHistory/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<MedicalHistory> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.MedicalHistories.RemoveRange(range);
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
        [Route("/api/MedicalHistory/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM MedicalHistory WHERE {condition}";

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