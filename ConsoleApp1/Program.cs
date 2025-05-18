namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime fecha = DateTime.Now;
            DateTime fecha2 = new DateTime(2025, 5, 13);
            DateTime fecha3 = new DateTime(2025, 5, 14);
            Console.WriteLine(fecha);
            Console.WriteLine(fecha2);
            TimeSpan fechaComparacion = fecha3 - fecha2;
            TimeSpan fechaComparacion2 = fecha2 - fecha ;
            TimeSpan test = new TimeSpan(1,0,0,0);
            Console.WriteLine(fechaComparacion >= (fecha-fecha2));
            Console.WriteLine(test.TotalHours);
        }
    }
}
