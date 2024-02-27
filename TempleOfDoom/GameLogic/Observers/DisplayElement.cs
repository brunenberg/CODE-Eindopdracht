using GameLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Observers {
    public class DisplayElement : IObserver<Player> {
        public void OnNext(Player player) {
            //TODO: IMPLEMENT
            // Update the display element based on the player's state
        }

        public void OnError(Exception error) {
            //TODO: IMPLEMENT
            // Handle any errors 
        }

        public void OnCompleted() {
            //TODO: IMPLEMENT
            // Handle completion
        }
    }
}
