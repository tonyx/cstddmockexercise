#define TEST

using System;
using System.Runtime.CompilerServices;


namespace TDDMicroExercises.TurnTicketDispenser
{
	public class TurnNumberSequence : ITurnNumberSequence
    {    	
		private int _turnNumber = 0;
		private static ITurnNumberSequence _instance = null;
				
	    #if TEST	    
		public static ITurnNumberSequence Instance {
			set {
				_instance = value;
			}	 
			[MethodImpl(MethodImplOptions.Synchronized)]	    	
	    	get {
				if (_instance==null)
				{
					_instance = new TurnNumberSequence();
				}
				return _instance;	
	    	}
		}
	    
		#else
		private static ITurnNumberSequence Instance {
			[MethodImpl(MethodImplOptions.Synchronized)]	 			
	    	get {				
				if (_instance==null)
				{
					_instance = new TurnNumberSequence();
				}
				return _instance;					    	
			}
		}
		#endif
											
		public static int GetNextTurnNumber()
		{
			return TurnNumberSequence.Instance.GetNextNumber();
		}
		
		public int GetNextNumber()
		{
			 return _turnNumber++;
		}

    }
}
