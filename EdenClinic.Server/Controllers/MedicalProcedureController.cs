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
    public class MedicalProcedureController : ControllerBase
    {
		public MedicalProcedureController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: MedicalProcedure
		[HttpGet]
		[EnableQuery]
        public IQueryable<MedicalProcedure> Get()
        {
            return context.MedicalProcedures;
        }

        // GET: MedicalProcedure/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<MedicalProcedure> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.MedicalProcedures.Where(medicalprocedure => medicalprocedure.MedicalProcedureID == key));
        }



		// POST: MedicalProcedure/
        [HttpPost]
		public IActionResult Post(MedicalProcedure medicalprocedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalProcedures.Add(medicalprocedure);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalprocedure);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: MedicalProcedure(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, MedicalProcedure medicalprocedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.MedicalProcedures.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalProcedures.Local.FirstOrDefault(it => it.MedicalProcedureID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(medicalprocedure).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalprocedure);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: MedicalProcedure(5)
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
					MedicalProcedure medicalprocedure = context.MedicalProcedures.Find(key);
                    if (medicalprocedure == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalProcedures.Local.FirstOrDefault(it => it.MedicalProcedureID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(medicalprocedure).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalprocedure);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/MedicalProcedure/PostRange")]
        public IActionResult PostRange(IEnumerable<MedicalProcedure> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalProcedures.AddRange(range);
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
        [Route("/api/MedicalProcedure/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<MedicalProcedure> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.MedicalProcedures.RemoveRange(range);
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
        [Route("/api/MedicalProcedure/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM MedicalProcedure WHERE {condition}";

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