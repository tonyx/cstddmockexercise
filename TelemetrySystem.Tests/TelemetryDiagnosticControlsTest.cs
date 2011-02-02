using NUnit.Framework;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Tests;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryDiagnosticControlsTest
    {
        [Test]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response()
        {
        	Assert.IsTrue(true);
        }
        
//        [Test]
//        public void Check_That_sensor_is_called_by_the_alarm()
//        {
//        	MockAlarm alarm = new MockAlarm();
//        	alarm.Check();
//
//        	
//        	alarm.Verify();
//        	
//        }
        
        
       [Test]
		public void For_A_Value_of_pressure_18_TheAlarmShould_be_off()
        {
        	Alarm alarm = new Alarm(new MockSensor(18));
        	alarm.Check();
        	Assert.IsFalse(alarm.AlarmOn);       	
        }
		
		[Test]
		public void For_A_Value_of_pressure_16_TheAlarmShould_be_on()
        {
        	Alarm alarm = new Alarm(new MockSensor(16));
        	alarm.Check();
        	Assert.IsTrue(alarm.AlarmOn);       	
        }
		
		[Test]
		public void The_Sensor_must_be_called_when_checking_alarm()
        {
        	MyMockAlarm alarm = new MyMockAlarm(new MockSensor(18));
        	alarm.Check();
        	alarm.ExpectedCalls=1;        	
        	alarm.Verify();
        	
        }
		
		[Test]
		public void When_the_Pressure_alarm_is_violated_two_times_the_alarm_count_shoud_count_two()
        {
			MockSensor sensor = new MockSensor(18);
			MyMockAlarm alarm = new MyMockAlarm(sensor);
			alarm.Check();

			sensor.StubbedReturnedValue=16;
        	alarm.Check();
        	alarm.Check();
        	alarm.ExpectedCalls=3;
        	alarm.ExpectedAlarmOns=2;
        	alarm.Verify();
        	
        }
		
    }
}
