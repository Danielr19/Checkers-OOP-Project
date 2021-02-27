using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDamasIng
{
    //La clase tablero se encarga de almacenar las posiciones de todas las fichas del juego así como el tipo de ficha el cual representan
    class Tablero
    {
        public Ficha[,] celdas;

        public Tablero()
        {
            this.celdas = new Ficha[8, 8];
        }

        public void Inicio()
        {
            //Poner las fichas negras en su posicion inicial
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(( i==0 || i==2 ) && (j==1 || j==3 || j==5 || j== 7))
                    {
                        celdas[i, j] = new FichaNegra(i,j);
                    }
                    else if((i == 1) && (j==0 || j == 2 || j == 4 || j == 6))
                    {
                        celdas[i,j] = new FichaNegra(i, j);
                    }
                    else
                    {
                        celdas[i, j] = new Ficha(i, j);
                    }
                }
            }

            //Poner las fichas blancas en su posición inicial
            for(int i = 5; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i == 5 || i == 7) && (j == 0 || j == 2 || j == 4 || j == 6))
                    {
                        celdas[i, j] = new FichaBlanca(i, j);
                    }
                    else if ((i == 6) && (j == 1 || j == 3 || j == 5 || j == 7))
                    {
                        celdas[i, j] = new FichaBlanca(i, j);
                    }
                    else
                    {
                        celdas[i, j] = new Ficha(i, j);
                    }
                }
            }
            for(int i = 3; i < 5; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    celdas[i, j] = new Ficha(i, j);
                }
            }
        }
        
        public Ficha[,] Celdas
        {
            get { return this.celdas; }
            
        }
    }
}
