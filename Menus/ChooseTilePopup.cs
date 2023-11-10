using Godot;
using System;
using static TileVarGen;

public partial class ChooseTilePopup : PopupMenu
{
    private static Tile[] uniqueTiles = TileInitData.uniqueTiles;
    private static Tile[] allVariantTiles = GenVariants(uniqueTiles);

    public override void _Ready()
    {
        PopulateMenu(allVariantTiles);
    }

    private static void PopulateMenu(Tile[] tiles) {
        
    }
}
