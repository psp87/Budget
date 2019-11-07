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
                new Income("salary velina", 2050),
                new Income("salary plamen", 1810),
                new Income("vouchers", 60),
                new Income("overtime", 0),
                new Income("other", 0)
            };

            return incomesTemplate.OrderByDescending(x => x.Value).ToList();
        }
    }
}
