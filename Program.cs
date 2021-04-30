using System;

namespace Proyecto_Final
{
    public class Prestamos
    {
        public double Dinero, Interes, Interes_A, Capital, Prestamo, Interes_M, pagos = 1, Plazo;

        public void Entrada_de_Datos()
        {

            Console.WriteLine();
            Console.WriteLine("Calculadora de Préstamos");

            Console.WriteLine("\nIntroduzca Monto a solicitar:");
            Prestamo = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("\nEscriba Tasa Anual:");
            Interes_A = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("\nEscriba la cantidad de Meses:");
            Plazo = Convert.ToUInt32(Console.ReadLine());


        }

        public void Calculos()
        {

            Interes_M = (Interes_A / 100) / 12;

            Dinero = Interes_M + 1;
            Dinero = (double)Math.Pow(Dinero, Plazo);
            Dinero = Dinero - 1;
            Dinero = Interes_M / Dinero;
            Dinero = Interes_M + Dinero;
            Dinero = Prestamo * Dinero;

        }

        public void Salida_Datos_Tabla()
        {

            int i = 1;

            do
            {
                Console.Write("{0}\t", pagos);

                pagos = pagos + 1;

                Console.Write("{0}\t", Dinero.ToString("0.00"));


                Interes = Interes_M * Prestamo;
                Console.Write("\t{0}\t", Interes.ToString("0.00"));


                Capital = Dinero - Interes;
                Console.Write(" \t{0}\t", Capital.ToString("0.00"));


                Prestamo = Prestamo - (Capital);

                if (Prestamo < 1)
                {

                    Console.Write(" \t{0} \t   ", Prestamo = 0);
                }
                else
                {
                    Console.Write(" \t{0}    ", Prestamo.ToString("0.00"));
                }


                Console.WriteLine();

                i++;

            } while (i <= Plazo);
            Console.WriteLine();

        }

        public void Detalles()
        {
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("Usted está simulando un crédito con las siguientes características:");

            Console.WriteLine();
            Console.WriteLine("Monto del Préstamo: RD$ {0}", Prestamo);

            Console.WriteLine();
            Console.WriteLine("Tasa de Porcentaje Anual: {0}%", Interes_A);
            Console.WriteLine();

            Console.WriteLine("Plazo: {0} Meses", Plazo);
            Console.WriteLine();

            Console.WriteLine("Valor de Cuota: RD$ {0}", Dinero.ToString("0.00"));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\t\t\tTabla de Amortización");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Pago");
            Console.Write("\t Cuota");
            Console.Write("\t\tInteres");
            Console.Write("\t\tCapital ");
            Console.Write("\t Balance ");

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            Prestamos p = new Prestamos();

            p.Entrada_de_Datos();
            p.Calculos();
            p.Detalles();
            p.Salida_Datos_Tabla();


        }
    }
}