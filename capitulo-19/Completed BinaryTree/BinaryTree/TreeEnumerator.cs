using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTree
{
    class TreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        public TreeEnumerator(Tree<T> data)
        {
            this.currentData = data;
        }

        private void populate(Queue<T> enumQueue, Tree<T> tree)
        {
            if (tree.LeftTree != null)
            {
                populate(enumQueue, tree.LeftTree);
            }

            enumQueue.Enqueue(tree.NodeData);

            if (tree.RightTree != null)
            {
                populate(enumQueue, tree.RightTree);
            }
        }

        private Tree<T> currentData = null;
        private T currentItem = default(T);
        private Queue<T> enumData = null;

        #region IEnumerator<T> Members

        T IEnumerator<T>.Current
        {
            get
            {
                if (this.enumData == null)
                    throw new InvalidOperationException("Use MoveNext before calling Current");

                return this.currentItem;
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            // throw new NotImplementedException();
        }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }

        bool System.Collections.IEnumerator.MoveNext()
        {
            if (this.enumData == null)
            {
                this.enumData = new Queue<T>();
                populate(this.enumData, this.currentData);
            }

            if (this.enumData.Count > 0)
            {
                this.currentItem = this.enumData.Dequeue();
                return true;
            }

            return false;
        }

        void System.Collections.IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
