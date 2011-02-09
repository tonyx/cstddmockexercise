/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 09/02/2011
 * Time: 00:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TDDMicroExercises.TelemetrySystem
{
	/// <summary>
	/// Description of ITelemetryClient.
	/// </summary>
	public interface ITelemetryClient
	{
		void Connect(String connectionString);
		bool OnlineStatus {get;}
		void Disconnect();
		void Send(String message);
		string Receive();
				
	}
}
