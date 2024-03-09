using GameLogic.Items;
using GameLogic.Items.Traps;

namespace Data.Factories {
    public class ItemFactory {
        private readonly Dictionary<string, Func<ItemDTO, Item>> itemCreators = new Dictionary<string, Func<ItemDTO, Item>> {
            { "sankara stone", dto => new SankaraStone { Type = dto.type, X = dto.x, Y = dto.y } },
            { "key", dto => new Key { Color = dto.color, Type = dto.type, X = dto.x, Y = dto.y } },
            { "boobytrap", dto => new BoobyTrap { Damage = (int)dto.damage, Type = dto.type, X = dto.x, Y = dto.y } },
            { "disappearing boobytrap", dto => new DisappearingBoobyTrap { Damage = (int)dto.damage, Type = dto.type, X = dto.x, Y = dto.y } },
            { "pressure plate", dto => new PressurePlate { Type = dto.type, X = dto.x, Y = dto.y } }
        };

        public Item Create(ItemDTO dto) {
            if (itemCreators.TryGetValue(dto.type, out Func<ItemDTO, Item> createItem)) {
                return createItem(dto);
            } else {
                throw new ArgumentException($"Item van type '{dto.type}' wordt niet herkend");
            }
        }
    }
}
