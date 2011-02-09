/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 09/02/2011
 * Time: 16:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TDDMicroExercises.TurnTicketDispenser
{
	/// <summary>
	/// Description of LegacyTicketDispenser.
	/// </summary>
	public class LegacyTicketDispenser
	{

		 public TurnTicket GetTurnTicket()
        {
		 	int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();

               	
            TurnTicket newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
	}
}
