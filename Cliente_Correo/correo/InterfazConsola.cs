using System;

namespace correo
{
	public class InterfazConsola
	{
		public InterfazConsola ()
		{
		}

		public int Menu_Principal(){
			int n;
			do{
				System.Console.WriteLine("Menu de prueba");
				System.Console.WriteLine("1_Introducir Tarea");
				System.Console.WriteLine("2_Borrar Tarea");
				System.Console.WriteLine("3_Listar Tareas");
				n= Convert.ToInt32 (Console.ReadLine());

			}while(n<0 || n>3);

			return n;
		}

		public int Borrar(Lista_Tareas l){
			int aux;
			l.toString();
			do{
			System.Console.WriteLine ("Cual quieres borrar?");
				aux=Convert.ToInt32 (Console.ReadLine ());
			}while(aux<0 || aux>l.Tamaño());
				return aux;
		}
	}
}

