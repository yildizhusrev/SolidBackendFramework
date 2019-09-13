using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmTFramework.Core.Aspects.Postsharp.AuthoritationAspects
{
    [Serializable]
    public class SecuredOperation : OnMethodBoundaryAspect
    {

        public string Roles { set; get; } = string.Empty;
        public override void OnEntry(MethodExecutionArgs args)
        {
           //if(!System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
           //    throw new Exception("You are Not Authorized");

            bool isAuthorized = false;
            string[]  roles = Roles.Split(',');
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole("Admin"))
                {
                    isAuthorized = true;
                }

            }

            if (!isAuthorized)
            {
                throw new Exception("You are Not Authorized");
            }
        }
    }
}
