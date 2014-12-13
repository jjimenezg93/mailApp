using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace correo
{
	public class Contactos:ICollection<Contacto>
	{
		public const string ArchivoXml = "contactos.xml";
		public const string EtqContactos = "contactos";
		public const string EtqContacto = "contacto";
		public const string EtqNombre = "Nombre";
		public const string EtqEmail = "Email";
		public const string EtqCategoria = "Categoria";
		public const string EtqDescripcion = "Descripcion";

		public Contactos ()
		{
			contactos = new List<Contacto> ();
		}



		public void GuardaXml()
		{
			this.GuardaXml( ArchivoXml );
		}

		public void GuardaXml(string f)
		{
			var writer = new XmlTextWriter( f, Encoding.UTF8 );
			writer.WriteStartDocument();

			writer.WriteStartElement( EtqContactos );

			foreach(var c in this.contactos) {
				writer.WriteStartElement( EtqContacto );

				writer.WriteStartElement( EtqNombre );
				writer.WriteString( c.Nombre );
				writer.WriteEndElement();

				writer.WriteStartElement( EtqEmail );
				writer.WriteString( c.Email );
				writer.WriteEndElement();

				writer.WriteStartElement( EtqCategoria );
				writer.WriteString( c.Categoria );
				writer.WriteEndElement();

				writer.WriteStartElement( EtqDescripcion );
				writer.WriteString( c.Descripcion );
				writer.WriteEndElement();

				writer.WriteEndElement();
			}

			writer.WriteEndElement();

			writer.WriteEndDocument();
			writer.Close();
		}

		public void Add(Contacto c)
		{
			this.contactos.Add( c );
		}

		public bool Remove(Contacto c)
		{
			return this.contactos.Remove( c );
		}

		public void RemoveAt(int i)
		{
			this.contactos.RemoveAt( i );
		}

		public void AddRange(ICollection<Contacto> c)
		{
			this.contactos.AddRange( c );
		}

		public int Count {
			get { return this.contactos.Count; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public void Clear()
		{
			this.contactos.Clear();
		}

		public bool Contains(Contacto c)
		{
			return this.contactos.Contains( c );
		}

		public void CopyTo(Contacto[] v, int i)
		{
			this.contactos.CopyTo( v, i );
		}

		// Enumerador genérico
		IEnumerator<Contacto> IEnumerable<Contacto>.GetEnumerator()
		{
		foreach(var r in this.contactos) {
				yield return r;
			}
		}

		//Enumerador básico
		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach(var r in this.contactos) {
				yield return r;
			}
		}

		// Indizador
		public Contacto this[int i] {
			get { return this.contactos[ i ]; }
			set { this.contactos[ i ] = value; }
		}

		public override string ToString()
		{
			var toret = new StringBuilder();

			foreach(var r in this.contactos) {
				toret.AppendLine( r.ToString() );
			}

			return toret.ToString();
		}

		public static Contacto[] RecuperaXml(string f)
		{
			var toret = new List<Contacto>();
			var docXml = new XmlDocument( );

			try {
				docXml.Load( ArchivoXml );

				if ( docXml.DocumentElement.Name == EtqContactos ) {
					string nombre = "";
					string email = "";
					string categoria= "";
					string descripcion="";

					foreach(XmlNode nodo in docXml.DocumentElement.ChildNodes) {
						if ( nodo.Name == EtqContacto ) {

							// Recorrer los nodos interiores: inicio, destino
							foreach(XmlNode subNodo in nodo.ChildNodes) {
								if ( subNodo.Name == EtqNombre ) {
									nombre = subNodo.InnerText;
								}
								else if ( subNodo.Name == EtqEmail ) {
									email = subNodo.InnerText;
								}else if (subNodo.Name == EtqCategoria){
									categoria=subNodo.InnerText;
								}else{
									descripcion=subNodo.InnerText;
								}
							}

							nombre = nombre.Trim();
							email = email.Trim();
							categoria = categoria.Trim();
							if ( nombre.Length > 0
							    && email.Length > 0)
							{
								toret.Add( new Contacto( nombre, email, categoria,descripcion ) );
							}
						}
					}
				}
			}
			catch(XmlException)
			{
				toret.Clear();
			}
			catch(IOException)
			{
				toret.Clear();
			}

			return toret.ToArray();
		}

		public static Contactos Crea()
		{
			var toret = new Contactos();
			Contacto[] contactos = RecuperaXml( ArchivoXml );

			toret.AddRange( contactos );
			return toret;
		}

		public string GetDescripcion (int i){
			if (i < this.contactos.Count) {
				return this.contactos [i].Descripcion;
			}
			return "";
		}

		private List<Contacto> contactos;
	}
}

