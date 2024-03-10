public static class DirectionHelper {
    public static (int, int) GetDelta(this Direction direction) {
        switch (direction) {
            case Direction.NORTH:
                return (0, -1);
            case Direction.EAST:
                return (1, 0);
            case Direction.SOUTH:
                return (0, 1);
            case Direction.WEST:
                return (-1, 0);
            default:
                throw new ArgumentException("Invalid direction");
        }
    }
}
