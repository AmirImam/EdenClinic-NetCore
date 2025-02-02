/*
*
* Generated At 9/7/2020 9:10:35 AM
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
    public class TestTemplateDetailController : ControllerBase
    {
		public TestTemplateDetailController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: TestTemplateDetail
		[HttpGet]
		[EnableQuery]
        public IQueryable<TestTemplateDetail> Get()
        {
            return context.TestTemplateDetails;
        }

        // GET: TestTemplateDetail/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<TestTemplateDetail> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.TestTemplateDetails.Where(testtemplatedetail => testtemplatedetail.TestTemplateDetailID == key));
        }



		// POST: TestTemplateDetail/
        [HttpPost]
		public IActionResult Post(TestTemplateDetail testtemplatedetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.TestTemplateDetails.Add(testtemplatedetail);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(testtemplatedetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: TestTemplateDetail(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, TestTemplateDetail testtemplatedetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.TestTemplateDetails.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.TestTemplateDetails.Local.FirstOrDefault(it => it.TestTemplateDetailID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(testtemplatedetail).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(testtemplatedetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: TestTemplateDetail(5)
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
					TestTemplateDetail testtemplatedetail = context.TestTemplateDetails.Find(key);
                    if (testtemplatedetail == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.TestTemplateDetails.Local.FirstOrDefault(it => it.TestTemplateDetailID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(testtemplatedetail).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(testtemplatedetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/TestTemplateDetail/PostRange")]
        public IActionResult PostRange(IEnumerable<TestTemplateDetail> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.TestTemplateDetails.AddRange(range);
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
        [Route("/api/TestTemplateDetail/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<TestTemplateDetail> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.TestTemplateDetails.RemoveRange(range);
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
        [Route("/api/TestTemplateDetail/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM TestTemplateDetail WHERE {condition}";

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