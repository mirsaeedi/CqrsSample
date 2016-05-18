using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace CqrsSample.Data.Models
{
    public class StaffFine:Entity
    {
        public StaffFine(Fine fine,Staff staff, DateTime dateTime, int cost)
        {

            if(cost<0)
                throw new Exception("Invalid Cost");

            FineId = fine.Id;
            StaffId = staff.Id;
            Cost = cost;
            DateTime = dateTime;
        }

        public long FineId { get; private set; }

        public long StaffId { get; private set; }

        public int Cost { get; private set; }

        public DateTime DateTime { get; private set; }

        public bool IsValid { get; private set; }

        public void ChangeCost(int cost)
        {
            Cost = cost;
        }

        public void ChangeValidation(bool isValid)
        {
            IsValid = isValid;
        }
    }
}