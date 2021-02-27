using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDamasIng
{
    class FichaNegra:Ficha
    {
        public FichaNegra(int fila, int columna):base("negro", fila, columna)
        {

        }
        //PosiblesMov se encarga de regresar un arreglo conteniendo los distintos espacios a los cuales la ficha se puede mover
        //el resultado arrojado varía segun la posición de la ficha
        override
        public List<Ficha> PosiblesMov()
        {
            this.posiblesMov = new List<Ficha>();
            
            if (this.fila != 7 && this.columna == 0)
            {
                this.posiblesMov.Add(new FichaNegra(this.fila + 1, this.columna + 1));
            }
            else if(this.fila != 7  && this.columna == 7)
            {
                this.posiblesMov.Add(new FichaNegra(this.fila + 1, this.columna - 1));
            }
            else if(this.fila != 7)
            {
                this.posiblesMov.Add(new FichaNegra(this.fila + 1, this.columna + 1));
                this.posiblesMov.Add(new FichaNegra(this.fila + 1, this.columna - 1));
            }

            return this.posiblesMov;
        }
        //PosiblesComer se encarga de regresar un arreglo conteniendo los distintos espacios a los cuales la ficha se puede mover para comer
        //el resultado arrojado varía segun la posición de la ficha
        override
        public List<Ficha> PosiblesComer()
        {
            this.posiblesComer = new List<Ficha>();
            if (this.fila < 6 && this.columna < 2)
            {
                this.posiblesComer.Add(new FichaNegra(this.fila + 2, this.columna + 2));
            }
            else if (this.fila < 6 && this.columna > 5)
            {
                this.posiblesComer.Add(new FichaNegra(this.fila + 2, this.columna - 2));
            }
            else if (this.fila < 6)
            {
                this.posiblesComer.Add(new FichaNegra(this.fila + 2, this.columna + 2));
                this.posiblesComer.Add(new FichaNegra(this.fila + 2, this.columna - 2));
            }

            return this.posiblesComer;
        }
    }
}
