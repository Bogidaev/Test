using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.Windsor;
using Newtonsoft.Json;
using PetStar.Entity;
using PetStar.Servise;

namespace PetStar.Controllers
{
    public class UserController : ApiController
    {
        public IWindsorContainer Container { get; set; }

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            var userManagerServise = this.Container.Resolve<IUsersServise>();
            try
            {
                return Ok(userManagerServise.GetUsers());
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            finally
            {
                this.Container.Release(userManagerServise);
            }
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            var userManagerServise = this.Container.Resolve<IUsersServise>();
            try
            {
                return Ok(userManagerServise.GetUser(id));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
            finally
            {
                this.Container.Release(userManagerServise);
            }
        }
    }
}
