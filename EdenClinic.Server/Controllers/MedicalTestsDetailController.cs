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
    public class MedicalTestsDetailController : ControllerBase
    {
		public MedicalTestsDetailController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: MedicalTestsDetail
		[HttpGet]
		[EnableQuery]
        public IQueryable<MedicalTestsDetail> Get()
        {
            return context.MedicalTestsDetails;
        }

        // GET: MedicalTestsDetail/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<MedicalTestsDetail> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.MedicalTestsDetails.Where(medicaltestsdetail => medicaltestsdetail.MedicalTestDetailID == key));
        }



		// POST: MedicalTestsDetail/
        [HttpPost]
		public IActionResult Post(MedicalTestsDetail medicaltestsdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalTestsDetails.Add(medicaltestsdetail);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicaltestsdetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: MedicalTestsDetail(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, MedicalTestsDetail medicaltestsdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.MedicalTestsDetails.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalTestsDetails.Local.FirstOrDefault(it => it.MedicalTestDetailID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(medicaltestsdetail).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicaltestsdetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: MedicalTestsDetail(5)
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
					MedicalTestsDetail medicaltestsdetail = context.MedicalTestsDetails.Find(key);
                    if (medicaltestsdetail == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalTestsDetails.Local.FirstOrDefault(it => it.MedicalTestDetailID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(medicaltestsdetail).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicaltestsdetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/MedicalTestsDetail/PostRange")]
        public IActionResult PostRange(IEnumerable<MedicalTestsDetail> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalTestsDetails.AddRange(range);
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
        [Route("/api/MedicalTestsDetail/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<MedicalTestsDetail> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.MedicalTestsDetails.RemoveRange(range);
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
        [Route("/api/MedicalTestsDetail/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM MedicalTestsDetail WHERE {condition}";

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