public record Tile() {
        public string TId {get; init;}
        public int[] UniqueRotations {get; init;}
        public int Up {get; init;}
        public int Right {get; init;}
        public int Down {get; init;}
        public int Left {get; init;}
    }