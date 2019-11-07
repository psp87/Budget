namespace Project_Finance.Contracts
{
    using Models;

    public interface IFinance
    {
        string Name { get; }

        decimal Value { get; }

        FinanceStatus Status { get; }
    }
}
