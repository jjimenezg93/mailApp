using System;
using System.Collections.Generic;

namespace To_Do
{
	public class Lista_Tareas
	{
		public Lista_Tareas()
		{lista = new List<Tarea> ();
		}
		public void Anadir(Tarea t){

			lista.Add(t);
			SortAscending ();
		}
		public void Borrar (int p)
		{
			lista.RemoveAt(p);
			SortAscending ();

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
		public int Tamaño(){
			return lista.Count;
		}

		private void SortAscending()
		{
			this.lista.Sort((a, b) => a.fecha.CompareTo(b.fecha));

		}

		private void SortDescending()
		{
			this.lista.Sort((a, b) => b.fecha.CompareTo(a.fecha));

		}
	public List<Tarea> lista{get;set;}

	}}

