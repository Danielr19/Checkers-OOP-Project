using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDamasIng
{
    //La clase juego se encarga de almacenar información perteneciente a los jugadores para poder ser manipulada en el main
    class Juego
    {
        private Jugador jugador1;
        private Jugador jugador2;

        public Juego(Jugador jugador1, Jugador jugador2)
        {
            //this.tablero = new Tablero();
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
        }
        public Jugador Jugador1
        {
            get { return this.jugador1; }
        }
        public Jugador Jugador2
        {
            get { return this.jugador2; }
        }
    }
}
