
using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace UserInterface.Views {
    public class MainView {
        private ConnectionView _connectionView = new ConnectionView();
        private ItemView _itemView = new ItemView();
        private EntityView _entityView = new EntityView();
        private WallView _wallView = new WallView();

        private readonly Dictionary<Type, Func<GameObject, DisplayInfo>> viewMap;

        public MainView() {
            viewMap = new Dictionary<Type, Func<GameObject, DisplayInfo>> {
                { typeof(Connection), obj => _connectionView.GetDisplayInfo(obj) },
                { typeof(Item), obj => _itemView.GetDisplayInfo(obj) },
                { typeof(Entity), obj => _entityView.GetDisplayInfo(obj) },
                { typeof(Wall), obj => _wallView.GetDisplayInfo(obj) }
            };
        }

        public DisplayInfo DisplayInfo {
            get => default;
            set {
            }
        }

        public void PrintPriorityObject(List<GameObject> objects) {
            GameObject priorityObject = GetPriorityObject(objects);
            DisplayInfo displayInfo = GetDisplayInfo(priorityObject);
            PrintHelper.PrintColoredCharacter(displayInfo.Character, displayInfo.Color);
        }

        public GameObject? GetPriorityObject(List<GameObject> objects) {
            List<Type> priorityList = new List<Type> { typeof(Player), typeof(EnemyAdapter) };

            objects.Sort((a, b) => {
                int indexA = priorityList.IndexOf(a.GetType());
                int indexB = priorityList.IndexOf(b.GetType());

                if (indexA == -1) indexA = int.MaxValue;
                if (indexB == -1) indexB = int.MaxValue;

                return indexA.CompareTo(indexB);
            });

            return objects.FirstOrDefault();
        }

        public DisplayInfo GetDisplayInfo(GameObject obj) {
            Type objType = obj.GetType();
            foreach (var kvp in viewMap) {
                Type viewType = kvp.Key;
                if (viewType.IsAssignableFrom(objType)) {
                    Func<GameObject, DisplayInfo> getDisplayInfo = kvp.Value;
                    DisplayInfo displayInfo = getDisplayInfo(obj);
                    displayInfo.Color = PrintHelper.GetObjectColor(obj, displayInfo.Color);
                    return displayInfo;
                }
            }
            throw new ArgumentException($"Object of type '{obj.GetType()}' is not recognized");
        }
    }
}
