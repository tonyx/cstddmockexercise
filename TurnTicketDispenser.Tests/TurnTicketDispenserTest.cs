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
			
			mocks.ReplayAll();
									
			TicketDispenser ticketDispenser = new TicketDispenser(sequence);
			
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
			
			mocks.ReplayAll();
									
			TicketDispenser ticketDispenser = new TicketDispenser(sequence);
			
			TurnTicket first = new TurnTicket(999999);
			TurnTicket second = new TurnTicket(1000000);
			
			Assert.AreEqual(first,ticketDispenser.GetTurnTicket());
			Assert.AreEqual(second,ticketDispenser.GetTurnTicket());
			
			mocks.VerifyAll();						
		}
		
		
		[Test]
		public void TestLegacyTickeTispensers()
		{
			MockRepository mocks = new MockRepository();
		
			ITurnNumberSequence sequence = mocks.StrictMock<ITurnNumberSequence>();
			Expect.Call(sequence.GetNextNumber()).Return(0);
			Expect.Call(sequence.GetNextNumber()).Return(1);			
			TurnNumberSequence.Instance=sequence;
			
			mocks.ReplayAll();
									
			LegacyTicketDispenser ticketDispenser = new LegacyTicketDispenser();
			
			TurnTicket first = new TurnTicket(0);
			TurnTicket second = new TurnTicket(1);
			
			Assert.AreEqual(first,ticketDispenser.GetTurnTicket());
			Assert.AreEqual(second,ticketDispenser.GetTurnTicket());
			
			mocks.VerifyAll();
						
		}		
		
		
		[Test]
		public void ShuldBeableToUseConsistentlyLegacyAndNonLegacyDispenserUsingSameSequence()
		{
			MockRepository mocks = new MockRepository();
		
			ITurnNumberSequence sequence = mocks.StrictMock<ITurnNumberSequence>();
			Expect.Call(sequence.GetNextNumber()).Return(0);
			Expect.Call(sequence.GetNextNumber()).Return(1);			
			TurnNumberSequence.Instance=sequence;
			
			mocks.ReplayAll();
									
			LegacyTicketDispenser legacyticketDispenser = new LegacyTicketDispenser();
			TicketDispenser ticketDispenser = new TicketDispenser(TurnNumberSequence.Instance);
			
			TurnTicket first = new TurnTicket(0);
			TurnTicket second = new TurnTicket(1);
			
			Assert.AreEqual(first,ticketDispenser.GetTurnTicket());
			Assert.AreEqual(second,legacyticketDispenser.GetTurnTicket());
			
			mocks.VerifyAll();
						
		}	
		
		
		
	}
}
