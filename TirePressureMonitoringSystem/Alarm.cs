using System;
using TDDMicroExercises.TirePressureMonitoringSystem.Tests;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{ 
	public class Alarm : IAlarm
    {

        private IChecker _checker;

        protected ISensor _sensor;

        bool _alarmOn = false;
        protected long _alarmCount = 0;
                        
        public Alarm() {
        	new Alarm(new Sensor(),new DefaultChecker());
        }
        
        public Alarm(ISensor sensor, IChecker checker) {
        	_sensor = sensor;
        	_checker = checker;
        }

        public void Check()
        {
            
            if (_checker.Check(_sensor.PopNextPressurePsiValue()))            
            {
                _alarmOn = true;
                _alarmCount += 1;
            } else
            {
            	_alarmOn = false;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
