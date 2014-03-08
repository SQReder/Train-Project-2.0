using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TrainProject.JunctionEditor
{
    public class JunctionRepository
    {
        private readonly List<Node> nodes_ = new List<Node>();
        private readonly List<Link> links_ = new List<Link>();

        #region Nodes manipulation
        
        /// <summary>
        /// Add node to repository
        /// </summary>
        /// <param name="node">Node ref to add into reposytory. If null or has duplicate in repo - do nothing.</param>
        public void AddNode(Node node)
        {
            if (node == null || nodes_.Contains(node))
                return;
            nodes_.Add(node);
        }

        /// <summary>
        /// Remove node and all assigned links from repository
        /// </summary>
        /// <param name="node">Node ref to remove. If null do nothing.</param>
        public void RemoveNode(Node node)
        {
            if (node == null)
                return;
            links_.RemoveAll(l => Equals(l.From, node) || Equals(l.To, node));
            nodes_.Remove(node);
        }


        /// <summary>
        /// List all nodes in reposytory
        /// </summary>
        /// <returns>Enumeration of node collection in repository</returns>
        public IEnumerable<Node> ListNodes()
        {
            return nodes_;
        }
        
        #endregion



        #region Links manipultion
        
        /// <summary>
        /// Add link to reposytory
        /// </summary>
        /// <param name="link">Link ref to add into reposytory. If null or has duplicate in repo - do nothing</param>
        public void AddLink(Link link)
        {
            if (link == null)
                return;

            var @from = nodes_.FirstOrDefault(n => n.Equals(link.From));
            if (@from == null)
            {
                nodes_.Add(link.From);
                @from = link.From;
            }

            var @to = nodes_.FirstOrDefault(n => n.Equals(link.To));
            if (@to == null)
            {
                nodes_.Add(link.To);
                @to = link.To;
            }

            if (Equals(@from, @to))
                throw new ArgumentException("Creating ring links not allowed");


            var linkToAdd = new Link
            {
                From = @from,
                To = @to,
                Length = link.Length
            };
            if (!links_.Contains(linkToAdd))
                links_.Add(linkToAdd);
        }

        /// <summary>
        /// Removes link from repository
        /// </summary>
        /// <param name="link">Link ref to remove. If null do nothing.</param>
        public void RemoveLink(Link link)
        {
            if (link == null)
                return;
            links_.Remove(link);
        }

        /// <summary>
        /// List all links in reposytory
        /// </summary>
        /// <returns>Enumeration of link collection in repository</returns>
        public IEnumerable<Link> ListLinks()
        {
            return links_;
        } 
        
        #endregion

        
        
        #region Selectors

        /// <summary>
        /// List links associated to node
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Enumeration of links connected to referenced node</returns>
        public IEnumerable<Link> ListLinksByNode(Node node)
        {
            return links_.Where(l => Equals(l.From, node) || Equals(l.To, node)).ToList();
        }

        /// <summary>
        /// Get first node with Selected flag
        /// </summary>
        /// <returns>First node from repository with Selected flag</returns>
        /// <seealso cref="ISelectable.Selected"/>
        public Node GetFirstSelectedNode()
        {
            return nodes_.FirstOrDefault(node => node.Selected);
        }

        /// <summary>
        /// Get first selected link
        /// </summary>
        /// <returns>First link from repository with Selected flag</returns>
        public Link GetFirstSelectedLink()
        {
            return links_.FirstOrDefault(link => link.Selected);
        }

        /// <summary>
        /// Update selection states of nodes in reposytory
        /// </summary>
        /// <param name="position">Point to check selection state for nodes</param>
        /// <seealso cref="ISelectable.UpdateSelectionState"/>
        public void UpdateSelectionStates(Point position)
        {
            nodes_.ForEach(n => n.UpdateSelectionState(position));
            links_.ForEach(l => l.UpdateSelectionState(position));
        }

        #endregion


        public string Serialize()
        {
            var sb = new StringBuilder();

            links_.ForEach(l => sb.AppendLine(JsonConvert.SerializeObject(l)));

            return sb.ToString();
        }

        public void Deserialize(string data)
        {
            Clear();

            var strings = data.Split('\n').Where(s => s != string.Empty).ToList();
            var links = strings.Select(JsonConvert.DeserializeObject<Link>).ToList();
            links.ForEach(l =>
            {
                AddNode(l.From);
                AddNode(l.To);
                AddLink(l);
            });
        }

        public void Clear()
        {
            links_.Clear();
            nodes_.Clear();
        }
    }
}
