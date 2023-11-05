public class TileInitData {

    public static Tile[] uniqueTiles = {
        new() {
            TId = "00",
            UniqueRotations = new int[] {0, 1, 2, 3},
            Up = 10,
            Right = 2,
            Down = -2,
            Left = 10},
        new() {
            TId = "01",
            UniqueRotations = new int[] {0, 1, 2, 3},
            Up = 10,
            Right = 2,
            Down = 20,
            Left = -2},
        new() {
            TId = "11",
            UniqueRotations = new int[] {0},
            Up = 20,
            Right = 20,
            Down = 20,
            Left = 20
        },
        new() {
            TId = "10",
            UniqueRotations = new int[] {0},
            Up = 10,
            Right = 10,
            Down = 10,
            Left = 10
        }
    };
}