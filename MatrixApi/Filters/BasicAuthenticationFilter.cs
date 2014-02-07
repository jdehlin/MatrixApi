﻿using System.Linq;
using System.Web.Http.Controllers;
using MatrixApi.Domain;
using MatrixApi.Helpers;
using NHibernate.Linq;

namespace MatrixApi.Filters
{
    public class BasicAuthenticationFilter : BaseAuthenticationFilter
    {

        public BasicAuthenticationFilter()
        { }

        public BasicAuthenticationFilter(bool active)
            : base(active)
        { }


        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var session = NHibernateHelper.GetCurrentSession();
            var result = session.Query<User>().FirstOrDefault(u => u.Email.ToLower() == username.ToLower() && u.Password == password);
            return result != null;
        }
    }
}