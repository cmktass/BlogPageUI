using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.ViewComponents
{
    public class TagVC:ViewComponent
    {
        private readonly ITagService _tagService;
        public TagVC(ITagService tagService)
        {
            this._tagService = tagService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _tagService.GetAllTags());
        }
    }
}
