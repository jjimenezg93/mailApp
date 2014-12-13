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
		[STAThread]
		public static void Main (string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var mw =new MainWindow();
			Application.Run (mw);
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
			
				return allMessages;
			}
		}


	}
}
