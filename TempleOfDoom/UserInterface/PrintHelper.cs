using GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.Views;

namespace UserInterface {
    public static class PrintHelper {
        public static void PrintPriorityObject(List<GameObject> objects) {
            GameObject priorityObject = MainView.GetPriorityObject(objects);
            DisplayInfo displayInfo = MainView.GetDisplayInfo(priorityObject);
            PrintCharacter(displayInfo.Character, displayInfo.Color);
        }

        public static void PrintCharacter(char character, ConsoleColor? color = null) {
            if (color.HasValue) {
                Console.ForegroundColor = color.Value;
            }
            Console.Write(character);
            Console.ResetColor();
        }
    }
}

