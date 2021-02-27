using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProyectoDamasIng
{
    
    static public class Program
    {
        //public static object PrimeraSeleccion = null;
        //public static object SegundaSeleccion = null;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            //FichaNegra fichaNPrueba = new FichaNegra(0, 0);
            //FichaBlanca fichaBPrueba = new FichaBlanca(0, 0);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);



            //Tablero tableroInicio = new Tablero();
            //tableroInicio.Inicio();
            //Jugador jugador1 = new Jugador("Jugador 1", "negro");
            //Jugador jugador2 = new Jugador("Jugador 2", "blanco");
            //Juego juego = new Juego(jugador1, jugador2);

            //Label[,] Labels = new Label[8, 8];
            //for(int i = 0; i < 8; i++)
            //{
            //    for(int j = 0; j < 8; j++)
            //    {
            //        Labels[i, j] = new Label();
            //        Labels[i, j].Size = new Size(70, 70);
            //        Labels[i, j].Click += Movimiento;
            //        Labels[i, j].Location = new Point(50 + (j * 70), 50 + (i * 70));
                    
            //        if (i % 2 == 0 && j % 2 == 0)
            //        {
            //            Labels[i, j].BackColor = Color.White;
            //        }
            //        else if(i % 2 != 0 && j % 2 != 0)
            //        {
            //            Labels[i, j].BackColor = Color.White;
            //        }
            //        else
            //        {
            //            Labels[i, j].BackColor = Color.Black;
            //        }
            //    }

            //}

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        if (tableroInicio.Celdas[i, j].Color == "negro")
            //        {
            //            Labels[i, j].Image = ProyectoDamasIng.Properties.Resources.BlackChecker;
            //        }
            //        else if (tableroInicio.Celdas[i, j].Color == "blanco")
            //        {

            //            Labels[i, j].Image = ProyectoDamasIng.Properties.Resources.WhiteChecker;
            //        }
            //        else
            //        {

            //        }
            //    }
            //}

            //Form form1 = new Form1();
            
            //foreach (Label label in Labels)
            //{
            //    form1.Controls.Add(label);
            //}

            
            Application.Run(new Form1());
        }
        //static void Movimiento(object sender, EventArgs e)
        //{

        //    if(PrimeraSeleccion == null)
        //    {

        //    }
        //}
    }
}
