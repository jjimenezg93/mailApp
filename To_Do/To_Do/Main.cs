using System;

namespace To_Do
{
	class MainClass
	{
		public static void Main (string[] args)
		{


			Lista_Tareas l=new Lista_Tareas();

			int n;

			do{
			n = Interfaz.Menu_Principal();
			switch (n) {
			case 1:
				Tarea t=new Tarea();
				l.Anadir(t);
				break;

			case 2:
					//Mandar a su sitio
				System.Console.WriteLine ("Cual quieres borrar?");
				l.Borrar (Convert.ToInt32 (Console.ReadLine ()));
				break;
			
			case 3:
				l.toString();
				break;
			}
			}while(n!=0);
			}
		}
	}
