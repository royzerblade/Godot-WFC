using System;

public class Parser {
    // takes in a string and returns list of [atlas-coord.x, atlas-coord.y, alternate-id]
    public static int[] ParseTileId(String s) {

        char atlasX = s[0];
        char atlasY = s[1];
        char variant = s[s.Length - 1];
        return new int[] {(int)Char.GetNumericValue(atlasX),
                            (int)Char.GetNumericValue(atlasY),
                            (int)Char.GetNumericValue(variant)};
    }
}