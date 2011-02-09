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
        	// old legacy clients will still use ITurnNumberSequence.GetNextTurnNumber()
               	
            TurnTicket newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
