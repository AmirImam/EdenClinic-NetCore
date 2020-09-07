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
    public class MedicalTestController : ControllerBase
    {
		public MedicalTestController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: MedicalTest
		[HttpGet]
		[EnableQuery]
        public IQueryable<MedicalTest> Get()
        {
            return context.MedicalTests;
        }

        // GET: MedicalTest/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<MedicalTest> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.MedicalTests.Where(medicaltest => medicaltest.MedicalTestID == key));
        }



		// POST: MedicalTest/
        [HttpPost]
		public IActionResult Post(MedicalTest medicaltest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalTests.Add(medicaltest);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicaltest);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: MedicalTest(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, MedicalTest medicaltest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.MedicalTests.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalTests.Local.FirstOrDefault(it => it.MedicalTestID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(medicaltest).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicaltest);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: MedicalTest(5)
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
					MedicalTest medicaltest = context.MedicalTests.Find(key);
                    if (medicaltest == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalTests.Local.FirstOrDefault(it => it.MedicalTestID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(medicaltest).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicaltest);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/MedicalTest/PostRange")]
        public IActionResult PostRange(IEnumerable<MedicalTest> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalTests.AddRange(range);
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
        [Route("/api/MedicalTest/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<MedicalTest> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.MedicalTests.RemoveRange(range);
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
        [Route("/api/MedicalTest/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM MedicalTest WHERE {condition}";

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