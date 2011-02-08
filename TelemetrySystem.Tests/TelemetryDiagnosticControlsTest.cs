using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Tests;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
				
    [TestFixture]
    public class TelemetryDiagnosticControlsTest
    {

    	[Test]
		public void VerifyingThatAnEventWasFired() 
		{ 
		     MockRepository mocks = new MockRepository();
		     IEventSubscriber subscriber = mocks.StrictMock<IEventSubscriber>(); 
		     IWithEvents events = new WithEvents(); 
		     // This doesn't create an expectation because no method is called on subscriber!! 
		     events.Blah+=new EventHandler(subscriber.Handler); 
		     subscriber.Handler(events, EventArgs.Empty); 
		     mocks.ReplayAll(); 
		     events.RaiseEvent(); 
		     mocks.VerifyAll(); 
		} 
    	
    	
    	
	     [Test]
		 public void MockingDelegates() {
		    var stubMapper = MockRepository.GenerateStub<Func<int, int>>();
		    var expectedResult = 1234;
		    stubMapper.Stub(x => x(10)).Return(expectedResult);            
		    var someClass = new SomeClass(stubMapper);		
		    var result = someClass.DoSomething(10);	
		    Console.Out.WriteLine(result);
		    Assert.AreEqual(expectedResult, result);
		 }
    
    	
               
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
		 
		[Test]
		public void when_the_pressure_in_under_16_the_alarm_is_on_with_rhino_mock()
		{
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(16.00);
			IAlarm alarm = new Alarm(sensor);
			mocks.ReplayAll();			
			alarm.Check();			
			Assert.IsTrue(alarm.AlarmOn);
			sensor.VerifyAllExpectations();
		}

		
		[Test]
		public void when_the_pressure_in_over_18_the_alarm_is_off_with_rhino_mock()
		{
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(18.00);
			IAlarm alarm = new Alarm(sensor);
			mocks.ReplayAll();			
			alarm.Check();			
			Assert.IsFalse(alarm.AlarmOn);
			sensor.VerifyAllExpectations();
		}
			
		
		[Test]
		[ExpectedException(typeof(ExpectationViolationException))]
		public void noCallToAlarmSoNoCallToSensor()
		{
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(18.00);
			IAlarm alarm = new Alarm(sensor);
			mocks.ReplayAll();			

			sensor.VerifyAllExpectations();			
		}
			
		
		[Test]		
		public void CheckingAlarmTwiceShouldCallSensorTwice()
		{
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(16.00).Repeat.Twice();
			IAlarm alarm = new Alarm(sensor);
			mocks.ReplayAll();			
			alarm.Check();
			alarm.Check();
			sensor.VerifyAllExpectations();		
						
		}
		
		[Test]		
		public void APressure18FollowedByPressure16MeansAlarmOffAndOn()
		{
			
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(18.00).Repeat.Once();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(16.00).Repeat.Once();
			
			mocks.ReplayAll();
			
			IAlarm alarm = new Alarm(sensor);
			
			alarm.Check();
			Assert.IsFalse(alarm.AlarmOn);

			alarm.Check();
			Assert.IsTrue(alarm.AlarmOn);
			
			sensor.VerifyAllExpectations();
			
		}
		
		
    }
}
