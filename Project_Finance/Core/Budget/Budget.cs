namespace Project_Finance.Models.Budget
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Budget : IBudget, IEnumerable<Finance>, IEnumerable<string>
    {
        private List<Finance> list;

        public Budget(string name)
        {
            this.list = new List<Finance>();
            this.Name = name;
        }

        public string Name { get; }

        public int Count => this.list.Count;

        public string Add(Finance finance)
        {
            this.list.Add(finance);
            this.list = this.list.OrderByDescending(x => x.Value).ToList();
            return $"Successfully added <{finance.Name}> with value: {finance.Value} lv.!";
        }

        public string Delete(string name)
        {
            if (!this.list.Select(x => x.Name).Contains(name))
            {
                return "No such finance found!";
            }

            Finance finance = this.list.Where(x => x.Name == name).FirstOrDefault();
            this.list.Remove(finance);
            return $"Successfully removed <{finance.Name}> with value: {finance.Value} lv.!";
        }

        public string Modify(string name)
        {
            if (!this.list.Select(x => x.Name).Contains(name))
            {
                return "No such finance found!";
            }
            else
            {
                for (int i = 0; i < this.list.Count; i++)
                {
                    if (this.list[i].Name == name)
                    {
                        Console.Write("New Value: ");
                        this.list[i].Value = int.Parse(Console.ReadLine());
                        Console.Write("New Status: ");
                        this.list[i].Status = FinanceStatus.IP;
                        return $"Successfully modified <{this.list[i].Name}> with value: {this.list[i].Value} lv.!";
                    }
                }

                return string.Empty;
            }
        }

        public void Clear()
        {
            this.list.Clear();
            Console.WriteLine($"CLEARED!");
        }

        public decimal Total()
        {
            return this.list.Select(x => x.Value).Sum();
        }

        public string TotalPercent(decimal totalIncomes)
        {
            if (totalIncomes > 0)
            {
                return (this.Total() / totalIncomes).ToString("P1");
            }

            return "N/A %";
        }

        public override string ToString()
        {
            foreach (var item in this.list)
            {
                Console.WriteLine(item.ToString());
            }

            return string.Empty;
        }

        public void AddTemplate(Budget budget)
        {
            switch (budget.Name)
            {
                case "Incomes": this.list.AddRange(Income.Template());
                    break;
                case "Expenses Fixed": this.list.AddRange(ExpenseFixed.Template());
                    break;
                case "Expenses Variable": this.list.AddRange(ExpenseVariable.Template());
                    break;
            }

            Console.WriteLine($"{budget.Name} Loaded!");
        }

        public List<string> GetFinanceNames()
        {
            return this.list.Select(x => x.Name).ToList();
        }

        public List<decimal> GetFinanceValues()
        {
            return this.list.Select(x => x.Value).ToList();
        }

        public List<FinanceStatus> GetFinanceStatuses()
        {
            return this.list.Select(x => x.Status).ToList();
        }

        public void Foreach(Action<string> action)
        {
            foreach (var finance in this.list)
            {
                action(finance.ToString());
            }
        }

        public IEnumerator<Finance> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item.ToString();
            }
        }
    }
}