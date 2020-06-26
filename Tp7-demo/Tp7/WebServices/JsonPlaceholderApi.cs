using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tp7.WebServices.Entities;

namespace Tp7.WebServices
{
    public interface JsonPlaceholderApi
    {
        [Get("/albums")]
        Task<List<Album>> GetAlbums();

        [Get("/albums/{id}")]
        Task<Album> GetAlbum(int id);

        [Post("/posts")]
        Task<Post> PostPost(Post post);//[Body]
    }
}
