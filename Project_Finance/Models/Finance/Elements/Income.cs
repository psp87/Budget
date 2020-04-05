namespace Project_Finance
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Income : Finance, IFinance
    {
        public Income(string name, decimal value)
            : base(name, value)
        {
        }

        public static List<Income> Template()
        {
            List<Income> incomesTemplate = new List<Income>
            {
                new Income("income", 100),
                new Income("income", 100),
                new Income("income", 100),
                new Income("income", 100),
                new Income("income", 100),
            };

            return incomesTemplate.OrderByDescending(x => x.Value).ToList();
        }
    }
}
