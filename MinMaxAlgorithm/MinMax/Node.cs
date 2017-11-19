using System.Collections.Generic;

namespace MinMax
{
    public abstract class Node<T> where T : Node<T>
    {
        #region Properties

        public int BestSorce { get; internal set; }
        public T BestNode { get; internal set; }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// generate all the expected moves
        /// </summary>
        /// <param name="isMaximizing"></param>
        /// <returns></returns>
        public abstract List<T> GetChildren(bool isMaximizing);

        /// <summary>
        /// returns the score of the move
        /// </summary>
        /// <returns></returns>
        public abstract int GetScore();

        /// <summary>
        /// check the result of the game
        /// </summary>
        /// <returns></returns>
        public abstract GameResult IsGameOver();

        #endregion
    }
}
