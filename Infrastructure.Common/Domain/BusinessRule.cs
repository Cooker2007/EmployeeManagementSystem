namespace Infrastructure.Common.Domain
{
    public class BusinessRule
    {
        public BusinessRule(string ruleDescription)
        {
            this.RuleDescription = ruleDescription;
        }

        public string RuleDescription { get; }
    }
}