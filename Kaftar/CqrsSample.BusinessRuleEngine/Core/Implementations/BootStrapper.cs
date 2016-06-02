using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;
using CqrsSample.BusinessRuleEngine.Data;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    public class BootStrapper
    {
        public void Bootstrap(ICollection<string> searchPath)
        {
            if(searchPath==null)
                searchPath=new List<string>();

            //var fileBasedRules = new FileRuleDiscoverer(searchPath)
              //  .Discover();

            var classBasedRules = new ClassRuleDiscoverer()
                .Discover();

            RuleEngine.CreateSigletonInstance(classBasedRules);

            // UpdateRulesInDb(fileBasedRules,classBasedRules);
        }

        private void UpdateRulesInDb(ICollection<IRule> fileBasedRules, ICollection<IRule> classBasedRules)
        {
            using (var dbContext = new RuleDbContext())
            {
                var currentRules = dbContext
                    .Rules
                    .ToDictionary(q=>q.FullName);


                Update(dbContext,currentRules, fileBasedRules,RuleType.File);
                Update(dbContext, currentRules, classBasedRules, RuleType.Class);
            }
        }

        private void Update(RuleDbContext dbContext, Dictionary<string, RuleEntity> currentRules, ICollection<IRule> newRules, RuleType ruleType)
        {
            foreach (var newRule in newRules)
            {
                string fullname = newRule.GetType().FullName;

                if (currentRules.ContainsKey(fullname))
                {

                }
                else
                {
                    dbContext.Rules.Add(new RuleEntity()
                    {
                        Name = newRule.Name,
                        FullName = fullname,
                        Description = newRule.Description,
                        IsEnable = newRule.IsEnable,
                        Priority = newRule.Priority,
                        Tag = null,
                        RuleType = ruleType
                    });
                }
            }
        }
    }
}
