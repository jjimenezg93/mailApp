using System;
using System.Collections.Generic;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using OpenPop.Common.Logging;
using System.Windows.Forms;

namespace correo
{
	class Principal
	{	
		public static void Main (string[] args)
		{
			var mw =new MainWindow();
			Application.Run (mw);
		}
		public static void Texto (string[] args)
		{	

			string servidor;
			string usuario;
			string pass;
		
			Console.Write("Introduzca el servidor de correo: ");
			servidor=Console.ReadLine ();

			Console.Write("Introduzca su usuario: ");
			usuario=Console.ReadLine ();

			Console.Write("Introduzca su contraseña: ");
			pass=Console.ReadLine ();

			Console.Clear ();
			Console.WriteLine ("Cargando Mensajes");

			List<OpenPop.Mime.Message> mensajes =FetchAllMessages (servidor, 995, true, usuario, pass);


		}
		public static List<OpenPop.Mime.Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
		{
			// The client disconnects from the server when being disposed
			using(Pop3Client client = new Pop3Client())
			{
				// Connect to the server
				client.Connect(hostname, port, useSsl);

				// Authenticate ourselves towards the server
				client.Authenticate(username, password);

				// Get the number of messages in the inbox
				int messageCount = client.GetMessageCount();

				// We want to download all messages
				List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

				// Messages are numbered in the interval: [1, messageCount]
				// Ergo: message numbers are 1-based.
				// Most servers give the latest message the highest number

				for (int i = 6; i > 0; i--)
				{
					allMessages.Add(client.GetMessage(i));
				}

				/*
				Console.WriteLine ("Tienes " + allMessages.Count + "mensajes");


				string tecla = "";
				int numero=0;
				OpenPop.Mime.Message mensaje;
				while (tecla != "q") {
					Console.Write("Introduzca el numero del mensaje que desea leer [0-"+allMessages.Count+"] (q para salir):  ");
					tecla=Console.ReadLine ();
					if (tecla == "q")
						Console.WriteLine ("Salir");
					else {
						numero=Convert.ToInt16 (tecla);
						mensaje = allMessages[numero];
						MessagePart plainTextPart = mensaje.FindFirstPlainTextVersion();
						if (plainTextPart != null)
						{
							// The message had a text/plain version - show that one
							Console.WriteLine(plainTextPart.GetBodyAsText());
						} else {
							Console.WriteLine ("Este mensaje no tiene version de texto");
						}


					}

				}*/
				// Now return the fetched messages
				return allMessages;
			}
		}


	}
}
