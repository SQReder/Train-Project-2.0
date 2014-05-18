using System.Collections.Generic;
using System.Linq;
using TrainProject.Model;

namespace TrainProject
{
    class PathFinder
    {
        private readonly JunctionRepository jr_;

        public PathFinder(JunctionRepository jr)
        {
            jr_ = jr;
        }

        public IEnumerable<List<Link>> FindAllPaths(string start, string end)
        {
            var nodes = jr_.ListNodes();
            var enumerable = nodes as Node[] ?? nodes.ToArray();
            var startNode = enumerable.FirstOrDefault(n => n.Title == start);
            var endNode = enumerable.FirstOrDefault(n => n.Title == end);

            return DriveDeep(startNode, endNode);
        }

        private IEnumerable<List<Link>> DriveDeep(Node startNode, Node endNode)
        {
            var firstLinks = jr_.ListLinksBeginsFromNode(startNode);
            var paths = new List<List<Link>>();
            foreach (var link in firstLinks)
            {                
                DriveDeep(link.To, endNode, new List<Link> {link}, new List<Node>(), paths);
            }
            return paths;
        }

        private void DriveDeep(Node currentNode, Node destinationNode, List<Link> path, ICollection<Node> passedNodes, ICollection<List<Link>> founded)
        {
            if (Equals(currentNode, destinationNode))
            {
                founded.Add(path);
                return;                
            }

            if (passedNodes.Contains(currentNode))
                return;
            
            var links = jr_.ListLinksBeginsFromNode(currentNode);
            foreach (var link in links)
            {
                var prolongedPath = new List<Link>(path) {link};
                var passed = new List<Node>(passedNodes) {link.From};
                DriveDeep(link.To, destinationNode, prolongedPath, passed, founded);
            }
        }
    }
}
