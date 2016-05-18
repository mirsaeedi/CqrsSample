using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;
using CqrsSample.Domain.Domain.Services;

namespace CqrsSample.FineBusiness.Data.Models
{
    public class InspectorService :  IInspectorService
    {
        public void IssueFine(Staff staff,Fine fine,DateTime dateTime,int cost)
        {
            var staffFine = new StaffFine(fine,staff,dateTime,cost);
            staff.AddFine(staffFine);
        }

        public bool IsIssuedFineValid(Fine fine,DateTime dateTime, int cost)
        {
            if (cost > fine.MaxCost)
                throw new Exception("");

            if (cost < fine.MinCost)
                throw new Exception("");

            return true;
        } 
    }
}