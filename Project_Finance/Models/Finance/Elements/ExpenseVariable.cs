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
                new ExpenseVariable("expense variable", 100),
                new ExpenseVariable("expense variable", 100),
                new ExpenseVariable("expense variable", 100),
                new ExpenseVariable("expense variable", 100),
                new ExpenseVariable("expense variable", 100),
            };

            return expensesVariableTemplate.OrderByDescending(x => x.Value).ToList();
        }
    }
}