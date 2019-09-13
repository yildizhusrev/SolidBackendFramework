using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TmTFramework.Business.Abstract;
using TmTFramework.Core.CrossCuttingConcerns.Security.Web;

namespace TmTFramework.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUsersService _userService;
        public LoginController(IUsersService userService)
        {
            _userService = userService;
        }

        public class AccountViewModel
        {
            public string email { get; set; }
            public string password { get; set; }

        }

        public HttpResponseMessage Post()
        {
           return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {

            //var user = _userService.GetByUserNameAndPassword(email, password);
            //if (user != null)
            //{
            //    AuthenticationHelper.CreateAuthCookie(
            //        user.Id, user.UserName,
            //        user.Email,
            //        DateTime.Now.AddDays(15),
            //        _userService.GetUserRoles(user),
            //        false,
            //        user.FirsName,
            //        user.LastName);
            //    return Request.CreateResponse(HttpStatusCode.OK);
            //}

            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Kullanıcı Adı Şifre Hatalı");
        }
    }
}
