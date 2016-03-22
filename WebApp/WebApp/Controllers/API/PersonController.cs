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
        public PersonListResult GetPeople(uint page, PersonType personType)
        {
            return PersonManager.GetPeople(page, 12, personType);
        }

        [HttpGet]
        public Dictionary<PersonType,int> GetConsolidatedData()
        {
            return PersonManager.GetConsolidatedData();
        }

        [HttpPost]
        public void AddOneYear()
        {
            PersonManager.AddYear(1);
        }

        [HttpPost]
        public void Restart()
        {
            PersonManager.Restart();
        }
    }
}
