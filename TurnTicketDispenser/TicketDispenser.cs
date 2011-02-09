using System;
using System.Reflection;
using TDDMicroExercises.TurnTicketDispenser;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
    	ITurnNumberSequence _turnNumbersequence;
    	
    	public TicketDispenser(ITurnNumberSequence turnNumberSequence) 
    	{
    		_turnNumbersequence=turnNumberSequence;    		
    	}

    	
    	
        public TurnTicket GetTurnTicket()
        {
        	int newTurnNumber= _turnNumbersequence.GetNextNumber();
               	
            TurnTicket newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
