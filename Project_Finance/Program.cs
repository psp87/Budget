namespace Project_Finance
{
    using System;
    using Contracts;
    using Models.Budget;

    public class Program
    {
        private static IPrinter consoleBudgetPrint = PrinterFactory.GetConsolePrinter();
        private static IMenuPrinter consoleMenuPrint = PrinterFactory.GetConsoleMenuPrinter();
        private static IPrinter fileBudgetPrint = PrinterFactory.GetFilePrinter();

        public static void Main()
        {
            Budget incomes = new Budget("Incomes");
            Budget expensesFixed = new Budget("Expenses Fixed");
            Budget expensesVariable = new Budget("Expenses Variable");
            decimal totalSaved = 0;

            while (true)
            {
                decimal incomesTotal = incomes.Total();
                decimal balance = Balance(incomes, expensesFixed, expensesVariable);

                consoleMenuPrint.Menu();
                var option = Console.ReadKey().Key;
                Console.Clear();
                switch (option)
                {
                    case ConsoleKey.D1:
                        SubmenuBudget(incomes, incomesTotal);
                        break;
                    case ConsoleKey.D2:
                        SubmenuBudget(expensesFixed, incomesTotal);
                        break;
                    case ConsoleKey.D3:
                        SubmenuBudget(expensesVariable, incomesTotal);
                        break;
                    case ConsoleKey.D4:
                        Console.Write("Value: ");
                        totalSaved = decimal.Parse(Console.ReadLine());
                        break;
                    case ConsoleKey.D5:
                        consoleBudgetPrint.WholeBudget(incomes, expensesFixed, expensesVariable, balance, totalSaved);
                        break;
                    case ConsoleKey.D6:
                        consoleMenuPrint.AveragePerDay(expensesVariable);
                        break;
                    case ConsoleKey.D7:
                        ClearAll(incomes, expensesFixed, expensesVariable);
                        break;
                    case ConsoleKey.D8:
                        TemplateBudget(incomes, expensesFixed, expensesVariable);
                        break;
                    case ConsoleKey.D9:
                        fileBudgetPrint.WholeBudget(incomes, expensesFixed, expensesVariable, balance, totalSaved);
                        break;
                    case ConsoleKey.D0: return;
                }
            }
        }

        private static void SubmenuBudget(Budget budget, decimal incomesTotal)
        {
            consoleMenuPrint.Submenu();
            var optionSubmenu = Console.ReadKey().Key;
            Console.Clear();
            switch (optionSubmenu)
            {
                case ConsoleKey.D1:
                    Add(budget, incomesTotal);
                    break;
                case ConsoleKey.D2:
                    Delete(budget, incomesTotal);
                    break;
                case ConsoleKey.D3:
                    Modify(budget, incomesTotal);
                    break;
                case ConsoleKey.D4:
                    consoleMenuPrint.Budget(budget, incomesTotal);
                    consoleMenuPrint.PrintLine(53);
                    break;
                case ConsoleKey.D5:
                    consoleMenuPrint.Count(budget);
                    break;
                case ConsoleKey.D6:
                    budget.Clear();
                    break;
                case ConsoleKey.D7:
                    budget.AddTemplate(budget);
                    break;
                case ConsoleKey.D9:
                    break;
            }
        }

        private static void Add(Budget budget, decimal incomesTotal)
        {
            consoleMenuPrint.Budget(budget, incomesTotal);
            consoleMenuPrint.PrintLine(53);
            string elementAdded = budget.Add(Finance.Create());
            Console.WriteLine(elementAdded);
            consoleBudgetPrint.Total(budget);
        }

        private static void Delete(Budget budget, decimal incomesTotal)
        {
            consoleMenuPrint.Budget(budget, incomesTotal);
            consoleMenuPrint.PrintLine(53);
            Console.Write("Name: ");
            string name = Console.ReadLine().ToLower();
            string elementRemoved = budget.Delete(name);
            Console.WriteLine(elementRemoved);
            consoleBudgetPrint.Total(budget);
        }

        private static void Modify(Budget budget, decimal incomesTotal)
        {
            consoleMenuPrint.Budget(budget, incomesTotal);
            consoleMenuPrint.PrintLine(53);
            Console.Write("Name: ");
            string name = Console.ReadLine().ToLower();
            string elementModified = budget.Modify(name);
            Console.WriteLine(elementModified);
            consoleBudgetPrint.Total(budget);
        }

        private static void ClearAll(Budget incomes, Budget expensesFixed, Budget expensesVariable)
        {
            incomes.Clear();
            expensesFixed.Clear();
            expensesVariable.Clear();
        }

        private static decimal Balance(Budget incomes, Budget expensesFixed, Budget expensesVariable)
        {
            return incomes.Total() - expensesFixed.Total() - expensesVariable.Total();
        }

        private static void TemplateBudget(Budget incomes, Budget expensesFixed, Budget expensesVariable)
        {
            incomes.AddTemplate(incomes);
            expensesFixed.AddTemplate(expensesFixed);
            expensesVariable.AddTemplate(expensesVariable);
        }
    }
}