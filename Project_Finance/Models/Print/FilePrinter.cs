namespace Project_Finance.Models.Print
{
    using System;
    using System.IO;
    using Budget;
    using Contracts;

    /// <summary>
    /// Saves the budget to file
    /// </summary>
    public class FilePrinter : IPrinter
    {
        public void Total(Budget budget)
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string path = $"../../../{budget.Name.ToUpper()}-{year}-{month}-{day}.txt";

            File.WriteAllText(path, $"Total: {budget.Total():F2} lv.");
        }

        public void WholeBudget(Budget incomes, Budget expensesFixed, Budget expensesVariable, decimal balance, decimal totalSaved)
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string path = $"../../../Budget-{year}-{month}-{day}.txt";

            decimal incomesTotal = incomes.Total();
            this.Budget(incomes, incomesTotal, path);
            this.Budget(expensesFixed, incomesTotal, path);
            this.Budget(expensesVariable, incomesTotal, path);

            if (incomesTotal > 0)
            {
                this.Balance(balance, balance / incomesTotal, path);
            }
            else
            {
                this.Balance(0, 0, path);
            }
        }

        private void Budget(Budget budget, decimal incomesTotal, string path)
        {
            Console.WriteLine();
            File.AppendAllText(path, $"+{new string('-', 53)}+\n");
            File.AppendAllText(
                path, 
                string.Format(
                "|{0,-43}{1,-10}|\n", 
                $"TOTAL {budget.Name.ToUpper()}: {budget.Total()} lv.", 
                $"({budget.TotalPercent(incomesTotal):P1})"));
            File.AppendAllText(path, $"+{new string('-', 53)}+\n");
            File.AppendAllText(path, string.Format("|{0,20}|{1,10}|{2,10}|{3,10}|\n", "Name", "Value", "Percent", "Status"));
            File.AppendAllText(path, $"+{new string('-', 53)}+\n");
            for (int i = 0; i < budget.Count; i++)
            {
                string financeName = budget.GetFinanceNames()[i];
                decimal financeValue = budget.GetFinanceValues()[i];
                FinanceStatus financeStatus = budget.GetFinanceStatuses()[i];

                File.AppendAllText(
                    path, 
                    string.Format(
                    "|{0,-20}|{1,-10}|{2,-10}|{3,-10}|\n",
                    financeName, 
                    $"{financeValue} lv.", 
                    $"{financeValue / incomesTotal:P1}", 
                    financeStatus));
            }
        }

        private void Balance(decimal balance, decimal balancePercent, string path)
        {
            File.AppendAllText(path, $"+{new string('-', 53)}+\n");
            File.AppendAllText(path, string.Format("|{0,-43}{1,-10}|\n", $"BALANCE: {balance} lv.", $"({balancePercent:P1})"));
            File.AppendAllText(path, $"+{new string('-', 53)}+\n");
        }
    }
}