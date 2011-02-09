/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 09/02/2011
 * Time: 02:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
	[TestFixture]
	public class TurnTicketDispenserTest
	{


		[Test]
		public void TestTicketDispenser()
		{
			MockRepository mocks = new MockRepository();
		
			ITurnNumberSequence sequence = mocks.StrictMock<ITurnNumberSequence>();
			Expect.Call(sequence.GetNextNumber()).Return(0);
			Expect.Call(sequence.GetNextNumber()).Return(1);
			
			TurnNumberSequence.Instance=sequence;
			
			mocks.ReplayAll();
									
			TicketDispenser ticketDispenser = new TicketDispenser(TurnNumberSequence.Instance);
			
			TurnTicket first = new TurnTicket(0);
			TurnTicket second = new TurnTicket(1);
			
			Assert.AreEqual(first,ticketDispenser.GetTurnTicket());
			Assert.AreEqual(second,ticketDispenser.GetTurnTicket());
			
			mocks.VerifyAll();
						
		}
		
		
		[Test]
		public void TestTicketDispenserHighNumbers()
		{
			MockRepository mocks = new MockRepository();
		
			ITurnNumberSequence sequence = mocks.StrictMock<ITurnNumberSequence>();
			Expect.Call(sequence.GetNextNumber()).Return(999999);
			Expect.Call(sequence.GetNextNumber()).Return(1000000);
			
			TurnNumberSequence.Instance=sequence;
			
			mocks.ReplayAll();
									
			TicketDispenser ticketDispenser = new TicketDispenser(TurnNumberSequence.Instance);
			
			TurnTicket first = new TurnTicket(999999);
			TurnTicket second = new TurnTicket(1000000);
			
			Assert.AreEqual(first,ticketDispenser.GetTurnTicket());
			Assert.AreEqual(second,ticketDispenser.GetTurnTicket());
			
			mocks.VerifyAll();
						
		}
		
		
	}
}
