using System;

namespace To_Do
{
	public class Interfaz
	{
		public Interfaz ()
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

			}while(n!=0);
			return n;
		}
	}
}

