using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace correo
{
	public class Xmlr
	{
		public const string ArchivoXml = "tareas.xml";
		private Lista_Tareas tareas;

		public const string EtqTareas = "tareas";
		public const string EtqTarea = "tarea";
		public const string EtqNombre = "Nombre";
		public const string EtqFecha = "Fecha";
		public const string EtqDescripcion = "Descripcion";


		public Xmlr ()
		{

			this.tareas=new Lista_Tareas();
		}
		public Lista_Tareas getTareas ()
		{
			return tareas;
		}

		public void Actualizar (Lista_Tareas ts)
		{
			this.tareas=ts;
		}

		public void GuardaXml()
		{
			this.GuardaXml( ArchivoXml );
		}

		public void GuardaXml(string f)
		{
			var writer = new XmlTextWriter( f, Encoding.UTF8 );
			writer.WriteStartDocument();

			writer.WriteStartElement( EtqTareas );

			for(int i=0;i<this.tareas.Tamaño();i++) {
				Tarea t=this.tareas.Recibir(i);
				writer.WriteStartElement( EtqTarea );

				writer.WriteStartElement( EtqNombre );
				writer.WriteString( t.Nombre );
				writer.WriteEndElement();

				writer.WriteStartElement( EtqFecha );
				writer.WriteString( Convert.ToString(t.Fecha) );
				writer.WriteEndElement();

				writer.WriteStartElement( EtqDescripcion );
				writer.WriteString( t.Descripcion );
				writer.WriteEndElement();

				writer.WriteEndElement();
			}

			writer.WriteEndElement();

			writer.WriteEndDocument();
			writer.Close();
		}

		public void Add(Tarea t)
		{
			this.tareas.Anadir( t );
		}

		public void RemoveAt(int i)
		{
			this.tareas.Borrar( i );
		}


		public int Count {
			get { return this.tareas.Tamaño(); }
		}

		public void RecuperaXml()
		{

			var toret = new Lista_Tareas();
			var docXml = new XmlDocument( );

			try {
				docXml.Load( ArchivoXml );

				if ( docXml.DocumentElement.Name == EtqTareas ) {
					string nombre = "";
					string fecha = "";
					string descripcion="";

					foreach(XmlNode nodo in docXml.DocumentElement.ChildNodes) {
						if ( nodo.Name == EtqTarea ) {

							// Recorrer los nodos interiores: inicio, destino
							foreach(XmlNode subNodo in nodo.ChildNodes) {
								if ( subNodo.Name == EtqNombre ) {
									nombre = subNodo.InnerText;
								}
								else if ( subNodo.Name == EtqFecha ) {
									fecha = subNodo.InnerText;
								}else {
									descripcion=subNodo.InnerText;
								}
							}

							nombre = nombre.Trim();
							fecha = fecha.Trim();
							if ( nombre.Length > 0
							    && fecha.Length > 0)
							{
								toret.Anadir( new Tarea( Convert.ToDateTime(fecha), nombre,descripcion ) );
							}
						}
					}
				}
			}
			catch(XmlException)
			{
				toret=new Lista_Tareas();
			}
			catch(IOException)
			{
				toret=new Lista_Tareas();
			}

			this.tareas=toret;
		}


	}
}

