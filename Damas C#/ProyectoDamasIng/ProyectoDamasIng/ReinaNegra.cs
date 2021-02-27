using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDamasIng
{
    class ReinaNegra:FichaNegra
    {
        public ReinaNegra(int fila, int columna) : base(fila, columna)
        {

        }
        //PosiblesMov en el caso de las reinas lo que hace es tomar los posibles valores de movimiento de las fichas del color contrario
        //por lo que ahora cuenta con el doble de posibles movimientos
        override
        public List<Ficha> PosiblesMov()
        {
            this.posiblesMov = new List<Ficha>();
            if (this.fila != 0 && this.columna == 0)
            {
                this.posiblesMov.Add(new ReinaNegra(this.fila - 1, this.columna + 1));
            }
            else if (this.fila != 0 && this.columna == 7)
            {
                this.posiblesMov.Add(new ReinaNegra(this.fila - 1, this.columna - 1));
            }
            else if (this.fila != 0)
            {
                this.posiblesMov.Add(new ReinaNegra(this.fila - 1, this.columna + 1));
                this.posiblesMov.Add(new ReinaNegra(this.fila - 1, this.columna - 1));
            }
            if (this.fila != 7 && this.columna == 0)
            {
                this.posiblesMov.Add(new ReinaNegra(this.fila + 1, this.columna + 1));
            }
            else if (this.fila != 7 && this.columna == 7)
            {
                this.posiblesMov.Add(new ReinaNegra(this.fila + 1, this.columna - 1));
            }
            else if (this.fila != 7)
            {
                this.posiblesMov.Add(new ReinaNegra(this.fila + 1, this.columna + 1));
                this.posiblesMov.Add(new ReinaNegra(this.fila + 1, this.columna - 1));
            }

            return this.posiblesMov;
        }
        //PosiblesComer en el caso de las reinas lo que hace es tomar los posibles valores de movimiento de las fichas del color contrario
        //por lo que ahora cuenta con el doble de posibles movimientos para comer
        override
        public List<Ficha> PosiblesComer()
        {
            this.posiblesComer = new List<Ficha>();
            if (this.fila > 1 && this.columna < 2)
            {
                this.posiblesComer.Add(new ReinaNegra(this.fila - 2, this.columna + 2));
            }
            else if (this.fila > 1 && this.columna > 5)
            {
                this.posiblesComer.Add(new ReinaNegra(this.fila - 2, this.columna - 2));
            }
            else if (this.fila > 1)
            {
                this.posiblesComer.Add(new ReinaNegra(this.fila - 2, this.columna - 2));
                this.posiblesComer.Add(new ReinaNegra(this.fila - 2, this.columna + 2));
            }
            if (this.fila < 6 && this.columna < 2)
            {
                this.posiblesComer.Add(new ReinaNegra(this.fila + 2, this.columna + 2));
            }
            else if (this.fila < 6 && this.columna > 5)
            {
                this.posiblesComer.Add(new ReinaNegra(this.fila + 2, this.columna - 2));
            }
            else if (this.fila < 6)
            {
                this.posiblesComer.Add(new ReinaNegra(this.fila + 2, this.columna + 2));
                this.posiblesComer.Add(new ReinaNegra(this.fila + 2, this.columna - 2));
            }
            return this.posiblesComer;
        }
    }
}
