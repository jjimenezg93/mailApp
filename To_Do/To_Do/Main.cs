using System;
using System.Windows.Forms;

namespace To_Do
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Lista_Tareas l=new Lista_Tareas();


			//InterfazConsola faz=new InterfazConsola();

			var f = new InterfazVisual(l);
			Application.Run( f );

			/*int n=0;
			do{
			n=faz.Menu_Principal();

			switch (n) {
			case 1:

				Tarea t=new Tarea(8,"jose","desc");
				l.Anadir(t);
				break;

			case 2:
					//Mandar a su sitio
				
					l.Borrar (faz.Borrar(l));
					System.Console.WriteLine ("C");
					break;
			
			case 3:
				l.toString();
				break;
			}

			}while(n!=0);*/
		}
		}
	}
