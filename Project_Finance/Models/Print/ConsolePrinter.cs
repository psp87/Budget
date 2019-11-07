namespace Project_Finance.Models.Print
{
    using System;
    using Contracts;
    using Models.Budget;

    public class ConsolePrinter : IPrinter, IMenuPrinter
    {
        public void Menu()
        {
            Painter.BlackYellow();

            Console.WriteLine($"+{new string('=', 28)}+");
            Console.WriteLine(string.Format("|{0, -28}|", " 1. Set Income"));
            Console.WriteLine(string.Format("|{0, -28}|", " 2. Set Expense Fixed"));
            Console.WriteLine(string.Format("|{0, -28}|", " 3. Set Expense Variable"));
            Console.WriteLine(string.Format("|{0, -28}|", " 4. Set Total Saved"));
            Console.WriteLine(string.Format("|{0, -28}|", " 5. Budget Print"));
            Console.WriteLine(string.Format("|{0, -28}|", " 6. Average/Day"));
            Console.WriteLine(string.Format("|{0, -28}|", " 7. Budget Clear"));
            Console.WriteLine(string.Format("|{0, -28}|", " 8. Load Budget Template"));
            Console.WriteLine(string.Format("|{0, -28}|", " 9. Save to File"));
            Console.WriteLine(string.Format("|{0, -28}|", " 0. EXIT"));
            Console.WriteLine($"+{new string('=', 28)}+");

            Painter.BlackGray();

            Console.Write("  Choose option: ");
        }

        public void Submenu()
        {
            Painter.BlackYellow();

            Console.WriteLine($"+{new string('=', 28)}+");
            Console.WriteLine(string.Format("|{0, -28}|", " 1. Add"));
            Console.WriteLine(string.Format("|{0, -28}|", " 2. Delete"));
            Console.WriteLine(string.Format("|{0, -28}|", " 3. Modify"));
            Console.WriteLine(string.Format("|{0, -28}|", " 4. Display"));
            Console.WriteLine(string.Format("|{0, -28}|", " 5. Count"));
            Console.WriteLine(string.Format("|{0, -28}|", " 6. Clear"));
            Console.WriteLine(string.Format("|{0, -28}|", " 7. Load Template"));
            Console.WriteLine(string.Format("|{0, -28}|", " 9. BACK"));
            Console.WriteLine($"+{new string('=', 28)}+");

            Painter.BlackGray();

            Console.Write("  Choose option: ");
        }

        public void Total(Budget budget)
        {
            Console.WriteLine($"Total: {budget.Total():F2} lv.");
        }

        public void WholeBudget(Budget incomes, Budget expensesFixed, Budget expensesVariable, decimal balance, decimal totalSaved)
        {
            decimal incomesTotal = incomes.Total();

            this.PrintTitle();
            this.Budget(incomes, incomesTotal);
            this.Budget(expensesFixed, incomesTotal);
            this.Budget(expensesVariable, incomesTotal);
            this.Balance(balance, incomesTotal);
            this.TotalSaved(totalSaved, balance);
        }

        public void Budget(Budget budget, decimal incomesTotal)
        {
            this.PrintLine(53);
            this.PrintTotal(budget, incomesTotal);
            this.PrintLine(53);
            this.PrintHeader();
            this.PrintLine(53);
            this.PrintBudget(budget, incomesTotal);
        }

        public void AveragePerDay(Budget expensesVariable)
        {
            int daysInMonth = DateTime.DaysInMonth(2019, DateTime.Now.Month);
            decimal averagePerDay = expensesVariable.Total() / daysInMonth;

            this.PrintLine(53);
            Painter.BlueWhite();
            Console.WriteLine(string.Format("|{0, -53}|", $"AVERAGE PER DAY: {averagePerDay:F1} lv."));
            Painter.BlackGray();
            this.PrintLine(53);
        }

        public void Count(Budget budget)
        {
            this.PrintLine(53);
            Painter.BlueWhite();
            Console.WriteLine(string.Format("|{0, -53}|", $"COUNT: {budget.Count}"));
            Painter.BlackGray();
            this.PrintLine(53);
        }

        public void PrintLine(int width)
        {
            Console.WriteLine($"+{new string('-', width)}+");
        }

        private void TotalSaved(decimal totalSaved, decimal balance)
        {
            totalSaved += balance;
            Painter.CyanWhite();

            Console.WriteLine(string.Format("|{0,-53}|", $"TOTAL SAVED: {totalSaved} lv."));

            Painter.BlackGray();
            this.PrintLine(53);
        }

        private void PrintTitle()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            this.PrintLine(53);
            Painter.BlueWhite();
            Console.WriteLine(string.Format("|{0,18}{1,-17}{2,18}|", string.Empty, $"BUDGET {year}-{month}-{day}", string.Empty));
            Painter.BlackGray();
        }

        private void Balance(decimal balance, decimal incomesTotal)
        {
            this.PrintLine(53);
            Painter.BlueWhite();

            if (incomesTotal > 0)
            {
                Console.WriteLine(string.Format(
                    "|{0,-43}{1,-10}|",
                    $"TOTAL BALANCE: {balance.ToString("+#;-#;0")} lv.",
                    $"({balance / incomesTotal:P1})"));
            }
            else
            {
                Console.WriteLine(string.Format(
                    "|{0,-43}{1,-10}|",
                    $"TOTAL BALANCE: {balance.ToString("+#;-#;0")} lv.",
                    "(N/A %)"));
            }

            Painter.BlackGray();
            this.PrintLine(53);
        }

        private void PrintHeader()
        {
            Painter.GrayWhite();
            Console.WriteLine(string.Format("|{0,20}|{1,10}|{2,10}|{3,10}|", "Name", "Value", "Percent", "Status"));
            Painter.BlackGray();
        }

        private void PrintBudget(Budget budget, decimal incomesTotal)
        {
            for (int i = 0; i < budget.Count; i++)
            {
                string financeName = budget.GetFinanceNames()[i].Length > 20
                    ? budget.GetFinanceNames()[i].Substring(0, 20 - 3) + "..."
                    : budget.GetFinanceNames()[i];
                decimal financeValue = budget.GetFinanceValues()[i];
                FinanceStatus financeStatus = budget.GetFinanceStatuses()[i];

                string value = incomesTotal > 0 ? (financeValue / incomesTotal).ToString("P1") : "N/A";

                Console.WriteLine(string.Format(
                    "|{0,-20}|{1,-10}|{2,-10}|{3,-10}|",
                    financeName,
                    $"{financeValue} lv.",
                    value,
                    financeStatus));
            }
        }

        private void PrintTotal(Budget budget, decimal incomesTotal)
        {
            if (budget.Name == "Incomes")
            {
                Painter.GreenWhite();
            }
            else
            {
                Painter.RedWhite();
            }

            Console.WriteLine(string.Format(
                "|{0,-43}{1,-10}|",
                $"TOTAL {budget.Name.ToUpper()}: {budget.Total()} lv.",
                $"({budget.TotalPercent(incomesTotal)})"));
            Painter.BlackGray();
        }
    }
}