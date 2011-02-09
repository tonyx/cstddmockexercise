/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 02/02/2011
 * Time: 17:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
	/// <summary>
	/// Description of MockSensor.
	/// deprecto (ora uso rhino)
	/// </summary>
	public class MockSensor : ISensor
	{
		
		private double _stubbedReturnedValue;	
		private int _countCall = 0;
		
		public double StubbedReturnedValue {
			set { _stubbedReturnedValue = value; }
		}
		
		public int CountCall {
			get { return _countCall; }
		}
		
		
		public MockSensor(double stubValue)
		{
			_stubbedReturnedValue=stubValue;
		}
				
		public double PopNextPressurePsiValue()
		{
			_countCall++;
			return _stubbedReturnedValue;
		}
				
		

				
		
	
	}
}
