using System;
using System.Collections.Generic;
using System.Linq;
using Quixo.Models;

namespace Quixo.Logic
{
    public class LeagalMoves
    {
        public List<Move> GetLeagalMoves()
        {
            Player activeplayer = Game.Activeplayer;
            List<Move> moves = new List<Move>();
            
            foreach (BoardPiece piece in Game.Board.Pieces)
            {
                if (piece.Face == BoardPieceFace.Clear)
                {
                    var destinations = FindDestinations(piece);
                    foreach (Move destination in destinations)
                    {
                        destination.Score = 100;
                    }
                    moves.AddRange(destinations);
                    
                }

                if (piece.Face == activeplayer.Face)
                {
                    var destinations = FindDestinations(piece);
                    foreach (Move destination in destinations)
                    {
                        destination.Score = 50;
                    }
                    moves.AddRange(destinations);
                }

            }
            return moves;
        }

        private List<Move> BuildListForActivePlayer(int from, List<int> toList)
        {
            Player activeplayer = Game.Activeplayer;
            List<Move> moves = new List<Move>();

            foreach (int to in toList)
            {
                if(Game.Board.Pieces[from].Face== activeplayer.Face || Game.Board.Pieces[from].Face==BoardPieceFace.Clear)
                moves.Add(new Move {From = from,To = to});
            }

            return moves;
        }


        public static void CheckForWinning()
        {
            var inningNumberList = new List<List<int>>();

            for (int i = 0; i < 5; i++)
            {
                inningNumberList.Add(new List<int> { i+0, i + 1, i + 2, i + 3, i + 4 });
                inningNumberList.Add(new List<int> { i * 5 + 0, i * 5 + 1, i * 5 + 2, i * 5 + 3, i * 5 + 4 });
            }

            inningNumberList.Add(new List<int> { 0,6,12,18,24 });
            inningNumberList.Add(new List<int> { 4,8,12,16,20 });


            Player activeplayer = Game.Activeplayer;

            foreach (List<int> winningNumbers in inningNumberList)
            {
                var playerPosistions = Game.Board.Pieces.Where(x => x.Face == activeplayer.Face).Select(x => x.Posistion);
                if(playerPosistions.Intersect(winningNumbers).Count() == winningNumbers.Count)
                    throw new Exception("Winner");

            }
            
        }

        private List<Move> FindDestinations(BoardPiece fromPiece)
        {
            List<Move> moves = new List<Move>();

            switch (fromPiece.Posistion)
            {   //row 1
                case 0:{return BuildListForActivePlayer(fromPiece.Posistion, new List<int>   {4,     20});}
                case 1:{return BuildListForActivePlayer(fromPiece.Posistion, new List<int>   { 0, 4, 21 });}
                case 2: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0, 4, 22 }); }
                case 3: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0, 4, 23 }); }
                case 4: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0,    24 }); }

                //row2
                case 5: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0,      9, 20 }); }
                //case 6: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 1,  5,  9, 21 }); }
                //case 7: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 2,  5,  9, 22 }); }
                //case 8: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 3,  5,  9, 23 }); }
                case 9: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 4,  5,     24 }); }

                //row3
                case 10: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0,     14, 20 }); }
                //case 11: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 1, 10, 14, 21 }); }
                //case 12: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 2, 10, 14, 22 }); }
                //case 13: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 3, 10, 14, 23 }); }
                case 14: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 4, 10,     24 }); }
                
                //row4
                case 15: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0,     19, 20 }); }
                //case 16: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 1, 15, 19, 21 }); }
                //case 17: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 2, 15, 19, 22 }); }
                //case 18: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 3, 15, 19, 23 }); }
                case 19: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 4, 15,     24 }); }

                //row5
                case 20: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 0,     24 }); }
                case 21: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 1, 20, 24 }); }
                case 22: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 2, 20, 24 }); }
                case 23: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 3, 20, 24 }); }
                case 24: { return BuildListForActivePlayer(fromPiece.Posistion, new List<int> { 4, 20 }); }
            }
            return moves;
        }
    }
}
