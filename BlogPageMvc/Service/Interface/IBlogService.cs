using BlogPageMvc.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Interface
{
    public interface IBlogService
    {
        Task<List<PostVM>> GetAllPost();
        Task<PostVM> GetPostByName(string title);
        Task<List<PostVM>> GetBlogsByCategoryName(string name);
    }
}
