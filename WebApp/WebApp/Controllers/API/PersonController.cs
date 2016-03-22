using BuildSoft.Core.Business;
using BuildSoft.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers.API
{
    public class PersonController : ApiController
    {
        [HttpGet]
        public PersonList GetPeople(uint page)
        {
            return PersonManager.GetPeople(page, 50, PersonType.Angle);
        }
    }
}
