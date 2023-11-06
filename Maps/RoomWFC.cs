using Godot;
using static TileVarGen;

public partial class RoomWFC : TileMap
{
    private static Tile[] uniqueTiles = TileInitData.uniqueTiles;
    Tile[] allVariantTiles = gen_variants(uniqueTiles);


    int width = 3;
    int height = 3;
    CharacterBody2D Player;

    public override void _Ready()
    {
        Player = GetNode<CharacterBody2D>("/root/Map/CharacterBody2D");
    }

    public override void _Process(double delta)
    {
        Vector2 pos = Player.Get("position").As<Vector2>();
        GenerateChunk(pos);
    }

    private void GenerateChunk(Vector2 pos) {
        Vector2I coords = LocalToMap(pos);
        for (int w = 0; w < width; w++) {
            for (int h = 0; h < height; h++) {
                SetCell(0, new Vector2I(coords.X-width/2 + w, coords.Y-height/2 + h), 0, new Vector2I(0,0), 1);
            }
        }
    }
}
