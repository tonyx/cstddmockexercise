/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 10/02/2011
 * Time: 22:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
	/// <summary>
	/// Description of DefaultChecker.
	/// </summary>
	public class DefaultChecker : IChecker
	{
        private const double LowPressureTreshold = 17;
        private const double HighPressureTreshold = 21;
		
		public bool Check(double psiPressureValue)
		{
			return (psiPressureValue < LowPressureTreshold || HighPressureTreshold < psiPressureValue);
		}
			
	}
}
