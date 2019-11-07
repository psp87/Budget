namespace Project_Finance.Contracts
{
    using System;

    public interface IBudget
    {
        string Name { get; }

        int Count { get; }

        string Add(Finance finance);

        string Delete(string name);

        string Modify(string name);

        void Clear();

        decimal Total();

        string TotalPercent(decimal totalIncomes);

        void Foreach(Action<string> action);
    }
}