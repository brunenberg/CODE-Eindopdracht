
public class DisplayInfo {
    public char Character { get; set; }
    public ConsoleColor? Color { get; set; }

    public DisplayInfo(char character, ConsoleColor? color) {
        Character = character;
        Color = color;
    }
}
