using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDamasIng
{
    //La clase jugador almacena información perteneciente al jugador como el nombre para identificarlo, el color de fichas que le corresponden
    //y el numero de fichas que tiene a su disposición 
    class Jugador
    {
        private bool turno;
        private string nombre;
        private string color;
        private int fichas;
        public Jugador(string nombre, string color)
        {
            this.nombre = nombre;
            this.color = color;
            this.fichas = 12;
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Color
        {
            get { return this.color; }
        }
        public bool Turno
        {
            get { return this.turno; }
            set { this.turno = value; }
        }
        public int Fichas
        {
            get { return this.fichas; }
            set { this.fichas = value; }
        }
    }
}
