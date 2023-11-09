using System;
using System.Collections.Generic;

public class TileVarGen {
    private static Tile RotateTile(int rotations, Tile tile) {
        Tile result = new() {
            TId = tile.TId + $"-{rotations}",
            UniqueRotations = tile.UniqueRotations,
            Up = tile.Up,
            Right = tile.Right,
            Down = tile.Down,
            Left = tile.Left
        };
        for (int i = 0; i < rotations; i++) {
            result = Rotate90(result);
        }
        return result;
    }

    private static Tile Rotate90(Tile tile) {
        return new Tile() {
            TId = tile.TId,
            UniqueRotations = tile.UniqueRotations,
            Up = tile.Left,
            Right = tile.Up,
            Down = tile.Right,
            Left = tile.Down
        };
    }

    public static Tile[] GenVariants(Tile[] unique) {
        List<Tile> variants = new();
        foreach (Tile tile in unique) {
            for (int i = 0; i < tile.UniqueRotations.Length; i++) {
                variants.Add(RotateTile(tile.UniqueRotations[i], tile));
            }
        }
        return variants.ToArray();
    }
}