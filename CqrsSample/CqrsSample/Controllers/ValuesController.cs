using CqrsSample.Core.CQRS.CommandStack;
using CqrsSample.Core.CQRS.QueryStack;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CqrsSample.Business.Fine.CQRS.CommandStack.Commands;
using CqrsSample.Business.Fine.Data.Models;
using CqrsSample.Core.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.Core.CQRS.QueryStack.Queries.CRUDQueries;

namespace CqrsSample.Controllers
{
    [RoutePrefix("api/business")]
    public class BusinessController : ApiController
    {
        public CommandDispatcher CommandDispatcher { get; set; }
        public QueryDispatcher QueryDispatcher { get; set; }

        [Route("fines"),HttpPost]
        public async Task<IHttpActionResult> DefineFine(DefineFineCqrsCommand cqrsCommand)
        {
            var commandResult = await CommandDispatcher.Dispatch(cqrsCommand, GetCurrentUserId(), GetCurrentIp());
            return Ok();
        }

        [Route("fines-crud"), HttpPost]
        public async Task<IHttpActionResult> GetStaffFines(CreateCqrsCommand<Fine> command)
        {
            var commandResult = await CommandDispatcher.Dispatch(command, GetCurrentUserId(), GetCurrentIp());
            return Ok();
        }

        [Route("staffs/register"), HttpGet]
        public async Task<IHttpActionResult> RegisterStaff(RegisterStaffCqrsCommand cqrsCommand)
        {
            var commandResult = await CommandDispatcher.Dispatch(cqrsCommand, GetCurrentUserId(), GetCurrentIp());
            return Ok();
        }

        [Route("fines"), HttpGet]
        public async Task<IHttpActionResult> GetStaffFines()
        {
            var query = new ReadCqrsQuery<Fine> {QueryConfiguration = (q) => q.Where(q1 => q1.MaxCost > 10)};

            var queryResult = await QueryDispatcher.Dispatch<ReadCqrsQuery<Fine>, Fine[]>(query, GetCurrentUserId(), GetCurrentIp());
            return Ok();
        }

        private string GetCurrentIp()
        {
            return "`127.0.0.1";
        }

        private int GetCurrentUserId()
        {
            return 1;
        }
    }
}
