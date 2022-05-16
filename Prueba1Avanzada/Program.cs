using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1Avanzada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            //Crear 2 buques.
            Buque buque1 = new Buque("35899","Ultranav","Noruega",230,12500);
            Buque buque2 = new Buque("35877","Super8","Chile",59,24000);
            //Buque buque3 = new Buque("35866","Milanesa","Argentina",39,12000);

            //Crear 4 containers.Asociarlos a un Buque. El 4to con el peso maximo asignado.
            Container cont1 = new Container("sr123", "Yamaha", 3000, 20, false, 2500, null);
            buque1.SubirContainer(cont1);
            Container cont2 = new Container("sr234", "HP", 900, 20, true, 200, null);
            buque1.SubirContainer(cont2);
            Container cont3 = new Container("sr345", "Okley", 1500, 40, false, 250, null);
            buque1.SubirContainer(cont3);
            Container cont4 = new Container("sr456", "Manzanas", 3000, 40, true, 3000, null);
            buque1.SubirContainer(cont4);

            //Listar los datos de los  containers que se encuentran en el buque.
            Console.WriteLine("Datos del buque1:"+ buque1);
            Console.WriteLine("Lista de los containers en el buque1:");
            foreach(Container elemento in buque1.ListaContainers)
            {
                Console.WriteLine(elemento.ToString());
            }


            //Mostrar el valor a pagar por conceptos de inspección para el container 3.
            Console.WriteLine("Valor a pagar por inspeccion del container 3:");
            Console.WriteLine(cont3.valorPagoInspeccion());

            //Mostrar el valor que debe pagar cada uno de los containers creados por conceptos de gastos de envío.
            Console.WriteLine("Conceptos de gastos de envio por conainer:");
            Console.WriteLine("cont1:"+cont1.CalcularGastosEnvio());
            Console.WriteLine("cont2:"+cont2.CalcularGastosEnvio());
            Console.WriteLine("cont3:"+cont3.CalcularGastosEnvio());
            Console.WriteLine("cont4:"+cont4.CalcularGastosEnvio());

            //Mostrar si al container 4 puedo subir una caja con mercadería que pesa 2000 kilos
            Console.WriteLine("Se intentara subir una caja de 2000 kilos al container 4.");
            if (cont4.PuedeSubir(2000))
            {
                Console.WriteLine("Se pudo subir la caja con mercaderia de 2000 kilos");
            }
            else
            {
                Console.WriteLine("No se pudo subir la caja.");
            }

            // Quitar 200 kilos de peso desde el primero de los containers y mostrar el peso actual. 
            Console.WriteLine("Se quitaran 200 kilos de peso del container1");
            bool res =cont1.SacarPeso(200);
            if (res)
            {
                Console.WriteLine("Peso sacado.");
            }
            else
            {
                Console.WriteLine("No se saco el peso.");
            }
            Console.WriteLine("El peso actual del container1 es: " + cont1.PesoActual);


        }
    }
}
