using System;
using System.Collections.Generic;
using System.Linq;
using Quixo.Models;

namespace Quixo.Logic
{
    public class PieceMover
    {

        private void MoveUp(BoardPiece boardPiece, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var fromFace = Game.Board.Pieces[boardPiece.Posistion - i * 5].Face;
                var toFace = Game.Board.Pieces[boardPiece.Posistion - i * 5 - 5].Face;

                Game.Board.Pieces[boardPiece.Posistion - i * 5 - 5].Face = fromFace;
                Game.Board.Pieces[boardPiece.Posistion - i * 5].Face = toFace;
            }
        }
    
    private void MoveDown(BoardPiece boardPiece, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var fromFace = Game.Board.Pieces[boardPiece.Posistion + i * 5].Face;
                var toFace = Game.Board.Pieces[boardPiece.Posistion + i * 5+5].Face;

                Game.Board.Pieces[boardPiece.Posistion + i * 5 + 5].Face = fromFace;
                Game.Board.Pieces[boardPiece.Posistion + i * 5].Face = toFace;
            }
        }

        private void MoveLeft(BoardPiece boardPiece, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var fromFace = Game.Board.Pieces[boardPiece.Posistion - i].Face;
                var toFace = Game.Board.Pieces[boardPiece.Posistion - i -1].Face;

                Game.Board.Pieces[boardPiece.Posistion - i -1].Face = fromFace;
                Game.Board.Pieces[boardPiece.Posistion - i].Face = toFace;
            }
        }
        private void MoveRight(BoardPiece boardPiece, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var fromFace = Game.Board.Pieces[boardPiece.Posistion + i].Face;
                var toFace = Game.Board.Pieces[boardPiece.Posistion + i + 1].Face;

                Game.Board.Pieces[boardPiece.Posistion + i + 1].Face = fromFace;
                Game.Board.Pieces[boardPiece.Posistion + i].Face = toFace;
            }
        }




        public void SuggestBestMove()
        {

            List<Move> moves = new LeagalMoves().GetLeagalMoves();
            Move move = moves.OrderByDescending(x => x.Score).FirstOrDefault();

            if (move == null)
                throw new Exception("No possible move exists");

          


            Move(move);

        }


        public void Move(Move move)
        {
            List<Move> moves = new LeagalMoves().GetLeagalMoves();


            Move leagalmove = moves.FirstOrDefault(x => x.From == move.From && x.To == move.To);
            if (leagalmove == null)
            {
                throw new Exception("move not legal");
            }

            if (Game.Board.Pieces[move.From].Face == BoardPieceFace.Clear)
                Game.Board.Pieces[move.From].Face = Game.Activeplayer.Face;


            if (move.To - move.From >= 5)
            {
                MoveDown(Game.Board.Pieces[move.From], (move.To - move.From) / 5);
            }
            else if (move.From - move.To >= 5)
            {
                MoveUp(Game.Board.Pieces[move.From], (move.From - move.To) / 5);

            }
            else if (move.To - move.From > 0)
            {
                MoveRight(Game.Board.Pieces[move.From], (move.To - move.From));
            }
            else
            {
                MoveLeft(Game.Board.Pieces[move.From], (move.From - move.To));
            }

            LeagalMoves.CheckForWinning();
        }
    }
}
