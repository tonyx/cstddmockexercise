using TDDMicroExercises.TirePressureMonitoringSystem.Tests;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{ 
	public class Alarm : IAlarm
    {
        private const double LowPressureTreshold = 17;
        private const double HighPressureTreshold = 21;

        protected ISensor _sensor;

        bool _alarmOn = false;
        protected long _alarmCount = 0;
                        
        public Alarm() {
        	 new Alarm(new Sensor());
        }
        
        public Alarm(ISensor sensor) {
        	_sensor = sensor;
        }


        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureTreshold || HighPressureTreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
