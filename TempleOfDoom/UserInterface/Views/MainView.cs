
using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace UserInterface.Views {
    public static class MainView {
        private static Dictionary<Type, Func<GameObject, DisplayInfo>> viewMap = new Dictionary<Type, Func<GameObject, DisplayInfo>> {
            { typeof(Connection), obj => ConnectionView.GetDisplayInfo(obj) },
            { typeof(Item), obj => ItemView.GetDisplayInfo(obj) },
            { typeof(Entity), obj => EntityView.GetDisplayInfo(obj) },
            { typeof(Wall), obj => WallView.GetDisplayInfo(obj) }
        };

        public static GameObject? GetPriorityObject(List<GameObject> objects) {
            List<Type> priorityList = new List<Type> { typeof(Player), typeof(Enemy) };

            objects.Sort((a, b) => {
                int indexA = priorityList.IndexOf(a.GetType());
                int indexB = priorityList.IndexOf(b.GetType());

                if (indexA == -1) indexA = int.MaxValue;
                if (indexB == -1) indexB = int.MaxValue;

                return indexA.CompareTo(indexB);
            });

            return objects.FirstOrDefault();
        }

        public static DisplayInfo GetDisplayInfo(GameObject obj) {
            Type objType = obj.GetType();
            foreach (var kvp in viewMap) {
                Type viewType = kvp.Key;
                if (viewType.IsAssignableFrom(objType)) {
                    Func<GameObject, DisplayInfo> getDisplayInfo = kvp.Value;
                    DisplayInfo displayInfo = getDisplayInfo(obj);
                    displayInfo.Color = GetObjectColor(obj, displayInfo.Color);
                    return displayInfo;
                }
            }
            throw new ArgumentException($"Object of type '{obj.GetType()}' is not recognized");
        }
        private static ConsoleColor? GetObjectColor(GameObject obj, ConsoleColor? defaultColor) {
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

        private static string ToPascalCase(string str) {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

    }
}
