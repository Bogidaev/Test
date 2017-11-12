using System;
using System.Web.Http;
using Castle.Windsor;
using PetStar.Servise;

namespace PetStar.Controllers
{
    public class AlbumsController : ApiController
    {
        public IWindsorContainer Container { get; set; }

        [HttpGet]
        [Route("api/albums")]
        public IHttpActionResult GetAlbums()
        {
            var userManagerServise = this.Container.Resolve<IAlbumsServise>();
            try
            {
                return Ok(userManagerServise.GetAlbums());
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
        [Route("api/albums/{id}")]
        public IHttpActionResult GetAlbum(int id)
        {
            var userManagerServise = this.Container.Resolve<IAlbumsServise>();
            try
            {
                return Ok(userManagerServise.GetAlbum(id));
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
        [Route("api/albums/GetUserAlbums/{userId}")]
        public IHttpActionResult GetUserAlbums(int userId)
        {
            var userManagerServise = this.Container.Resolve<IAlbumsServise>();
            try
            {
                return Ok(userManagerServise.GetUserAlbums(userId));
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
