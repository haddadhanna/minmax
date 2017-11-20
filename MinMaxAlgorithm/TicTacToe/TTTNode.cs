using MinMax;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TTTNode : Node<TTTNode>
    {
        #region Properties

        public int?[] GameBoard { get; set; }

        #endregion

        #region Public Methods

        public override List<TTTNode> GetChildren(bool isMaximizing)
        {
            List<TTTNode> nodes = new List<TTTNode>();
            for (int i = 0; i < 9; i++)
            {
                if(!this.GameBoard[i].HasValue)
                {
                    int?[] newBoard = new int?[9];
                    GameBoard.CopyTo(newBoard, 0);
                    newBoard[i] = isMaximizing ? 1: 0;
                    nodes.Add(new TTTNode{
                        GameBoard = newBoard
                    });
                }
            }
            return nodes;
        }

        public override int GetScore()
        {
            int n = 0;
            if ((GameBoard[0] == n && GameBoard[3] == n && GameBoard[6] == n)
                || (GameBoard[0] == n && GameBoard[1] == n && GameBoard[2] == n)
                || (GameBoard[0] == n && GameBoard[4] == n && GameBoard[8] == n)
                || (GameBoard[1] == n && GameBoard[4] == n && GameBoard[7] == n)
                || (GameBoard[2] == n && GameBoard[4] == n && GameBoard[6] == n)
                || (GameBoard[2] == n && GameBoard[5] == n && GameBoard[8] == n)
                || (GameBoard[3] == n && GameBoard[4] == n && GameBoard[5] == n)
                || (GameBoard[6] == n && GameBoard[7] == n && GameBoard[8] == n))
                return -1;
            else
            {
                n = 1;
                if ((GameBoard[0] == n && GameBoard[3] == n && GameBoard[6] == n)
                    || (GameBoard[0] == n && GameBoard[1] == n && GameBoard[2] == n)
                    || (GameBoard[0] == n && GameBoard[4] == n && GameBoard[8] == n)
                    || (GameBoard[1] == n && GameBoard[4] == n && GameBoard[7] == n)
                    || (GameBoard[2] == n && GameBoard[4] == n && GameBoard[6] == n)
                    || (GameBoard[2] == n && GameBoard[5] == n && GameBoard[8] == n)
                    || (GameBoard[3] == n && GameBoard[4] == n && GameBoard[5] == n)
                    || (GameBoard[6] == n && GameBoard[7] == n && GameBoard[8] == n))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override MinMax.GameResult IsGameOver()
        {
            int res = this.GetScore();
            if (res == -1)
            {
                return GameResult.HumanWin;
            }
            else
            {
                if (res == 1)
                {
                    return GameResult.AIWin;
                }
                else
                {

                    var valv = this.GameBoard.Select((val, index) => new { index, val }).FirstOrDefault(x => !x.val.HasValue);
                    if (valv != null)
                    {
                        return GameResult.NoOverYet;
                    }
                    else
                    {
                        return GameResult.Draw;
                    }
                }
            }
        }

        #endregion
    }
}
