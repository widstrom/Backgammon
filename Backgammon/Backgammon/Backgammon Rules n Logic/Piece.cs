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

        public string PieceColor
        {
            get { return this.m_pieceColor; }
            set { this.m_pieceColor = value; }
        }
    }
}