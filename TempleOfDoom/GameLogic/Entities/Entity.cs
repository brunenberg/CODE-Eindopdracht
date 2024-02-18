using GameLogic.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Entities {
    public abstract class Entity {
        public int Health { get; protected set; }

        public abstract void Move(Direction direction);
        public abstract void TakeDamage(int damage);
        public abstract void InteractWithDoor(Door door);
    }
}
