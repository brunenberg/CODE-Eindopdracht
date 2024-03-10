using GameLogic.Models;
using UserInterface.Views;

namespace UserInterface {
    public static class PrintHelper {
        public static void PrintColoredCharacter(char character, ConsoleColor? color = null) {
            if (color.HasValue) {
                Console.ForegroundColor = color.Value;
            }
            Console.Write(character);
            Console.ResetColor();
        }
        public static void PrintColoredString(string text, ConsoleColor? color = null) {
            if (color.HasValue) {
                Console.ForegroundColor = color.Value;
            }
            Console.Write(text);
            Console.ResetColor();
        }

        public static  ConsoleColor? GetColorFromString(string colorName) {
            if (!string.IsNullOrEmpty(colorName)) {
                colorName = ToPascalCase(colorName);
                return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
            }
            return null;
        }

        public static ConsoleColor? GetObjectColor(GameObject obj, ConsoleColor? defaultColor) {
            var colorProperty = obj.GetType().GetProperty("Color");
            if (colorProperty != null) {
                string? colorName = (string?)colorProperty.GetValue(obj);
                if (!string.IsNullOrEmpty(colorName)) {
                    colorName = ToPascalCase(colorName);
                    return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
                }
            }
            return defaultColor;
        }

        public static string ToPascalCase(string str) {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}

