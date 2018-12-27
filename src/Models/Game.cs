using System.Collections.Generic;
using Quixo.Logic;

namespace Quixo.Models
{
    public static class Game
    {

        public static void SetupGame()
        {
            Board = new GameBoard {Pieces = new List<BoardPiece>()};
          

            for (int i = 0; i < 25; i++)
            {
                Board.Pieces.Add(new BoardPiece {Face =BoardPieceFace.Clear,Posistion = i});
            }

            Player1 = new Player {IsComputer = true, Name = "Player1 X",Face = BoardPieceFace.Cross};
            Player2 = new Player { IsComputer = true, Name = "Player2 O",Face = BoardPieceFace.Circle};
            Activeplayer = Player1;
        }

        public static void NextPlayer()
        {
            Activeplayer = Activeplayer == Player1 ? Player2 : Player1;
        }

        public static void AutoMove()
        {
            PieceMover pm = new PieceMover();
            pm.SuggestBestMove();
        }

        public static Player Player2 { get; private set; }
        public static Player Player1 { get; private set; }
        public static GameBoard Board { get; private set; }
        public static Player Activeplayer { get; private set; }

        public static void Move(int from, int to)
        {
            PieceMover pm = new PieceMover();
            pm.Move(new Move(){From = from, To = to});
        }
    }
}
