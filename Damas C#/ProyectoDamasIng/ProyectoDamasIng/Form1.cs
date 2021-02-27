using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDamasIng
{
    public partial class Form1 : Form
    {
        //LOS MESSAGEBOX COMENTADOS QUE SE DEJARON EN EL CÓDIGO FUERON UTILIZADOS PARA REALIZAR PRUEBAS Y ELIMNAR ERRORES
        //EN CASO DE QUERER OBTENER INFORMACIÓN DE LOS CAMBIOS QUE SE HACEN DESPUES DE CADA ACCIÓN PUEDE QUITARLOS COMO COMENTARIO
        

        //Variables para verificaciones de movimiento
        private Ficha PrimeraSeleccion = null;
        private Ficha SegundaSeleccion = null;
        private FichaNegra fichaNPrueba;
        private ReinaNegra ReinaNPrueba;
        private FichaBlanca fichaBPrueba;
        private ReinaBlanca ReinaBPrueba;
        private Ficha fichaCPrueba;
        private bool segundoClick;

        //Instancias de clases utilizadas
        private Tablero tablero;
        private Jugador jugador1;
        private Jugador jugador2;
        private Juego juego;

        //Matriz para los labels que conforman el tablero
        private Label[,] Labels;

        public Form1()
        {
            InitializeComponent();

            
            this.fichaNPrueba = new FichaNegra(0, 0);
            this.ReinaNPrueba = new ReinaNegra(0, 0);
            this.fichaBPrueba = new FichaBlanca(0, 0);
            this.ReinaBPrueba = new ReinaBlanca(0, 0);
            this.fichaCPrueba = new Ficha(0, 0);
            this.segundoClick = false;

            this.tablero = new Tablero();
            tablero.Inicio();
            this.jugador1 = new Jugador("Jugador 1", "negro");
            this.jugador2 = new Jugador("Jugador 2", "blanco");
            this.juego = new Juego(jugador1, jugador2);

            this.juego.Jugador1.Turno = true;
            this.juego.Jugador2.Turno = false;

            this.Labels = new Label[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Labels[i, j] = new Label();
                    Labels[i, j].Size = new Size(70, 70);
                    Labels[i, j].Click += Movimiento;
                    Labels[i, j].Location = new Point(50 + (j * 70), 50 + (i * 70));

                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Labels[i, j].BackColor = Color.White;
                    }
                    else if (i % 2 != 0 && j % 2 != 0)
                    {
                        Labels[i, j].BackColor = Color.White;
                    }
                    else
                    {
                        Labels[i, j].BackColor = Color.Black;
                    }
                }

            }

            //Actualizar tablero
            Actualizar();
            CambioTurno();



            foreach (Label label in Labels)
            {
                this.Controls.Add(label);
            }
        }
        public void Movimiento(object sender, EventArgs e)
        {
            if(PrimeraSeleccion != null)
            {
                //MessageBox.Show("PrimeraSelec x: " + PrimeraSeleccion.Fila + " y: " + PrimeraSeleccion.Columna);
            }
            //Si no se tiene primera seleccion
            if (this.PrimeraSeleccion == null)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (this.Labels[i, j] == sender)
                        {
                            //MessageBox.Show("x: " + i + " y: " + j);
                            if (this.tablero.Celdas[i, j].GetType() == this.fichaNPrueba.GetType() || this.tablero.Celdas[i, j].GetType() == this.fichaBPrueba.GetType() || this.tablero.Celdas[i, j].GetType() == this.ReinaBPrueba.GetType() || this.tablero.Celdas[i, j].GetType() == this.ReinaNPrueba.GetType())
                            {
                                //MessageBox.Show("x: " + i + " y: " + j + "tipo" + Convert.ToString(this.tablero.Celdas[i,j].GetType()));
                                foreach(Ficha posibleMov in this.tablero.Celdas[i,j].PosiblesMov())
                                {
                                    if (posibleMov != null)
                                    {
                                        
                                        PrimeraSeleccion = this.tablero.Celdas[i, j];
                                    }
                                    else
                                    {
                                        PrimeraSeleccion = null;
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
            //Si no tiene segunda seleccion
            else if(SegundaSeleccion == null)
            {
                this.segundoClick = true;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (this.Labels[i, j] == sender)
                        {

                            //MessageBox.Show("x: " + i + " y: " + j);
                            //Movimiento normal
                            if (this.tablero.Celdas[i, j].GetType() == this.fichaCPrueba.GetType())
                            {

                                //MessageBox.Show("x: " + i + " y: " + j + "tipo" + Convert.ToString(this.tablero.Celdas[i,j].GetType()));
                                this.SegundaSeleccion = this.tablero.Celdas[i, j];
                            }
                            else
                            {
                                this.PrimeraSeleccion = null;
                                this.SegundaSeleccion = null;
                            }
                        }
                    }
                }
            }
            //Si intenta moverse a una distancia de un espacio en diagonal
            if(PrimeraSeleccion != null && SegundaSeleccion != null)
            {
                //foreach (Ficha posibleMov in PrimeraSeleccion.PosiblesMov())
                foreach(Ficha posibleMov in this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna].PosiblesMov())
                {

                    if (SegundaSeleccion.Fila == posibleMov.Fila && SegundaSeleccion.Columna == posibleMov.Columna)
                    {
                        //MessageBox.Show("x: " + i + " y: " + j);
                        if (PrimeraSeleccion.GetType() == fichaNPrueba.GetType())
                        {
                            this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new FichaNegra(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                            this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                            this.PrimeraSeleccion = null;
                            this.SegundaSeleccion = null;
                            Actualizar();
                            CambioTurno();
                            break;
                        }
                        else if (PrimeraSeleccion.GetType() == fichaBPrueba.GetType())
                        {
                            this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new FichaBlanca(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                            this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                            this.PrimeraSeleccion = null;
                            this.SegundaSeleccion = null;
                            Actualizar();
                            CambioTurno();
                            break;
                        }
                        else if (PrimeraSeleccion.GetType() == ReinaNPrueba.GetType())
                        {
                            this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new ReinaNegra(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                            this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                            this.PrimeraSeleccion = null;
                            this.SegundaSeleccion = null;
                            Actualizar();
                            CambioTurno();
                            break;
                        }
                        else if (PrimeraSeleccion.GetType() == ReinaBPrueba.GetType())
                        {
                            this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new ReinaBlanca(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                            this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                            this.PrimeraSeleccion = null;
                            this.SegundaSeleccion = null;
                            Actualizar();
                            CambioTurno();
                            break;
                        }
                    }
                }
            }
            //Si se intenta COMER
            if (PrimeraSeleccion != null && SegundaSeleccion != null)
            {
                foreach (Ficha posibleComer in this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna].PosiblesComer())
                {
                    if (posibleComer != null)
                    {
                        if (SegundaSeleccion.Fila == posibleComer.Fila && SegundaSeleccion.Columna == posibleComer.Columna)
                        {
                            //MessageBox.Show("x: " + this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].Fila + "y: " + this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].Columna);
                            if (PrimeraSeleccion.GetType() == fichaNPrueba.GetType() || PrimeraSeleccion.GetType() == fichaBPrueba.GetType())
                            {
                                //MessageBox.Show("x: " + i + " y: " + j);
                                if (PrimeraSeleccion.GetType() == fichaNPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.fichaBPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new FichaNegra(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                                else if (PrimeraSeleccion.GetType() == fichaBPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.fichaNPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new FichaBlanca(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                                if (PrimeraSeleccion.GetType() == this.fichaNPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.ReinaBPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new FichaNegra(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                                else if (PrimeraSeleccion.GetType() == fichaBPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.ReinaNPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new FichaBlanca(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                            }
                            else if (PrimeraSeleccion.GetType() == ReinaNPrueba.GetType() || PrimeraSeleccion.GetType() == ReinaBPrueba.GetType())
                            {
                                if (PrimeraSeleccion.GetType() == ReinaNPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.fichaBPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new ReinaNegra(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                                else if (PrimeraSeleccion.GetType() == ReinaBPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.fichaNPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new ReinaBlanca(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }                    
                                if (PrimeraSeleccion.GetType() == ReinaNPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.ReinaBPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new ReinaNegra(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador2.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                                else if (PrimeraSeleccion.GetType() == ReinaBPrueba.GetType())
                                {
                                    if (this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)].GetType() == this.ReinaNPrueba.GetType())
                                    {
                                        this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna] = new ReinaBlanca(SegundaSeleccion.Fila, SegundaSeleccion.Columna);
                                        this.tablero.Celdas[PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2)] = new Ficha(PrimeraSeleccion.Fila + ((SegundaSeleccion.Fila - PrimeraSeleccion.Fila) / 2), PrimeraSeleccion.Columna + ((SegundaSeleccion.Columna - PrimeraSeleccion.Columna) / 2));
                                        this.tablero.Celdas[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna] = new Ficha(PrimeraSeleccion.Fila, PrimeraSeleccion.Columna);
                                        if (PuedeComer() == true)
                                        {
                                            this.PrimeraSeleccion = this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna];
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            break;
                                        }
                                        else
                                        {
                                            this.PrimeraSeleccion = null;
                                            this.SegundaSeleccion = null;
                                            this.juego.Jugador1.Fichas--;
                                            Actualizar();
                                            CambioTurno();
                                            break;
                                        }
                                    }

                                }
                            }
                           
                        }
                    }
                    else 
                    {
                        this.PrimeraSeleccion = null;
                        this.SegundaSeleccion = null;
                        Actualizar();
                    }
                }
            }
            if(segundoClick == true)
            { 
                this.PrimeraSeleccion = null;
                this.SegundaSeleccion = null;
                Actualizar();
                this.segundoClick = false;
            }

                //MessageBox.Show("x: " + PrimeraSeleccion.Fila + " y:" + PrimeraSeleccion.Columna);
            if(this.juego.Jugador1.Fichas == 0 || this.juego.Jugador2.Fichas == 0)
            {
                FinDelJuego();
            }
            if (this.PrimeraSeleccion != null)
            {
                //RESALTAR FICHA QUE FUE SELECCIONADA COMO LA PRIMERA SELECCIÓN.
                this.Labels[PrimeraSeleccion.Fila, PrimeraSeleccion.Columna].BackColor = Color.Yellow;
            }
        }
        
        public void Actualizar()
        {
            //SE CAMBIAN LOS COLORES DE CADA CELDA A LOS APROPIADOS
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Labels[i, j].BackColor = Color.White;
                    }
                    else if (i % 2 != 0 && j % 2 != 0)
                    {
                        Labels[i, j].BackColor = Color.White;
                    }
                    else
                    {
                        Labels[i, j].BackColor = Color.Black;
                    }
                }
            }
            //FOR PARA CAMBIAR FICHAS NEGRAS Y BLANCAS A REINAS.
            for (int i = 0; i < 8; i++)
            {
                if (this.tablero.Celdas[0,i].GetType() == this.fichaBPrueba.GetType())
                {
                    this.tablero.Celdas[0, i] = new ReinaBlanca(0, i);
                }
                if(this.tablero.Celdas[7,i].GetType() == this.fichaNPrueba.GetType())
                {
                    this.tablero.Celdas[7, i] = new ReinaNegra(7, i);
                }
            }
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this.tablero.Celdas[i, j].GetType() == this.fichaNPrueba.GetType())
                    {
                        this.Labels[i, j].Image = ProyectoDamasIng.Properties.Resources.BlackChecker;
                    }
                    else if (this.tablero.Celdas[i, j].GetType() == this.fichaBPrueba.GetType())
                    {

                        this.Labels[i, j].Image = ProyectoDamasIng.Properties.Resources.WhiteChecker;
                    }
                    else if(this.tablero.Celdas[i,j].GetType() == this.ReinaNPrueba.GetType())
                    {
                        this.Labels[i, j].Image = ProyectoDamasIng.Properties.Resources.BlackKing;
                    }
                    else if (this.tablero.Celdas[i, j].GetType() == this.ReinaBPrueba.GetType())
                    {
                        this.Labels[i, j].Image = ProyectoDamasIng.Properties.Resources.WhiteKing;
                    }
                    else
                    {
                        this.Labels[i, j].Image = null;
                    }
                }
            }
        }

        private void CambioTurno()
        {
            //Se habilitan todos los controles
            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
            
            //Si es el turno del jugador de fichas negras se deshabilitan las fichas blancas
            if (this.juego.Jugador1.Turno == true)
            {
                foreach (Ficha celda in this.tablero.Celdas)
                {
                    if(celda.GetType() == this.fichaBPrueba.GetType() || celda.GetType() == this.ReinaBPrueba.GetType())
                    {
                        this.Labels[celda.Fila, celda.Columna].Enabled = false;
                        //this.Labels[celda.Fila, celda.Columna].BackColor = Color.Blue;
                    }
                }
                this.juego.Jugador1.Turno = false;
                this.label1.Text = "Turno de: " + this.juego.Jugador1.Nombre;
                this.btnTurno.BackColor = Color.Black;
            }
            //Si es el turno del jugador de fichas blancas se deshabilitan las fichas negras
            else
            {
                foreach (Ficha celda in this.tablero.Celdas)
                {
                    if (celda.GetType() == this.fichaNPrueba.GetType() || celda.GetType() == this.ReinaNPrueba.GetType())
                    {
                        this.Labels[celda.Fila, celda.Columna].Enabled = false;
                        //this.Labels[celda.Fila, celda.Columna].BackColor = Color.Yellow;
                    }
                    this.juego.Jugador1.Turno = true;
                    this.label1.Text = "Turno de: " + this.juego.Jugador2.Nombre;
                    this.btnTurno.BackColor = Color.White;
                }
            }

            
        }
        public void FinDelJuego()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = false;
            }
            if (this.juego.Jugador1.Fichas == 0)
            {
                MessageBox.Show("FIN DEL JUEGO. EL GANADOR ES EL JUGADOR DE LAS FICHAS DE COLOR " + this.juego.Jugador2.Color); 
            }
            else if (this.juego.Jugador2.Fichas == 0)
            {
                MessageBox.Show("FIN DEL JUEGO. EL GANADOR ES EL JUGADOR DE LAS FICHAS DE COLOR " + this.juego.Jugador1.Color);
            }
            this.btnReiniciar.Enabled = true;
            this.btnReiniciar.Visible = true;
            this.btnSalir.Enabled = true;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private bool PuedeComer()
        {
            bool resultado = false;
            
            foreach(Ficha posibleComer in this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna].PosiblesComer())
            {
                if(posibleComer.GetType() == this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna].GetType())
                {
                    //MessageBox.Show("Puede comer x: " + posibleComer.Fila + " y: " + posibleComer.Columna);

                    if (this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna].GetType() == this.fichaNPrueba.GetType())
                    {
                        
                        if (this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.fichaBPrueba.GetType() || this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.ReinaBPrueba.GetType())
                        {
                            resultado = true;
                        }
                    }
                    if (this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna].GetType() == this.fichaBPrueba.GetType())
                    {
                        
                        if (this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.fichaNPrueba.GetType() || this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.ReinaNPrueba.GetType())
                        {
                            resultado = true;
                        }
                    }
                    if (this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna].GetType() == this.ReinaNPrueba.GetType())
                    {
                        
                        if (this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.fichaBPrueba.GetType() || this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.ReinaBPrueba.GetType())
                        {
                            resultado = true;
                        }
                    }
                    if (this.tablero.Celdas[SegundaSeleccion.Fila, SegundaSeleccion.Columna].GetType() == this.ReinaBPrueba.GetType())
                    {
                        
                        if (this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.fichaNPrueba.GetType() || this.tablero.Celdas[SegundaSeleccion.Fila + ((posibleComer.Fila - SegundaSeleccion.Fila) / 2), SegundaSeleccion.Columna + ((posibleComer.Columna - SegundaSeleccion.Columna) / 2)].GetType() == this.ReinaNPrueba.GetType())
                        {
                            resultado = true;
                        }
                    }
                   
                }
               
            }
            return resultado;
            
        }
    }
}
