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
    public class TestTemplateController : ControllerBase
    {
		public TestTemplateController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: TestTemplate
		[HttpGet]
		[EnableQuery]
        public IQueryable<TestTemplate> Get()
        {
            return context.TestTemplates;
        }

        // GET: TestTemplate/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<TestTemplate> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.TestTemplates.Where(testtemplate => testtemplate.TestTemplateID == key));
        }



		// POST: TestTemplate/
        [HttpPost]
		public IActionResult Post(TestTemplate testtemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.TestTemplates.Add(testtemplate);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(testtemplate);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: TestTemplate(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, TestTemplate testtemplate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.TestTemplates.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.TestTemplates.Local.FirstOrDefault(it => it.TestTemplateID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(testtemplate).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(testtemplate);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: TestTemplate(5)
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
					TestTemplate testtemplate = context.TestTemplates.Find(key);
                    if (testtemplate == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.TestTemplates.Local.FirstOrDefault(it => it.TestTemplateID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(testtemplate).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(testtemplate);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/TestTemplate/PostRange")]
        public IActionResult PostRange(IEnumerable<TestTemplate> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.TestTemplates.AddRange(range);
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
        [Route("/api/TestTemplate/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<TestTemplate> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.TestTemplates.RemoveRange(range);
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
        [Route("/api/TestTemplate/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM TestTemplate WHERE {condition}";

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