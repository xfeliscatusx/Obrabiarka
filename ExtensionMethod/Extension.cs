using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obrabiarka.ExtensionMethod
{
    public static class Extensions
    {
        public static List<TreeNode> GetParentNodes(this TreeView treeView)
        {
            List<TreeNode> results = new List<TreeNode>();
            foreach (TreeNode node in treeView.Nodes)
            {
                results.AddRange(GetNodes(node));
            }
            return results;
        }
        private static List<TreeNode> GetNodes(TreeNode parentNode)
        {
            List<TreeNode> results = new List<TreeNode>();
            if (parentNode.Nodes.Count > 0)
            {
                results.Add(parentNode);
                foreach (TreeNode node in parentNode.Nodes)
                {
                    results.AddRange(GetNodes(node));
                }
            }
            return results;
        }

        public static void MoveUp(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                }
            }
            else if (node.TreeView.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index > 0)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index - 1, node);
                }
            }
        }

        public static void MoveDown(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                }
            }
            else if (view != null && view.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index < view.Nodes.Count - 1)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index + 1, node);
                }
            }
        }
    }
}
