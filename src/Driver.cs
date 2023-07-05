using System;
using FEEngine.Engine;

namespace FEEngine {
    public class Driver {
        public static void Main(string[] args) {
            Display display = new Display();
            string input;

            while (true) {
                Console.WriteLine(display.toString());
                input = Console.ReadLine()!;
            }
        }
    }
}