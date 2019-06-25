namespace TicTacToe
{
    public class Tile
    {
        public Tile(Coordinate coordinate)
        {
            Coordinate = coordinate;
            Symbol = ' ';
        }

        public Coordinate Coordinate { get; }
        public char Symbol {get; private set;}

        public void Play(char symbol)
        {
            Symbol = symbol;
        }
    }
}