using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net.Http.Headers;
using WebAPI.DAL;
using System.Web.Http.Description;
using System.Text;
using WebAPI.Attributes;
using System.Net.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
   
    public class UsersController : ApiController
    {
        private TestEntities db = new TestEntities();

        // GET: api/Users/        
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser()
        {
            UserResponse user = null;
            HttpRequest request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic",
                        StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    string credentials = encoding.GetString(Convert.FromBase64String(authHeaderVal.Parameter));

                    int separator = credentials.IndexOf(':');
                    string name = credentials.Substring(0, separator);
                    string password = credentials.Substring(separator + 1);
                    user = db.User
                        .Include(u => u.Role)
                        .Where(u => u.UserName == name)                        
                        .Select(u => new UserResponse {
                            UserId = u.UserID,
                            UserName = u.UserName,
                            Roles = u.Role
                                     .Select(r => new RoleResponse {
                                         RoleId = r.RoleID,
                                         RoleName = r.RoleName
                                     }).ToList()
                        }).SingleOrDefault();

                    if (user == null)
                    {
                        return NotFound();
                    }
                    return Ok(user);
                }                
            }
            return NotFound();

        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserID)
            {
                return BadRequest();
            }

            db.Entry(user).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.UserID == id) > 0;
        }
    }
}