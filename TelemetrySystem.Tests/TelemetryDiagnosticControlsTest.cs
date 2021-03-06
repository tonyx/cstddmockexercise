using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;
using TDDMicroExercises.TelemetrySystem;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
	
	[TestFixture]
	public class TelemetryDiagnosticControlsTest
	{
		
		[Test]
		public void TestConnectionAlreadyOk()
		{
			MockRepository mocks = new MockRepository();
			ITelemetryClient client = mocks.StrictMock<ITelemetryClient>();

			Expect.Call(delegate{client.Disconnect();});
			
			Expect.Call(client.OnlineStatus).Return(true).Repeat.Twice();
			
			Expect.Call(delegate{client.Send("AT#UD");});
			Expect.Call(client.Receive()).Return("ok");

			mocks.ReplayAll();
			
			TelemetryDiagnosticControls target = new TelemetryDiagnosticControls(client);
			target.CheckTransmission();
			Assert.AreEqual("ok",target.DiagnosticInfo);
			
			mocks.VerifyAll();
			
		}
		
		
		
		[Test]
		[ExpectedException(typeof(System.Exception),ExpectedMessage="Unable to connect.")]
		public void AfterThreeConnectionTriesWillNotAbleToConnect()
		{
			MockRepository mocks = new MockRepository();
			ITelemetryClient client = mocks.StrictMock<ITelemetryClient>();

			Expect.Call(delegate{client.Disconnect();});
			Expect.Call(delegate{client.Connect("*111#");}).Repeat.Times(4);
			Expect.Call(client.OnlineStatus).Return(false).Repeat.Times(5);		
			mocks.ReplayAll();
			
			TelemetryDiagnosticControls target = new TelemetryDiagnosticControls(client);

			target.CheckTransmission();
		}
							
	}
}
