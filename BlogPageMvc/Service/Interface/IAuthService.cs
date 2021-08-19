using BlogPageMvc.Models;
using BlogPageMvc.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Interface
{
    public interface IAuthService
    {
        Task<GenericResponse<string>> SignIn(UserSignInVM user);
    }
}
