namespace Project_Finance.Contracts
{
    using Models.Budget;

    public interface IPrinter
    {
        void Total(Budget budget);

        void WholeBudget(Budget incomes, Budget expensesFixed, Budget expensesVariable, decimal balance, decimal totalSaved);
    }
}