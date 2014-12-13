using System;

namespace correo
{
	public class Contacto
	{
		private string nombre;
		private string email;
		private string categoria;
		private string descripcion;

		public Contacto (string n, string e, string c, string d)
		{
			categoria = c;
			nombre = n;
			email = e;
			descripcion = d;
		}


		public string Email {
			get{ return email;}
			set{ email = value;}
		}


		public string Nombre{
			get{ return nombre;}
			set{ nombre = value;}
		}

		public string Categoria{
			get{ return categoria;}
			set{ categoria = value;}
		}

		public string Descripcion{
			get{ return descripcion;}
			set{ descripcion = value;}
		}




	}
}

