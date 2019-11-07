namespace Project_Finance
{
    using Contracts;
    using Models.Print;

    public class PrinterFactory
    {
        public static IPrinter GetConsolePrinter()
        {
            return new ConsolePrinter();
        }

        public static IMenuPrinter GetConsoleMenuPrinter()
        {
            return new ConsolePrinter();
        }

        public static IPrinter GetFilePrinter()
        {
            return new FilePrinter();
        }
    }
}
