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
    public class DoctorSettingController : ControllerBase
    {
		public DoctorSettingController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: DoctorSetting
		[HttpGet]
		[EnableQuery]
        public IQueryable<DoctorSetting> Get()
        {
            return context.DoctorSettings;
        }

        // GET: DoctorSetting/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<DoctorSetting> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.DoctorSettings.Where(doctorsetting => doctorsetting.DoctorSettingID == key));
        }



		// POST: DoctorSetting/
        [HttpPost]
		public IActionResult Post(DoctorSetting doctorsetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.DoctorSettings.Add(doctorsetting);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(doctorsetting);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: DoctorSetting(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, DoctorSetting doctorsetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.DoctorSettings.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.DoctorSettings.Local.FirstOrDefault(it => it.DoctorSettingID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(doctorsetting).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(doctorsetting);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: DoctorSetting(5)
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
					DoctorSetting doctorsetting = context.DoctorSettings.Find(key);
                    if (doctorsetting == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.DoctorSettings.Local.FirstOrDefault(it => it.DoctorSettingID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(doctorsetting).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(doctorsetting);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/DoctorSetting/PostRange")]
        public IActionResult PostRange(IEnumerable<DoctorSetting> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.DoctorSettings.AddRange(range);
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
        [Route("/api/DoctorSetting/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<DoctorSetting> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.DoctorSettings.RemoveRange(range);
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
        [Route("/api/DoctorSetting/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM DoctorSetting WHERE {condition}";

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