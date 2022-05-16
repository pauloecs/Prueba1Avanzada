using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1Avanzada
{
    internal class Container
    {
        private string codigo;
        private string marca;
        private int capacidadMaxima;
        private byte tamaño;
        private bool esRefrigerado;
        private int pesoActual;
        public Buque buque;

        //getters y setters:

        public string Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        public byte Tamaño { get => tamaño; set => tamaño = value; }
        public bool EsRefrigerado { get => esRefrigerado; set => esRefrigerado = value; }
        public int PesoActual { get => pesoActual; set => pesoActual = value;}
        public Buque Buque { get => buque; set => buque = value; }

        //Constructores
        public Container(string codigo)
        {
            this.codigo = codigo;
            this.pesoActual = 0;
        }
        public Container(string codigo, string marca, int capacidadMax, byte tamaño, bool esRefrigerado
            ,int pesoActual, Buque buqueAsignado)
        {
            this.codigo = codigo;
            this.marca = marca;
            this.tamaño = tamaño;
            this.esRefrigerado = esRefrigerado;
            this.buque = buqueAsignado;

            if ( pesoActual>=0 && (pesoActual <= capacidadMax))
            {
                this.capacidadMaxima = capacidadMax;
                this.pesoActual = pesoActual;
            }
            else
            {
                throw new ArgumentException("El peso actual debe ser un entero positivo o cero, menor a capacidadMaxima");
            }

            
        }

        public bool SacarPeso(int sacarPeso)
        {
            if (sacarPeso < 0)
            {
                return false;
            }
            if( pesoActual-sacarPeso > 0)
            {
                pesoActual = pesoActual - sacarPeso;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int valorPagoInspeccion()
        {
            //5 pesos por kilo de carga revisado.
            int valor = pesoActual*5 ;
            return valor;
        }

        public override string ToString()
        {
            string cadenaBuque = "null";
            if (buque == null)
            {
                cadenaBuque="ninguno";
            }
            else
            {
                cadenaBuque = buque.Nombre;
            }

            string cadena = "";
            cadena = "Container{ cod: "+this.codigo+", marca: "+this.marca+", capMax: "+this.capacidadMaxima+", tamaño: "
                +this.tamaño+", refrigerado: "+this.esRefrigerado+", pesoActual: "+this.pesoActual+", Buque: "
                +cadenaBuque + "};";

            return cadena;
        }

        public int CalcularGastosEnvio()
        {
            //Primero que nada: Necesito el gasto de transporte por container, del buque actual.
            int gastoViaje = this.Buque.GastoTransporte;
            //lo divido por la cantidad de containers que PUEDE cargar. (asi lo dice el enunciado).
            int gastoContainer = gastoViaje / this.Buque.CantidadContainers;
            int gastoAduana = 0;
            if (this.Tamaño == 20)
            {
                gastoAduana = 3500;
            }else if (this.Tamaño == 40)
            {
                gastoAduana = 9000;
            }
            else
            {
                //Si el tamaño no es 20 ni 40 hay un error.
                Console.WriteLine("Error al calcular gastos de envio, tamaño anormal");
                gastoAduana = 0;
                return -1; 
            }
            int totalEnvio = gastoContainer + gastoAduana;
            return totalEnvio;
        }

        public bool PuedeSubir(int pesoExtra)
        {
            if(pesoExtra <= 0)
            {
                return false;
            }

            if( pesoActual+ pesoExtra > capacidadMaxima)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
