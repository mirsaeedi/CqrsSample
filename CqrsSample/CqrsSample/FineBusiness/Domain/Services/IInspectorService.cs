using System;
using CqrsSample.Data.Models;

namespace CqrsSample.FineBusiness.Data.Models
{
    public interface IInspectorService
    {
        bool IsIssuedFineValid(Fine fine, DateTime dateTime, int cost);
        void IssueFine(Staff staff, Fine fine, DateTime dateTime, int cost);
    }
}