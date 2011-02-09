/*
 * Created by SharpDevelop.
 * User: Tonino
 * Date: 08/02/2011
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


using System;
using System.IO;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Exceptions;
using TDDMicroExercises.UnicodeFileToHtmTextConverter;

namespace TDDMicroExercises.UnicodeFileToHtmTextConverter.Tests
{
	[TestFixture]
	public class UnicodeFileToHtmlConverterTest
	{
		[Test]
		public void TestMethod()
		{
			MockRepository mocks = new MockRepository();
			TextReader reader = mocks.StrictMock<TextReader>();
			
			Expect.Call(reader.ReadLine()).Return("hello привет");
			Expect.Call(reader.ReadLine()).Return(null);
			
			mocks.ReplayAll();
			
			UnicodeFileToHtmTextConverter unicode = new UnicodeFileToHtmTextConverter(reader);
			
			Assert.AreEqual("hello привет</b>",unicode.ConvertToHtml());

			mocks.VerifyAll();
			

		}
	}
}
