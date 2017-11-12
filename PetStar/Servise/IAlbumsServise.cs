using System.Collections.Generic;
using PetStar.Entity;

namespace PetStar.Servise
{
    public interface IAlbumsServise
    {
        List<Album> GetAlbums();

        Album GetAlbum(int id);

        List<Album> GetUserAlbums(int userid);
    }
}