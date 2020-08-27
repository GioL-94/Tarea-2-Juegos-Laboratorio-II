using System;
using System.ComponentModel.Design;
using System.Threading; 

namespace Clase6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo Tecla;
            int x = 40, y = 12;
            int xo1 = 20, yo1 = 15;
            int xo2 = 25, yo2 = 5;
            int xo3 = 62, yo3 = 21;
            int xe1 = 10, ye1 = 15;//enemigo
            int xe2 = 20, ye2 = 10;
            int fin = 0;
            int incr1 = 1;
            int incr2 = 1;
            int[] xpremio = new int[10];
            int[] ypremio = new int[10];
            Random generador =new Random();
            int puntos = 0;
            for(int i = 0; i < 10; i++)
            {
                xpremio[i] = generador.Next(0, 79);
                ypremio[i] = generador.Next(0, 24);
            }
                
            while (fin == 0)
            {
                //Dibujar Pantalla
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("A");
                Console.SetCursorPosition(xo1, yo1); // Obstáculos
                Console.Write("o");
                Console.SetCursorPosition(xo2, yo2);
                Console.Write("o");
                Console.SetCursorPosition(xo3, yo3);
                Console.Write("o");
                Console.SetCursorPosition(xe1, ye1); // Enemigo
                Console.Write("@");
                Console.SetCursorPosition(xe2, ye2); // Enemigo
                Console.Write("*");
                for(int i = 0; i<10; i++)
                {
                    if((xpremio[i] > 0) && (ypremio[i] > 0))
                    {
                        Console.SetCursorPosition(xpremio[i], ypremio[i]);
                        Console.Write("x");
                    }
                }


                if(xe1 < x) 
                {
                    xe1 = xe1 + incr1;
                }
                else
                {
                    xe1 = xe1 - incr1;
                }
                    
                if (ye1 < y)
                {
                    ye1 = ye1 + incr1;
                }                               //Estas comparaciones son para que los enemigos persigan al jugador.
                else
                {
                    ye1 = ye1 - incr1;
                }
                if(xe2 < x)
                {
                    xe2 = xe2 + incr2;
                }
                else
                {
                    ye2 = ye2 + incr2;
                }

                Tecla = Console.ReadKey(false);
                    if (Tecla.Key == ConsoleKey.RightArrow) x++;
                    if (Tecla.Key == ConsoleKey.LeftArrow) x--;
                    if (Tecla.Key == ConsoleKey.DownArrow) y++;
                    if (Tecla.Key == ConsoleKey.UpArrow) y--;
                
                if ((xe1 == 0) || (xe1 == 79))
                    incr1 = -incr1;
                if ((xe2 == 0) || (xe2 == 79))
                    incr2 = -incr2;
                if((ye1 == 0) || (ye1 == 79))
                    incr1 = -incr1;
                if((ye2 == 0) || (ye2 == 79))
                    incr2 = -incr2;

                for (int i = 0; i < 10; i++)
                {
                    if((x == xpremio[i]))
                    {
                        puntos = +xpremio[i]; //Aquí se eliminan los premios de la vista cuando son recogidos.
                        xpremio[i] = 0;
                    }

                    if((x == ypremio[i]))
                    {
                        puntos = +ypremio[i];
                        ypremio[i] = 0;
                    }
                }


                if (x == xe1 || x == xe2)
                    puntos = puntos - 10; // Aquí resto puntos cuando el jugador choque con alugno de los enemigos
                if (y == ye1 || y == ye2)
                    puntos = puntos - 15;

                if (((x == xo1) && (y == yo1))

                || ((x == xo2) && (y == yo2))

                || ((x == xo3) && (y == yo3))

                )
                {
                    fin = 1;

                    Console.Write("Game Over");

                    Console.Write("");

                    Console.WriteLine(" Tus puntos: {0}", puntos);
                }


            }
            Thread.Sleep(40);
        }
    }
}
