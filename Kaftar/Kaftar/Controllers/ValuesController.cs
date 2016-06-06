using System;
using System.Web.Http;
using Avicenna.Domain.CQRS.CommandStack.Commands;
using Avicenna.Domain.CQRS.QueryStack.Queries;
using Avicenna.Domain.CQRS.QueryStack.QueryResult;
using Avicenna.RciContracts;
using Kaftar.Core.CQRS.CommandStack;
using Kaftar.Core.CQRS.QueryStack;
using Kaftar.RuntimePolicyInjection.Core;

namespace Avicenna.Application.Controllers
{
    [RoutePrefix("api/business")]
    public class BusinessController : ApiController
    {
        public CommandDispatcher CommandDispatcher { get; set; }
        public QueryDispatcher QueryDispatcher { get; set; }

        [Route("visit"),HttpPost]
        public IHttpActionResult CreateVisit(CreateVisitCommand command)
        {
            var result = CommandDispatcher.Dispatch(command,GetUserId(),GetUserIp());
            return Ok();
        }

        [Route("visit"), HttpGet]
        public IHttpActionResult GetVisit([FromUri]GetVisitQuery query)
        {
            var result = QueryDispatcher.Dispatch<GetVisitQuery, GetVisitQueryResult>(query, GetUserId(), GetUserIp());
            return Ok();
        }

        [Route(""), HttpGet]
        public IHttpActionResult GetVisit()
        {
            int height = 0;
            int weigth = 0;
            var ruleResult = PolicyProvider.Instance
                .Single<BmiCalculator, double>
                ((contract) => contract.ClinicId == 7
                , weigth, height);

            return Ok(ruleResult);
        }

        private string GetUserIp()
        {
            return "127.0.0.1";
        }

        private int GetUserId()
        {
            return 666;
        }
    }
}
