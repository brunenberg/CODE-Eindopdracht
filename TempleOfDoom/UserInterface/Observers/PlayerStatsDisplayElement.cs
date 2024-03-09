using GameLogic.Entities;

namespace UserInterface.Observers {
    public class PlayerStatsDisplayElement : IObserver<Player> {
        public void OnNext(Player player) {
            Console.WriteLine($"Lives: {player.Lives}");

            Console.Write("Inventory: ");
            for (int i = 0; i < player.Inventory.Count; i++) {
                var item = player.Inventory[i];
                ConsoleColor? color = PrintHelper.GetObjectColor(item, null);
                PrintHelper.PrintColoredString(item.Type, color);
                if (i < player.Inventory.Count - 1) {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        public void OnError(Exception error) {
            Console.WriteLine($"An error occured: {error.Message}");
        }

        public void OnCompleted() {
            Console.WriteLine("Player updates completed.");
        }
    }
}
