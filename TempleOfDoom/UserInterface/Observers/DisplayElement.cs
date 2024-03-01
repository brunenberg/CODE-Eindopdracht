using GameLogic.Entities;

namespace UserInterface.Observers {
    public class DisplayElement : IObserver<Player> {
        public void OnNext(Player player) {
            Console.WriteLine($"Lives: {player.Lives}");

            string inventory = string.Join(", ", player.Inventory.Select(item => item.Type));
            Console.WriteLine($"Inventory: {inventory}");
        }

        public void OnError(Exception error) {
            Console.WriteLine($"An error occured: {error.Message}");
        }

        public void OnCompleted() {
            Console.WriteLine("Player updates completed.");
        }
    }
}
