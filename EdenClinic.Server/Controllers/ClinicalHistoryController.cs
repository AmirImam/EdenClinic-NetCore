/*
*
* Generated At 9/7/2020 9:10:28 AM
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
    public class ClinicalHistoryController : ControllerBase
    {
		public ClinicalHistoryController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: ClinicalHistory
		[HttpGet]
		[EnableQuery]
        public IQueryable<ClinicalHistory> Get()
        {
            return context.ClinicalHistories;
        }

        // GET: ClinicalHistory/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<ClinicalHistory> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.ClinicalHistories.Where(clinicalhistory => clinicalhistory.ClinicalHistoryID == key));
        }



		// POST: ClinicalHistory/
        [HttpPost]
		public IActionResult Post(ClinicalHistory clinicalhistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.ClinicalHistories.Add(clinicalhistory);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(clinicalhistory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: ClinicalHistory(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, ClinicalHistory clinicalhistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.ClinicalHistories.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.ClinicalHistories.Local.FirstOrDefault(it => it.ClinicalHistoryID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(clinicalhistory).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(clinicalhistory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: ClinicalHistory(5)
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
					ClinicalHistory clinicalhistory = context.ClinicalHistories.Find(key);
                    if (clinicalhistory == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.ClinicalHistories.Local.FirstOrDefault(it => it.ClinicalHistoryID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(clinicalhistory).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(clinicalhistory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/ClinicalHistory/PostRange")]
        public IActionResult PostRange(IEnumerable<ClinicalHistory> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.ClinicalHistories.AddRange(range);
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
        [Route("/api/ClinicalHistory/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<ClinicalHistory> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.ClinicalHistories.RemoveRange(range);
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
        [Route("/api/ClinicalHistory/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM ClinicalHistory WHERE {condition}";

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