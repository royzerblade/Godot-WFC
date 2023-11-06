using System;

public class Parser {
    // takes in a string and returns list of [atlas-coord.x, atlas-coord.y, alternate-id]
    public static int[] parseTileId(String s) {

        // completely symmetrical variants contain only atlas coords (alternate-id = 0)
        if (s.Length == 2) {
            char atlasX = s[0];
            char atlasY = s[1];
            return new int[] {(int)Char.GetNumericValue(atlasX),
                              (int)(int)Char.GetNumericValue(atlasY),
                              0};
        } else {
            char atlasX = s[0];
            char atlasY = s[1];
            char variant = s[s.Length - 1];
            return new int[] {(int)Char.GetNumericValue(atlasX),
                              (int)Char.GetNumericValue(atlasY),
                              (int)Char.GetNumericValue(variant)};
        }
    }
}