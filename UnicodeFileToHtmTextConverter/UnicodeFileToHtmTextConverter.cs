using System;
using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmTextConverter
{
	public class UnicodeFileToHtmTextConverter
	{
		
		private TextReader _textReader;
		
		public UnicodeFileToHtmTextConverter(TextReader reader)
		{
			_textReader = reader;
		}

		
		public UnicodeFileToHtmTextConverter(string fullFilenameWithPath)
		{
			_textReader = File.OpenText(fullFilenameWithPath);
		}

		public string ConvertToHtml()
		{
			string html = string.Empty;

			string line = _textReader.ReadLine();
			while (line != null)
			{
				html += HttpUtility.HtmlEncode(line);
				html += "</b>";
				line = _textReader.ReadLine();
			}

			return html;
		}
	}
}
