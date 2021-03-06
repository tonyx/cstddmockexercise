﻿/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 02/02/2011
 * Time: 18:17
 * 
 * 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
//using System.Diagnostics.Contracts;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
	/// <summary>
	/// deprecato (ora uso rhino)
	/// </summary>
	public class MyMockAlarm : Alarm
	{
		int _expectedCalls = 0;
		int _expectedAlarmOns=0;
		
		public int ExpectedAlarmOns {
			set { _expectedAlarmOns = value; }
		}
				
		
		public int ExpectedCalls {			
			set { _expectedCalls = value; }
		}

		public MyMockAlarm(MockSensor sensor) {
			_sensor=sensor;
		}
		
		public void Verify()
       {
			if (! (_sensor is MockSensor))
				throw new ArgumentException("cannot veryfy with sensor if sensor is not a mock");

			MockSensor mocksensor = (MockSensor)_sensor;

		 	if (mocksensor.CountCall!=_expectedCalls)
		 		throw new ArgumentOutOfRangeException("count call expected "+_expectedCalls+"but actual was "+mocksensor.CountCall);
		 	
		 	if (this._expectedAlarmOns!=_alarmCount)
		 		throw new ArgumentOutOfRangeException("AlarmOn calls count expected "+this._expectedAlarmOns+" but was "+_alarmCount);
		}		

	}
}
