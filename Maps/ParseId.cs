using System;

public class Parser {

    // takes in a string and returns list of [atlas-coord.x, atlas-coord.y, alternate-id]
    public static int[] parseTileId(String str) {

        // completely symmetrical variants contain only atlas coords (alternate-id = 0)
        if (str.Length == 2) {
            String[] cl = str.Split("");
            return new int[] {int.Parse(cl[0]), int.Parse(cl[1]), 0};
        }
        return new int[] {0, 1, 2};
    }
}