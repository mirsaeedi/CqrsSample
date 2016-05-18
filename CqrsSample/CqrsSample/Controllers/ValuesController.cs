using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CqrsSample.CommandStack;
using CqrsSample.CommandStack.Commands;
using CqrsSample.CQRS.CommandStack;
using CqrsSample.CQRS.CommandStack.CommandHandlers.CRUDCommandHandlers;
using CqrsSample.CQRS.CommandStack.Commands.CRUDCommands;
using CqrsSample.CQRS.QueryStack;
using CqrsSample.CQRS.QueryStack.Queries.CRUDQueries;
using CqrsSample.Data.Models;
using CqrsSample.FineBusiness.CQRS.CommandStack.Commands;
using CqrsSample.FineBusiness.CQRS.QueryStack.Queries;
using CqrsSample.QueryStack;

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
            var commandResult = await CommandDispatcher.Dispatch<DefineFineCqrsCommand>(cqrsCommand, GetCurrentUserId(), GetCurrentIp());
            return Ok();
        }

        [Route("fines-crud"), HttpPost]
        public async Task<IHttpActionResult> GetStaffFines(CreateCqrsCommand<Fine> command)
        {
            var commandResult = await CommandDispatcher.Dispatch<CreateCqrsCommand<Fine>>(command, GetCurrentUserId(), GetCurrentIp());
            return Ok();
        }


        [Route("staffs/register"), HttpGet]
        public async Task<IHttpActionResult> RegisterStaff(RegisterStaffCqrsCommand cqrsCommand)
        {
            var commandResult = await CommandDispatcher.Dispatch<RegisterStaffCqrsCommand>(cqrsCommand, GetCurrentUserId(), GetCurrentIp());
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
