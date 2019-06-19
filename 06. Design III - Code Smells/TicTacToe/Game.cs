﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Tile
    {
        public int X {get; set;}
        public int Y {get; set;}
        public char Symbol {get; set;}
    }

    public class Board
    {
       private List<Tile> _plays = new List<Tile>();
       
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile{ X = i, Y = j, Symbol = ' '});
                }  
            }       
        }
       public Tile TileAt(int x, int y)
       {
           return _plays.Single(tile => tile.X == x && tile.Y == y);
       }

       public void AddTileAt(char symbol, int x, int y)
       {
           var newTile = new Tile
           {
               X = x,
               Y = y,
               Symbol = symbol
           };

           _plays.Single(tile => tile.X == x && tile.Y == y).Symbol = symbol;
       }
    }

    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();
        
        public void Play(char symbol, int x, int y)
        {
            if(IsFirstMove())
            {
                if(IsPlayerX(symbol))
                {
                    throw new Exception("Invalid first player");
                }
            } 
            else if (IsNotFirstMoveButPlayerRepeated(symbol))
            {
                throw new Exception("Invalid next player");
            }
            else if (IsNotFirstMoveButPlayerAlreadyPlayedTile(x, y))
            {
                throw new Exception("Invalid position");
            }

            UpdateGameState(symbol, x, y);
        }

        private void UpdateGameState(char symbol, int x, int y)
        {
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private bool IsNotFirstMoveButPlayerAlreadyPlayedTile(int x, int y)
        {
            return _board.TileAt(x, y).Symbol != ' ';
        }

        private bool IsNotFirstMoveButPlayerRepeated(char symbol)
        {
            return symbol == _lastSymbol;
        }

        private static bool IsPlayerX(char symbol)
        {
            return symbol == 'O';
        }

        private bool IsFirstMove()
        {
            return _lastSymbol == ' ';
        }

        public char Winner()
        {   //if the positions in first row are taken
            if(_board.TileAt(0, 0).Symbol != ' ' &&
               _board.TileAt(0, 1).Symbol != ' ' &&
               _board.TileAt(0, 2).Symbol != ' ')
               {
                    //if first row is full with same symbol
                    if (_board.TileAt(0, 0).Symbol == 
                        _board.TileAt(0, 1).Symbol &&
                        _board.TileAt(0, 2).Symbol == 
                        _board.TileAt(0, 1).Symbol )
                        {
                            return _board.TileAt(0, 0).Symbol;
                        }
               }
                
             //if the positions in first row are taken
             if(_board.TileAt(1, 0).Symbol != ' ' &&
                _board.TileAt(1, 1).Symbol != ' ' &&
                _board.TileAt(1, 2).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(1, 0).Symbol == 
                        _board.TileAt(1, 1).Symbol &&
                        _board.TileAt(1, 2).Symbol == 
                        _board.TileAt(1, 1).Symbol)
                        {
                            return _board.TileAt(1, 0).Symbol;
                        }
                }

            //if the positions in first row are taken
             if(_board.TileAt(2, 0).Symbol != ' ' &&
                _board.TileAt(2, 1).Symbol != ' ' &&
                _board.TileAt(2, 2).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(2, 0).Symbol == 
                        _board.TileAt(2, 1).Symbol &&
                        _board.TileAt(2, 2).Symbol == 
                        _board.TileAt(2, 1).Symbol)
                        {
                            return _board.TileAt(2, 0).Symbol;
                        }
                }

            return ' ';
        }
    }
}