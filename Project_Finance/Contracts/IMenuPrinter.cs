namespace Project_Finance.Contracts
{
    using Models.Budget;

    public interface IMenuPrinter
    {
        void Menu();

        void Submenu();

        void Budget(Budget budget, decimal incomesTotal);

        void PrintLine(int width);

        void AveragePerDay(Budget expensesVariable);

        void Count(Budget budget);
    }
}
