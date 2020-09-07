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
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using StringEncryption;
using EdenClinic.Server.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace EdenClinic.Server.Controllers
{
	[Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
		public PersonController(ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager,
            UserAccountHelper userAccountHelper)
        {
            this.context = dbContext;
            this.userManager = userManager;
            this.userAccountHelper = userAccountHelper;
        }
        private ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly UserAccountHelper userAccountHelper;

        #region Basic Functions
        // GET: Person
        [HttpGet]
		[EnableQuery]
        public IQueryable<Person> Get()
        {
            return context.Persons;
        }

        // GET: Person/5
		[HttpGet]
		[EnableQuery]
        public SingleResult<Person> Get([FromODataUri]Guid key)
        {
			return SingleResult.Create(context.Persons.Where(person => person.PersonID == key));
        }



		// POST: Person/
        [HttpPost]
		public async Task<IActionResult> Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityUser user = new IdentityUser()
            {
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                UserName = person.Email
            };
            if (String.IsNullOrEmpty(person.UserPassword))
            {
                person.UserPassword = "123456";
            }
            var identityResult = await userManager.CreateAsync(user, person.UserPassword);
            if(identityResult.Succeeded == false)
            {
                return BadRequest(identityResult.Errors);
            }
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    person.UserPassword = person.UserPassword.Encrypt(user.Id);
                    person.ApplicationUserID = user.Id;
                    context.Persons.Add(person);
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(person);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }
        // PUT: Person(5)
        [HttpPut]
		public IActionResult Put([FromODataUri]Guid key, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			
			using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    if (context.Persons.Find(key) == null)
                    {
                        return NotFound();
                    }
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.Persons.Local.FirstOrDefault(it => it.PersonID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }


                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(person);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }

		
		// DELETE: Person(5)
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
					Person person = context.Persons.Find(key);
                    if (person == null)
                    {
                        return NotFound();
                    }
					
                    //context = new ApplicationDbContext(context.Options);
                    var local = context.Persons.Local.FirstOrDefault(it => it.PersonID.Equals(key));
                    if (local != null)
                    {
                       context.Entry(local).State = EntityState.Detached;
                    }
                    context.Entry(person).State = EntityState.Deleted;
                    context.SaveChanges();
                    trans.Commit();
                    return Ok(person);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return BadRequest(ex);
                }
            }

        }


		[HttpPost]
        [Route("/api/Person/PostRange")]
        public IActionResult PostRange(IEnumerable<Person> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Persons.AddRange(range);
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
        [Route("/api/Person/DeleteRange")]
        public IActionResult DeleteRange(IEnumerable<Person> range)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
					//context = new ApplicationDbContext(context.Options);
                    context.Persons.RemoveRange(range);
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
        [Route("/api/Person/Average")]
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
            string query = $"SELECT CONVERT(nvarchar(9),{caller}({column})) AS Value FROM Person WHERE {condition}";

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


        [HttpPost]
        [Route("/api/Person/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Login Failed");
                }

                var client = (await userAccountHelper.Login(model)).User;
                if (client != null)
                {
                    return Ok(client);
                }
                else
                {
                    return BadRequest("Login Failed !");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("/api/Person/CreateFirstAdmin")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFirstAdmin()
        {
            var usersCount = context.Persons.Count();
            if(usersCount > 0)
            {
                return Ok();
            }
            IdentityUser user = new IdentityUser()
            {
                PhoneNumber = "000",
                Email = "admin@eden.com",
                UserName = "admin@eden.com"
            };
            var identityResult = await userManager.CreateAsync(user, "123456");
            Person person = new Person()
            {
                ApplicationUserID=user.Id,
                BirthDate = DateTime.Parse("1/5/1983"),
                Email = "admin@eden.com",
                PersonAddress = "Eden Address",
                UserPassword = "123456",
                PersonName="Eden Admin",
                PhoneNumber="000",
                Gander = Ganders.Male,
                PersonState= UserStates.Active,
                Center = new Center()
                {
                    CenterName = "Eden",
                    CenterAddress = "Eden Address",
                    CenterPhone = "000"
                },
               
                Role = new SystemRole()
                {
                    RoleName="System Admin",
                    IsSystemAdmin = true,
                    IsAdmin = false
                }
            };

            context.Persons.Add(person);
            context.SaveChanges();
            return Ok(person);
        }
    }
}