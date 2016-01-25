using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Backgammon_Rules_n_Logic
{
    public class PieceManager
    {
        //There are 30 pieces in total
        private Piece[] m_WhitePieces;
        private Piece[] m_RedPieces;

        public PieceManager()
        {
            m_WhitePieces = new Piece[15];
            m_RedPieces = new Piece[15];
            CreatePieces();
        }

        private void CreatePieces()
        {
            for (int i = 0; i < m_RedPieces.Length; i++)
            {
                Piece p = new Piece();
                p.PieceColor = "White";
                m_RedPieces[i] = p;
            }

            for (int i = 0; i < m_WhitePieces.Length; i++)
            {
                Piece p = new Piece();
                p.PieceColor = "Red";
                m_WhitePieces[i] = p;
            }
        }

        public Piece WhitePiece(int index)
        {
            return m_WhitePieces[index];
        }

        public Piece RedPiece(int index)
        {
            return m_RedPieces[index];
        }

        
        
        
    }
}
