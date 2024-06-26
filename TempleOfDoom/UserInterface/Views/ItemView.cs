﻿using GameLogic.Items;
using GameLogic.Items.Traps;
using GameLogic.Models;

namespace UserInterface.Views {
    public class ItemView {
        private readonly Dictionary<Type, (char, ConsoleColor?)> displayMap = new Dictionary<Type, (char, ConsoleColor?)> {
            { typeof(SankaraStone), ('S', ConsoleColor.DarkYellow) },
            { typeof(Key), ('K', null) },
            { typeof(BoobyTrap), ('O', null) },
            { typeof(DisappearingBoobyTrap), ('@', null) },
            { typeof(PressurePlate), ('P', null) }
        };

        public DisplayInfo GetDisplayInfo(GameObject item) {
            if (displayMap.TryGetValue(item.GetType(), out var characterColor)) {
                return new DisplayInfo(characterColor.Item1, characterColor.Item2);
            }
            throw new ArgumentException($"Item of type '{item.GetType()}' is not recognized");
        }

        public char GetCharacter(GameObject item) {
            if (displayMap.TryGetValue(item.GetType(), out var characterColor)) {
                return characterColor.Item1;
            }
            throw new ArgumentException($"Item of type '{item.GetType()}' is not recognized");
        }
    }
}
