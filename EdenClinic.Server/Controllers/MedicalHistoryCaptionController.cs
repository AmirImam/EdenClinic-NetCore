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
    public class MedicalHistoryCaptionController : ControllerBase
    {
		public MedicalHistoryCaptionController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: MedicalHistoryCaption
		[HttpGet]
		[EnableQuery]
        public IQueryable<MedicalHistoryCaption> Get()
        {
            return context.MedicalHistoryCaptions;
        }

        // GET: MedicalHistoryCaption/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<MedicalHistoryCaption> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.MedicalHistoryCaptions.Where(medicalhistorycaption => medicalhistorycaption.CaptionID == key));
        }



		// POST: MedicalHistoryCaption/
        [HttpPost]
		public IActionResult Post(MedicalHistoryCaption medicalhistorycaption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalHistoryCaptions.Add(medicalhistorycaption);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalhistorycaption);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: MedicalHistoryCaption(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, MedicalHistoryCaption medicalhistorycaption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.MedicalHistoryCaptions.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalHistoryCaptions.Local.FirstOrDefault(it => it.CaptionID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(medicalhistorycaption).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalhistorycaption);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: MedicalHistoryCaption(5)
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
					MedicalHistoryCaption medicalhistorycaption = context.MedicalHistoryCaptions.Find(key);
                    if (medicalhistorycaption == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.MedicalHistoryCaptions.Local.FirstOrDefault(it => it.CaptionID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(medicalhistorycaption).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(medicalhistorycaption);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/MedicalHistoryCaption/PostRange")]
        public IActionResult PostRange(IEnumerable<MedicalHistoryCaption> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.MedicalHistoryCaptions.AddRange(range);
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
        [Route("/api/MedicalHistoryCaption/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<MedicalHistoryCaption> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.MedicalHistoryCaptions.RemoveRange(range);
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
        [Route("/api/MedicalHistoryCaption/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM MedicalHistoryCaption WHERE {condition}";

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