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
    public class DiseaseCategoryController : ControllerBase
    {
		public DiseaseCategoryController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: DiseaseCategory
		[HttpGet]
		[EnableQuery]
        public IQueryable<DiseaseCategory> Get()
        {
            return context.DiseaseCategories;
        }

        // GET: DiseaseCategory/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<DiseaseCategory> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.DiseaseCategories.Where(diseasecategory => diseasecategory.DiseaseCategoryID == key));
        }



		// POST: DiseaseCategory/
        [HttpPost]
		public IActionResult Post(DiseaseCategory diseasecategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.DiseaseCategories.Add(diseasecategory);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(diseasecategory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: DiseaseCategory(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, DiseaseCategory diseasecategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.DiseaseCategories.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.DiseaseCategories.Local.FirstOrDefault(it => it.DiseaseCategoryID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(diseasecategory).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(diseasecategory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: DiseaseCategory(5)
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
					DiseaseCategory diseasecategory = context.DiseaseCategories.Find(key);
                    if (diseasecategory == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.DiseaseCategories.Local.FirstOrDefault(it => it.DiseaseCategoryID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(diseasecategory).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(diseasecategory);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/DiseaseCategory/PostRange")]
        public IActionResult PostRange(IEnumerable<DiseaseCategory> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.DiseaseCategories.AddRange(range);
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
        [Route("/api/DiseaseCategory/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<DiseaseCategory> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.DiseaseCategories.RemoveRange(range);
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
        [Route("/api/DiseaseCategory/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM DiseaseCategory WHERE {condition}";

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