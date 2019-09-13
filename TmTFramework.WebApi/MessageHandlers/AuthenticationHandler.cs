using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TmTFramework.Business.Abstract;
using TmTFramework.Business.DependencyResolvers.Ninject;
using TmTFramework.Entities.Concrete;

namespace TmTFramework.WebApi.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodeString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodeString.Split(':');

                    IUsersService userService = InstanceFactory.GetInstance<IUsersService>();
                    User user = userService.GetByUserNameAndPassword(
                        tokenValues[0],
                        tokenValues[1]
                        );
                    if (user!=null)
                    {
                        IPrincipal principal = new GenericPrincipal(
                            new GenericIdentity(tokenValues[0]),
                            userService.GetUserRoles(user).ToArray()
                            );
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}