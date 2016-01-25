using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Backgammon_Rules_n_Logic
{
    public class PiecePlacement
    {
        //A two-dimentional array storing arrays
        private Piece[,][] m_Placement; //Stores 2X12 arrays
        private PieceManager m_pManager;
        private Piece[] m_Outs;
        private Piece[] m_Prison;

        public PiecePlacement()
        {
            InitiateMember();
        }

        private void InitiateMember()
        {
            m_Placement = new Piece[2, 12][];
            m_Outs = new Piece[30];
            m_pManager = new PieceManager();
            m_Prison = new Piece[30];
            SetStack();
            testAssigPiece();
        }

        private Piece[] Stack()
        {
            Piece[] p = new Piece[15];
            return p;
        }

        private Piece CreateEmptyPiece()
        {
            Piece p = new Piece();
            return p;
        }

        //Assign 15 stacks on each "triangle"
        private void SetStack()
        {
            int p = 0;
            for (int i = 0; i < m_Placement.GetLength(1); i++)
            {
                m_Placement[p, i] = this.Stack();
                if (i > 11 && p < 1)
                {
                    p++;
                    i = 0;
                }
            }

            //assign pieces (currently one)
            for (int i = 0; i < 1; i++)
                m_Placement[0, 2][i] = CreateEmptyPiece();
        }

        private void testAssigPiece()
        {
            for (int i = 0; i < 5; i++)
                m_Placement[0, 2][i] = m_pManager.RedPiece(i);

        }

        public void GetPlacement(int i, int j, int k, Piece p)
        {
            m_Placement[i, j][k] = p;
        }

        public bool CheckStack(Piece[,][] stack)
        {
            return stack[0, 2][0] != null ? true : false;
        }
        /////////////////////Rules

        private void ThrowOpponentOut()
        {

        }

        private void Prison()
        {
            if (m_Placement[0, 2][1] == null)
                m_Prison[0] = m_Placement[0, 2][0];
        }

        

        //Direction
        private int[] m_Player = new int[] { -1, 1 };
        private int DiceRoll;

        private int PlayerDirection(int player)
        {
            return DiceRoll * m_Player[player];
        }
    }
}
