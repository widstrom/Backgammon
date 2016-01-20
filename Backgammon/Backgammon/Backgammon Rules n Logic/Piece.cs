using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Backgammon_Rules_n_Logic
{
    public class Piece
    {
        private string m_pieceColor;
        private int m_position;

        public Piece()
        {
            m_pieceColor = string.Empty;
            m_position = 0;
        }

        public string PieceColor
        {
            get { return this.m_pieceColor; }
            set { this.m_pieceColor = value; }
        }

        public int Position
        {
            get { return this.m_position; }
            set { this.m_position = value; }
        }
    }
}
