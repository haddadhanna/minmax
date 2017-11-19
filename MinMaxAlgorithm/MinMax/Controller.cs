using System;
using System.Collections.Generic;

namespace MinMax
{
    public sealed class Controller<T> where T : Node<T>
    {
        #region Public Methods

        /// <summary>
        /// MiniMax algorithm
        /// </summary>
        /// <param name="node"></param>
        /// <param name="isMiximizingPlayer">true: maximizing the score; false: minimizing the score</param>
        /// <returns></returns>
        public T MiniMax(T node, bool isMiximizingPlayer)
        {
            List<T> children = node.GetChildren(isMiximizingPlayer);
            if (children == null || children.Count == 0 || node.IsGameOver() != GameResult.NoOverYet)
            {
                node.BestNode = node;
                node.BestSorce = node.GetScore();
                return node;
            }
            if (isMiximizingPlayer)
            {
                node.BestSorce = Int32.MinValue;
                foreach (var child in children)
                {
                    T retNode = MiniMax(child, false);
                    if (node.BestSorce < retNode.BestSorce)
                    {
                        node.BestSorce = retNode.BestSorce;
                        node.BestNode = retNode;
                    }
                }
                return node;
            }
            else
            {
                node.BestSorce = Int32.MaxValue;
                foreach (var child in children)
                {
                    T retNode = MiniMax(child, true);
                    if (retNode.BestSorce < node.BestSorce)
                    {
                        node.BestSorce = retNode.BestSorce;
                        node.BestNode = retNode;
                    }
                }
                return node;
            }
        }

        #endregion
    }
}