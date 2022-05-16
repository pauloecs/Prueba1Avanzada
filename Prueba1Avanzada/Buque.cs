using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1Avanzada
{
    internal class Buque
    {
        private string codigo;
        private string nombre;
        private string pais;
        private int cantidadContainers;
        private int cantidadContainersCargados;
        private int gastoTransporte;
        private List<Container> listaContainers;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value;}
        public string Pais { get => pais; set => pais = value; }
        public int CantidadContainers { get => cantidadContainers; set => cantidadContainers = value; }
        public int CantidadContainersCargados { get => cantidadContainersCargados; set => cantidadContainersCargados = value; }
        public int GastoTransporte { get => gastoTransporte; set => gastoTransporte = value; }  
        public List<Container> ListaContainers { get => listaContainers; set => listaContainers = value; }

        //Constructores
        public Buque(string codigo)
        {
            this.codigo = codigo;

        }

        public Buque(string codigo, string nombre, string pais, int cantidadcontainers)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.pais = pais;
            this.cantidadContainers= cantidadcontainers;
            //Lo otro se llena luego¿? o se calcula¿?

        }
    }
}
