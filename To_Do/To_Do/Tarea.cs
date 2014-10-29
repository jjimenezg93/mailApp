using System;

namespace To_Do
{
	public class Tarea
	{
		public Tarea (int f,string n,string d)
		{
			fecha=f;
			nombre=n;
			descripcion=d;
		}
		public Tarea ()
		{
			System.Console.WriteLine ("Nombre de la tarea");
			nombre= Console.ReadLine ();

			System.Console.WriteLine ("Fecha de la tarea");
			fecha= (Convert.ToInt32 (Console.ReadLine ()));

			System.Console.WriteLine ("Descripcion de la tarea");
			descripcion=Console.ReadLine ();
		}
		public string toString ()
		{
			string aux;
			aux="Nombre: " + nombre+"\nFecha: "+fecha+"\nDescripccion:\n"+descripcion;
			return aux;
		}
		//Cambiar tipo de dato si es necesario
		public int fecha{get;set;}
		public string nombre{get;set;}
		public string descripcion{get;set;}


	}
}

