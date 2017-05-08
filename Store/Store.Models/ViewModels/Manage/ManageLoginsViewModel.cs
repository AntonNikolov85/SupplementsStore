namespace Store.Models.ViewModels.Manage
{
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using Microsoft.Owin.Security;

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }
}
