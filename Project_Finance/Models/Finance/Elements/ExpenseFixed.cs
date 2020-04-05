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
                new ExpenseFixed("expense fixed", 100),
                new ExpenseFixed("expense fixed", 100),
                new ExpenseFixed("expense fixed", 100),
                new ExpenseFixed("expense fixed", 100),
                new ExpenseFixed("expense fixed", 100),
            };

            return expensesFixedTemplate.OrderByDescending(x => x.Value).ToList();
        }
    }
}