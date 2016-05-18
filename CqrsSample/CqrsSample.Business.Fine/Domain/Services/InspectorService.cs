using System;
using CqrsSample.Business.Fine.Data.Models;

namespace CqrsSample.Business.Fine.Domain.Services
{
    public class InspectorService :  IInspectorService
    {
        public void IssueFine(Staff staff,Data.Models.Fine fine,DateTime dateTime,int cost)
        {
            var staffFine = new StaffFine(fine,staff,dateTime,cost);
            staff.AddFine(staffFine);
        }

        public bool IsIssuedFineValid(Data.Models.Fine fine,DateTime dateTime, int cost)
        {
            if (cost > fine.MaxCost)
                throw new Exception("");

            if (cost < fine.MinCost)
                throw new Exception("");

            return true;
        } 
    }
}