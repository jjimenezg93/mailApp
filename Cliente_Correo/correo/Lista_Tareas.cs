using System;
using System.Collections.Generic;

namespace correo
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
		public Tarea pop ()
		{
			Tarea a;
			a=lista[lista.Count-1];
			lista.RemoveAt(lista.Count-1);
			return a;
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
			this.lista.Sort((a, b) => a.Fecha.CompareTo(b.Fecha));

		}

		private void SortDescending()
		{
			this.lista.Sort((a, b) => b.Fecha.CompareTo(a.Fecha));

		}
	public List<Tarea> lista{get;set;}

	}}

