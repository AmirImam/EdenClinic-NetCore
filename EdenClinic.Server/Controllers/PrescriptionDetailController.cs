/*
*
* Generated At 9/7/2020 9:10:32 AM
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
    public class PrescriptionDetailController : ControllerBase
    {
		public PrescriptionDetailController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: PrescriptionDetail
		[HttpGet]
		[EnableQuery]
        public IQueryable<PrescriptionDetail> Get()
        {
            return context.PrescriptionDetails;
        }

        // GET: PrescriptionDetail/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<PrescriptionDetail> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.PrescriptionDetails.Where(prescriptiondetail => prescriptiondetail.PrescriptionDetailID == key));
        }



		// POST: PrescriptionDetail/
        [HttpPost]
		public IActionResult Post(PrescriptionDetail prescriptiondetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.PrescriptionDetails.Add(prescriptiondetail);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(prescriptiondetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: PrescriptionDetail(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, PrescriptionDetail prescriptiondetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.PrescriptionDetails.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.PrescriptionDetails.Local.FirstOrDefault(it => it.PrescriptionDetailID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(prescriptiondetail).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(prescriptiondetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: PrescriptionDetail(5)
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
					PrescriptionDetail prescriptiondetail = context.PrescriptionDetails.Find(key);
                    if (prescriptiondetail == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.PrescriptionDetails.Local.FirstOrDefault(it => it.PrescriptionDetailID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(prescriptiondetail).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(prescriptiondetail);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/PrescriptionDetail/PostRange")]
        public IActionResult PostRange(IEnumerable<PrescriptionDetail> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.PrescriptionDetails.AddRange(range);
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
        [Route("/api/PrescriptionDetail/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<PrescriptionDetail> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.PrescriptionDetails.RemoveRange(range);
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
        [Route("/api/PrescriptionDetail/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM PrescriptionDetail WHERE {condition}";

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