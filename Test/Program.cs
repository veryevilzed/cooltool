using System;

namespace Test {
	class MainClass {
		public static void Main(string[] args) {
			for (int d = 0; d <= 50; d += 1) {
				Console.WriteLine("[{0}]", CoolTool.TextTools.LiveFromCenter("9876543210123456789", d, 50));
			}
		}
	}
}
