using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;

public record Tile() {
    public string TId {get; init;}
    public int[] UniqueRotations {get; init;}
    public int Up {get; init;}
    public int Right {get; init;}
    public int Down {get; init;}
    public int Left {get; init;}
}



public partial class RoomWFC : TileMap
{
    private static Tile RotateTile(int rotations, Tile tile) {
        Tile result = new() {
            TId = tile.TId,
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

    private static Tile[] gen_variants(Tile[] unique) {
        List<Tile> variants = new List<Tile>();
        foreach (Tile tile in unique) {
            for (int i = 0; i < tile.UniqueRotations.Length; i++) {
                variants.Add(RotateTile(tile.UniqueRotations[i], tile));
            }
        }
        return variants.ToArray();
    }
    
    private static Tile[] uniqueTiles = {
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
                SetCell(0, new Vector2I(coords.X-width/2 + w, coords.Y-height/2 + h), 0, new Vector2I(1,1));
            }
        }
    }
}
