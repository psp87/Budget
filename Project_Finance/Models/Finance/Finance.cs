namespace Project_Finance
{
    using System;
    using Contracts;
    using Models;

    public class Finance : IFinance
    {
        private decimal value;

        public Finance(string name, decimal value)
        {
            this.Name = name;
            this.Value = value;
            this.Status = FinanceStatus.I;
        }

        public string Name { get; }

        public decimal Value
        {
            get => this.value;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid value!");
                }

                this.value = value;
            }
        }

        public FinanceStatus Status { get; set; }

        public static Finance Create()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine().ToLower();
            Console.Write("Value: ");
            decimal value = decimal.Parse(Console.ReadLine());

            Finance finance = new Finance(name, value);
            return finance;
        }

        public override string ToString()
        {
            return $"  {Name} - {Value} lv.   ({Status})";
        }
    }
}