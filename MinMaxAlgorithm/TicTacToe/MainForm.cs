using MinMax;
using System;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// Human player is O => 0
    /// Computer is X => 1
    /// </summary>
    public partial class MainForm : Form
    {
        
        #region Static 

        public static int?[] GameBoard = new int?[9];

        #endregion

        #region Private Fields

        private bool isGameEnded;

        #endregion

        #region Ctor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void label_Click(object sender, EventArgs e)
        {
            if (!this.isGameEnded)
            {
                Label lblPressed = sender as Label;
                if (lblPressed != null && string.IsNullOrEmpty(lblPressed.Text))
                {
                    lblPressed.Text = "O";
                    int lblIndex = Convert.ToInt32(lblPressed.Tag);
                    MainForm.GameBoard[lblIndex] = 0;

                    TTTNode node = new TTTNode();
                    node.GameBoard = MainForm.GameBoard;
                    GameResult resultForNow = node.IsGameOver();
                    if (resultForNow == GameResult.NoOverYet)
                    {
                        Controller<TTTNode> controller = new Controller<TTTNode>();
                        TTTNode retNode = controller.MiniMax(node, true);
                        retNode = retNode.BestNode;

                        int retIndex = this.GetTheIndex(retNode.GameBoard);
                        MainForm.GameBoard[retIndex] = 1;
                        this.panelHolder.Controls.Find(string.Format("label{0}", retIndex), false)[0].Text = "X";

                        retNode = new TTTNode();
                        retNode.GameBoard = MainForm.GameBoard;
                        resultForNow = retNode.IsGameOver();
                        if (resultForNow != GameResult.NoOverYet)
                        {
                            string message = resultForNow == GameResult.AIWin ? "Computer Wins"
                            : resultForNow == GameResult.Draw ? "Game Draw"
                            : "Player Wins";
                            this.isGameEnded = true;
                            MessageBox.Show(message);
                        }
                    }
                    else
                    {
                        string message = resultForNow == GameResult.AIWin ? "Computer Wins"
                            : resultForNow == GameResult.Draw ? "Game Draw"
                            : "Player Wins";
                        this.isGameEnded = true;
                        MessageBox.Show(message);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isGameEnded = false;
            MainForm.GameBoard = new int?[9];
            this.label0.Text =
                this.label1.Text =
                this.label2.Text =
                this.label3.Text =
                this.label4.Text =
                this.label5.Text =
                this.label6.Text =
                this.label7.Text =
                this.label8.Text = string.Empty;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Implementing unbeatable Tic Tac Toe using MinMax algorithm, Hanna Haddad");
        }

        #endregion

        #region Private Methods

        private int GetTheIndex(int?[] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i].HasValue)
                {
                    if (!MainForm.GameBoard[i].HasValue)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        #endregion

       
    }
}
