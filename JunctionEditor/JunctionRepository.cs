using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TrainProject.JunctionEditor
{
    class JunctionRepository
    {
        private readonly List<Node> nodes_ = new List<Node>();
        private readonly List<Link> links_ = new List<Link>();

        #region Nodes manipulation
        
        public void AddNode(Node node)
        {
            if (nodes_.FirstOrDefault(n => n == node) != null)
                return;
            nodes_.Add(node);
        }


        public void RemoveNode(Node node)
        {
            if (node == null)
                return;
            links_.RemoveAll(l => l.From == node && l.To == node);
            nodes_.Remove(node);
        }


        public IEnumerable<Node> ListNodes()
        {
            return nodes_;
        }
        
        #endregion



        #region Links manipultion
        
        public void AddLink(Node from, Node to)
        {
            if (nodes_.Contains(from) && nodes_.Contains(to))
                links_.Add(new Link(from, to));
        }

        public void AddLink(Link link)
        {
            if (links_.FirstOrDefault(l => l == link) != null)
                return;

            links_.Add(link);
        }

        public void RemoveLink(Link link)
        {
            links_.Remove(link);
        }

        public IEnumerable<Link> ListLinks()
        {
            return links_;
        } 
        
        #endregion

        
        
        #region Selectors

        public IEnumerable<Link> ListLinksByNode(Node node)
        {
            return links_.Where(l => l.From == node || l.To == node).ToList();
        }

        public Node GetFirstSelectedNode()
        {
            return nodes_.FirstOrDefault(node => node.IsSelected());
        }

        public void UpdateSelectionStates(Point position)
        {
            nodes_.ForEach(n => n.UpdateSelectionState(position));
        }

        #endregion

    }
}
