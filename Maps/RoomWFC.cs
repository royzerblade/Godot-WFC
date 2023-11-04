using Godot;
using System;
using System.ComponentModel;
using System.Data.Common;

public enum Connector {
    Empty,
    Wall,
    WallFlipped,
    Floor
}

public record Tile() {
    public string TId {get; init;}
    public Connector Up {get; init;}
    public Connector Right {get; init;}
    public Connector Down {get; init;}
    public Connector Left {get; init;}
}

public partial class RoomWFC : TileMap
{
    Tile Corner = new() { 
        TId = "00", 
        Up = Connector.Empty, 
        Right = Connector.WallFlipped,
        Down = Connector.Wall,
        Left = Connector.Empty};
    
    Tile Wall = new() { 
        TId = "01", 
        Up = Connector.Empty, 
        Right = Connector.WallFlipped,
        Down = Connector.Floor,
        Left = Connector.Wall};
    
    Tile Floor = new() { 
        TId = "11", 
        Up = Connector.Floor, 
        Right = Connector.Floor,
        Down = Connector.Floor,
        Left = Connector.Floor};

    Tile Blank = new() { 
        TId = "10", 
        Up = Connector.Empty, 
        Right = Connector.Empty,
        Down = Connector.Empty,
        Left = Connector.Empty};

    int TileSize = 10;
    int width = 2;
    int height = 2;
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
        for (int w = 0; w < width*TileSize; w++) {
            for (int h = 0; h < height*TileSize; h++) {
                SetCell(0, new Vector2I(coords.X-width/2*TileSize + w, coords.Y-height/2*TileSize + h), 0, new Vector2I(1,1));
            }
        }
    }
}
