namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnTicket
    {
        private readonly int _turnNumber;

        public TurnTicket(int turnNumber)
        {
            _turnNumber = turnNumber;
        }

        public int TurnNumber
        {
            get { return _turnNumber; }
        }
        
        public override int GetHashCode() {
        	return _turnNumber;
        }
        
        public override bool Equals(object other)
        {
        	if (! (other is TurnTicket))
        		return false;
        	TurnTicket tOther = (TurnTicket)other;
        	return (_turnNumber==tOther._turnNumber);
        }
        
        public override string ToString() {
        	return System.Convert.ToString(_turnNumber);
        }

    }
}