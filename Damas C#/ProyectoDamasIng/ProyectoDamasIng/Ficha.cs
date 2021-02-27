using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDamasIng
{
    //La clase ficha se encarga de guardar los valores de la posición de una ficha en específico así como las distintas direcciones hacia las cuales puede moverse o comer
    class Ficha
    {
        protected string color;
        protected int fila;
        protected int columna;
        protected List<Ficha> posiblesMov;
        protected List<Ficha> posiblesComer;

        public Ficha(string color, int fila, int columna)
        {
            this.color = color;
            this.fila = fila;
            this.columna = columna;
            this.posiblesMov = new List<Ficha>();
            this.posiblesComer = new List<Ficha>();
        }
        public Ficha(int fila, int columna)
        {
            this.color = "";
            this.fila = fila;
            this.columna = columna;
            this.posiblesMov = new List<Ficha>();
            this.posiblesComer = new List<Ficha>();
            
        }
        public int Fila
        {
            get { return this.fila; }
        }
        public int Columna
        {
            get { return this.columna; }
        }
        public string Color
        {
            get { return this.color; }
        }
        //PosiblesMov se encarga de regresar un arreglo conteniendo los distintos espacios a los cuales la ficha se puede mover
        //el resultado arrojado varía segun la posición de la ficha
        public virtual List<Ficha> PosiblesMov()
        {
            return this.posiblesMov;
        }
        //PosiblesComer se encarga de regresar un arreglo conteniendo los distintos espacios a los cuales la ficha se puede mover para comer
        //el resultado arrojado varía segun la posición de la ficha
        public virtual List<Ficha> PosiblesComer()
        {
            return this.posiblesComer;
        }
    }
}
