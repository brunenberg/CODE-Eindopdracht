using GameLogic.Items;
using GameLogic.Items.Traps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories {
    public static class ItemFactory {
        public static Item Create(ItemDTO dto) {
            switch (dto.type) {
                case "sankara stone":
                    SankaraStone sankaraStone = new SankaraStone();
                    return sankaraStone;
                case "key":
                    Key key = new Key {
                        Color = dto.color
                    };
                    return key;
                case "boobytrap":
                    BoobyTrap boobyTrap = new BoobyTrap {
                        Damage = dto.damage
                    };
                    return boobyTrap;
                case "disappearing boobytrap":
                    DisappearingBoobyTrap disappearingBoobyTrap = new DisappearingBoobyTrap {
                        Damage = dto.damage
                    };
                    return disappearingBoobyTrap;
                case "pressure plate":
                    PressurePlate pressurePlate = new PressurePlate();
                    return pressurePlate;
                default:
                    throw new ArgumentException("Unknown item type" + dto.type);
            }
        }
    }
}
