﻿/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 08/02/2011
 * Time: 23:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Tests;



namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
	[TestFixture]
	public class TirePressureSystemTest
	{
		           
       [Test]
		public void For_A_Value_of_pressure_18_TheAlarmShould_be_off()
        {
			Alarm alarm = new Alarm(new MockSensor(18),new DefaultChecker());
        	alarm.Check();
        	Assert.IsFalse(alarm.AlarmOn);       	
        }
		
		[Test]
		public void For_A_Value_of_pressure_16_TheAlarmShould_be_on()
        {
        	Alarm alarm = new Alarm(new MockSensor(16),new DefaultChecker());
        	alarm.Check();
        	Assert.IsTrue(alarm.AlarmOn);       	
        }
		
//		[Test]
//		public void The_Sensor_must_be_called_when_checking_alarm()
//        {
//        	MyMockAlarm alarm = new MyMockAlarm(new MockSensor(18),new DefaultChecker());
//        	alarm.Check();
//        	alarm.ExpectedCalls=1;        	
//        	alarm.Verify();
//        	
//        }
		
		
//		[Test]
//		public void When_the_Pressure_alarm_is_violated_two_times_the_alarm_count_shoud_count_two()
//        {
//			MockSensor sensor = new MockSensor(18);
//			MyMockAlarm alarm = new MyMockAlarm(sensor);
//			alarm.Check();
//
//			sensor.StubbedReturnedValue=16;
//        	alarm.Check();
//        	alarm.Check();
//        	alarm.ExpectedCalls=3;
//        	alarm.ExpectedAlarmOns=2;
//        	alarm.Verify();
//        	
//        } 
		 
		
		[Test]
		public void when_the_pressure_in_under_16_the_alarm_is_on_with_rhino_mock()
		{
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(16.00);
			IAlarm alarm = new Alarm(sensor,new DefaultChecker());
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
			IAlarm alarm = new Alarm(sensor,new DefaultChecker());
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
			IAlarm alarm = new Alarm(sensor, new DefaultChecker());
			mocks.ReplayAll();			

			sensor.VerifyAllExpectations();			
		}
			
		
		[Test]		
		public void CheckingAlarmTwiceShouldCallSensorTwice()
		{
			MockRepository mocks = new MockRepository();
			ISensor sensor = mocks.StrictMock<ISensor>();
			Expect.Call(sensor.PopNextPressurePsiValue()).Return(16.00).Repeat.Twice();
			IAlarm alarm = new Alarm(sensor, new DefaultChecker());
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
			
			IAlarm alarm = new Alarm(sensor, new DefaultChecker());
			
			alarm.Check();
			Assert.IsFalse(alarm.AlarmOn);

			alarm.Check();
			Assert.IsTrue(alarm.AlarmOn);
			
			sensor.VerifyAllExpectations();
			
		}
				
    }
	
}
