using System;

namespace correo
{
	public class Tarea
	{
		public Tarea (DateTime f,string n,string d)
		{
			Fecha=f;
			Nombre=n;
			Descripcion=d;
		}
		public string toString ()
		{
			string aux;
			aux="Nombre:" + Nombre+"\nFecha"+Fecha+"\nDescripccion:\n"+Descripcion;
			return aux;
		}
		//Cambiar tipo de dato si es necesario
		public DateTime Fecha{get;set;}
		public string Nombre{get;set;}
		public string Descripcion{get;set;}


	}
}

