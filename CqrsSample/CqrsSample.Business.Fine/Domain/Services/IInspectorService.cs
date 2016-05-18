using System;
using CqrsSample.Business.Fine.Data.Models;

namespace CqrsSample.Business.Fine.Domain.Services
{
    public interface IInspectorService
    {
        bool IsIssuedFineValid(Data.Models.Fine fine, DateTime dateTime, int cost);
        void IssueFine(Staff staff, Data.Models.Fine fine, DateTime dateTime, int cost);
    }
}