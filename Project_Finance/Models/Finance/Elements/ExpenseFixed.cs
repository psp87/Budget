namespace Project_Finance
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class ExpenseFixed : Finance, IFinance
    {
        public ExpenseFixed(string name, decimal value) 
            : base(name, value)
        {
        }

        public static List<ExpenseFixed> Template()
        {
            List<ExpenseFixed> expensesFixedTemplate = new List<ExpenseFixed>
            {
                new ExpenseFixed("rent", 780),
                new ExpenseFixed("accounts", 120),
                new ExpenseFixed("credit velina", 250),
                new ExpenseFixed("credit plamen", 330),
                new ExpenseFixed("tv & net", 60),
                new ExpenseFixed("phone", 10),
                new ExpenseFixed("procedures", 200),
                new ExpenseFixed("big spends", 100),
                new ExpenseFixed("sports plamen", 50),
                new ExpenseFixed("sports velina", 20),
            };

            return expensesFixedTemplate.OrderByDescending(x => x.Value).ToList();
        }
    }
}