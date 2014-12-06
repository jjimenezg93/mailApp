using System;

namespace To_Do
{
	public class Tarea
	{
		public Tarea (DateTime f,string n,string d)
		{
			fecha=f;
			nombre=n;
			descripcion=d;
		}
		public string toString ()
		{
			string aux;
			aux="Nombre:" + nombre+"\nFecha"+fecha+"\nDescripccion:\n"+descripcion;
			return aux;
		}
		//Cambiar tipo de dato si es necesario
		public DateTime fecha{get;set;}
		public string nombre{get;set;}
		public string descripcion{get;set;}


	}
}

