namespace Project_Finance
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class ExpenseVariable : Finance, IFinance
    {
        public ExpenseVariable(string name, decimal value)
            : base(name, value)
        {
        }

        public static List<ExpenseVariable> Template()
        {
            List<ExpenseVariable> expensesVariableTemplate = new List<ExpenseVariable>
            {
                new ExpenseVariable("food", 800),
                new ExpenseVariable("fuel", 100),
                new ExpenseVariable("cigarettes", 100),
                new ExpenseVariable("going out", 300),
                new ExpenseVariable("unexpected", 200)
            };

            return expensesVariableTemplate.OrderByDescending(x => x.Value).ToList();
        }
    }
}