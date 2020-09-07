/*
*
* Generated At 9/7/2020 2:41:28 PM
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
    public class SystemRoleController : ControllerBase
    {
		public SystemRoleController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }
        private ApplicationDbContext context;
        
        #region Basic Functions
        // GET: SystemRole
		[HttpGet]
		[EnableQuery]
        public IQueryable<SystemRole> Get()
        {
            return context.SystemRoles;
        }

        // GET: SystemRole/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<SystemRole> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.SystemRoles.Where(systemrole => systemrole.RoleID == key));
        }



		// POST: SystemRole/
        [HttpPost]
		public IActionResult Post(SystemRole systemrole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    context.SystemRoles.Add(systemrole);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(systemrole);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: SystemRole(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, SystemRole systemrole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.SystemRoles.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.SystemRoles.Local.FirstOrDefault(it => it.RoleID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(systemrole).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(systemrole);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: SystemRole(5)
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
					SystemRole systemrole = context.SystemRoles.Find(key);
                    if (systemrole == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.SystemRoles.Local.FirstOrDefault(it => it.RoleID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(systemrole).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(systemrole);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/SystemRole/PostRange")]
        public IActionResult PostRange(IEnumerable<SystemRole> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SystemRoles.AddRange(range);
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
        [Route("/api/SystemRole/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<SystemRole> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.SystemRoles.RemoveRange(range);
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
        [Route("/api/SystemRole/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM SystemRole WHERE {condition}";

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