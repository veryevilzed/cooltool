using System;

namespace CoolTool {
	public static class TextTools {

		private static string letters = " 1234567890abcdefghijklmnopqrstuvwxyz.,-=+!*$%#@абвгдеёжзийклмнопрстуфхцчшщьыъэюя";

		public static string GetAeroText(string fromText, string toText, int currentTime, int totalTime){
			string res = "";

			if (currentTime < 0 || totalTime < 1)
				throw new ArgumentOutOfRangeException("Need currentTime>=0, totalTime>=1");
			if (currentTime > totalTime)
				currentTime = totalTime;

			fromText = fromText.PadRight(toText.Length);
			toText = toText.PadRight(fromText.Length);
			int deltaI = (int)(((double)currentTime / (double)totalTime) * 100);

			string _fromText = fromText.ToLower();
			string _toText = toText.ToLower();

			for (int i = 0; i < toText.Length; i++) {

				int startLetterPosition = letters.IndexOf(_fromText[i]);
				int stopLetterPosition = letters.IndexOf(_toText[i]);
				if (startLetterPosition == -1 || stopLetterPosition == -1) {
					res += toText[i];
					continue;
				}

				int deltaPosition = 0;
				if (startLetterPosition < stopLetterPosition) {
					deltaPosition = startLetterPosition + deltaI;
					if (deltaPosition > stopLetterPosition)
						deltaPosition = stopLetterPosition;
				}else {
					deltaPosition = startLetterPosition - deltaI;
					if (deltaPosition < stopLetterPosition)
						deltaPosition = stopLetterPosition;
				}

				string letter = letters[deltaPosition].ToString();
				if (Char.IsLower(fromText[i]) && Char.IsUpper(fromText[i])) {
					if (deltaI < 50)
						res += letter.ToLower();
					else
						res += letter.ToUpper();
				} else if (Char.IsUpper(fromText[i]) && Char.IsLower(fromText[i])) {
					if (deltaI < 50)
						res += letter.ToUpper();
					else
						res += letter.ToLower();
				} else if (Char.IsUpper(fromText[i]) && Char.IsUpper(fromText[i])) {
					res += letter.ToUpper();
				} else 
					res += letter;
			}
			return res;
		}

		public static string LiveLine(string text, int size, int currentTime, int totalTime){
			string res = text.PadLeft(text.Length + size);
			res = res.PadRight(res.Length + size);
			int pos = (int)((res.Length-size) * ((double)currentTime / (double)totalTime));
			return res.Substring(pos, size).PadRight(size);
		}

		public static string LiveToRight(string text, int currentTime, int totalTime){
			int pos = (int)((text.Length) * ((double)currentTime / (double)totalTime));
			return text.Substring(0, pos);
		}

		public static string LiveToLeft(string text, int currentTime, int totalTime){
			int pos = (int)((text.Length) * ((double)currentTime / (double)totalTime));
			return text.Substring(text.Length - pos, text.Length - (text.Length - pos)).PadLeft(text.Length);
		}

		public static string LiveFromCenter(string text, int currentTime, int totalTime){
			if (currentTime == totalTime)
				return text;
			int pos = (int)((text.Length / 2) * ((double)currentTime / (double)totalTime));
			Console.WriteLine("{0}  {1}  {2}", pos,text.Length / 2 - pos, pos * 2);
			return text.Substring(text.Length / 2 - pos, pos * 2).PadLeft(text.Length / 2).PadRight(text.Length);
		}
	}

}

