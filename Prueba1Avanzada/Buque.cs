using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba1Avanzada
{
    internal class Buque
    {
        private string codigo;//debe tener al menos 5 caracteres.
        private string nombre;
        private string pais;
        private int cantidadContainers;
        private int cantidadContainersCargados;
        private int gastoTransporte;
        private List<Container> listaContainers;

        //public string Codigo { get => codigo; }

        public string Codigo
        {
            get { return codigo; }
            set {
                    if (value.Length<5)
                    {
                        throw new ArgumentException("El codigo debe ser de al menos 5 caracteres.");
                    }
                    else
                    {
                        codigo = value;
                    }
                }
        }


        public string Nombre { get => nombre; set => nombre = value;}
        public string Pais { get => pais; set => pais = value; }
        public int CantidadContainers { get => cantidadContainers; set => cantidadContainers = value; }
        public int CantidadContainersCargados { get => cantidadContainersCargados; set => cantidadContainersCargados = value; }
        public int GastoTransporte { get => gastoTransporte; set => gastoTransporte = value; }  
        public List<Container> ListaContainers { get => listaContainers; set => listaContainers = value; }

        //Constructores
        public Buque(string codigo)
        {
            listaContainers = new List<Container>();
            if (codigo.Length < 5)
            {
                throw new ArgumentException("El codigo debe tener al menos 5 caracteres.");
            }
            else
            {
                this.codigo = codigo;
            }
            CantidadContainersCargados = 0;
        }

        public Buque(string codigo, string nombre, string pais, int cantidadcontainers ,int gastoTransporte)
        {
            listaContainers=new List<Container>();
            if (codigo.Length < 5)
            {
                throw new ArgumentException("El codigo debe tener al menos 5 caracteres.");
            }
            else
            {
                this.codigo = codigo;
            }
            this.nombre = nombre;
            this.pais = pais;
            this.cantidadContainers= cantidadcontainers;
            this.gastoTransporte= gastoTransporte;
            CantidadContainersCargados = 0;


        }

       

        /// <summary>
        /// Metodo que calcula la carga total que tiene el buque, medido en containers de 20 pies
        /// </summary>
        /// <returns></returns>
        private int CalcularCarga()
        {
            int cantidadDe20 = 0;

            foreach (Container elemento in listaContainers)
            {
                if(elemento.Tamaño == 20)
                {
                    cantidadDe20++;
                }
                else
                {
                    cantidadDe20 = cantidadDe20 + 2;
                }
            }
            return cantidadDe20;
        }


        public bool SubirContainer(Container nuevoContainer)
        {
            bool trabajoRealizado = false;
            if (nuevoContainer.Tamaño == 20)
            {
                if(cantidadContainersCargados+1 <= cantidadContainers)
                {
                    //Se carga un container de 20.
                    CantidadContainersCargados++;
                    listaContainers.Add(nuevoContainer);
                    trabajoRealizado=true;
                }
                else
                {
                    //No hay capacidad para más containers.No se carga.
                    trabajoRealizado = false;
                    
                }

            }
            else if (nuevoContainer.Tamaño == 40)
            {
                if (cantidadContainersCargados + 2 <= cantidadContainers)
                {
                    //Asumimos que un container de 40 ocupa la carga de 2 de 20 pies.
                    //Se carga un container de 40.
                    CantidadContainersCargados=CantidadContainersCargados+2;
                    listaContainers.Add(nuevoContainer);
                    trabajoRealizado = true;
                }
                else
                {
                    //No hay capacidad para más containers.No se carga.
                    trabajoRealizado = false;

                }
            }
            else
            {
                //Hay un error en el tamaño del container.
                trabajoRealizado = false;
            }

            //Si el container se subio, se le actualiza, ahora esta en este buque:
            if (trabajoRealizado)
            {
                nuevoContainer.Buque = this;
            }

            return trabajoRealizado;
        }

        public override string ToString()
        {
            string salida="Buque cod:" + this.codigo + ", Nombre: " + this.nombre+", pais:"+pais
                +" , cantidadContainers: "+cantidadContainers+", gastoTransporte :"+gastoTransporte
                +",ListaContainers: "+listaContainers.Count+" elementos.";
            return salida;
        }


    }

   
}
