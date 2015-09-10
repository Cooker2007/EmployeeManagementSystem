namespace Infrastructure.Common.Domain
{
    public class BusinessRule
    {
        private readonly string ruleDescription;

        public BusinessRule(string ruleDescription)
        {
            this.ruleDescription = ruleDescription;
        }

        public string RuleDescription
        {
            get
            {
                return this.ruleDescription;
            }
        }
    }
}