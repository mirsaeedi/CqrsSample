using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.FineBusiness.Domain.Events;

namespace CqrsSample.Data.Models
{
    public class Staff:Entity
    {
        public ICollection<EmploymentHistory> EmploymentHistories { get; private set; }
        public ICollection<StaffFine> StaffFines { get; private set; }

        public string Name { get; private set; }
        
        private Staff()
        {
            StaffFines=new List<StaffFine>();
            EmploymentHistories= new List<EmploymentHistory>();
        }

        public Staff(string name,DateTime registrationDateTime):this()
        {
            Name = name;
            Events.Add(new StaffRegistred(this));

            var registrationHistory = new EmploymentHistory(this,registrationDateTime,isValid:true);
            registrationHistory.EmploymentStatusType= EmploymentStatusType.Registred;
            EmploymentHistories.Add(registrationHistory);
        }

        
        internal void AddFine(StaffFine staffFine)
        {
            StaffFines.Add(staffFine);
        }

        public void Resign(DateTime dateTime)
        {
            
        }
    }
}