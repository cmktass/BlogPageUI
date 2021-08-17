using BlogPageMvc.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Interface
{
    public interface ITagService
    {
        Task<List<TagVM>> GetAllTags();
    }
}
