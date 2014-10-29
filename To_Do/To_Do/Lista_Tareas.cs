using System;
using System.Collections.Generic;

namespace To_Do
{
	public class Lista_Tareas
	{
		public Lista_Tareas()
		{
		}
		public void Anadir(Tarea t){
			lista.Add(t);
		}
		public void Borrar (int p)
		{
			lista.RemoveAt(p);
		}
		public Tarea Recibir (int p)
		{
			return lista[p];
		}
		public void toString ()
		{
			foreach (Tarea tareilla in lista) {
				System.Console.WriteLine(tareilla.toString());
			}
		}

	public List<Tarea> lista{get;set;}

	}}

