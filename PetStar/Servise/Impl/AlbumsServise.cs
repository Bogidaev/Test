using System.Collections.Generic;
using PetStar.App_Data;
using PetStar.Entity;

namespace PetStar.Servise.Impl
{
    public class AlbumsServise : IAlbumsServise
    {
        public List<Album> GetAlbums()
        {
            return ApiHelper<Album>.GetList("https://jsonplaceholder.typicode.com/albums");
        }

        public Album GetAlbum(int id)
        {
            return ApiHelper<Album>.Get("https://jsonplaceholder.typicode.com/albums?id=" + id);
        }

        public List<Album> GetUserAlbums(int userid)
        {
            return ApiHelper<Album>.GetList("https://jsonplaceholder.typicode.com/albums?userId=" + userid);
        }
    }
}