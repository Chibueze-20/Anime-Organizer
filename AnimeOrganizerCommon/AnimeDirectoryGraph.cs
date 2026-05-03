using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizerCommon
{
    public class AnimeDirectoryGraph
    {
        private AnimeFolder[] _nodes;
        private Node _root;

        public Node RootNode
        {
            get { return _root; }
        }
        public AnimeDirectoryGraph(AnimeFolder[] nodes)
        {
            _nodes = nodes;
            _root = new Node(null);
            initGraph();
        }

        /**
         * Searches the graph for the best matching AnimeFolder based on the provided search set.
         * Utilizes a self-pruning depth-first search (DFS) approach to efficiently find the best match.
         * We explore nodes in a hybrid queue-stack manner to maintain search order while allowing for pruning.
         * when we explore a node, we only enqueue its children if they have an equal or higher match weight than the current node.
         * the child nodes are added to the front of the queue to ensure they are explored next, maintaining a depth-first search behavior.
         * 
         * @param searchSet The set of tags to search for.
         * @return The best matching AnimeFolder, or null if no match is found.
         */
        public AnimeFolder SearchGraph(List<string> searchSet)
        {
            var bestMatch = null as AnimeFolder;
            var bestMatchWeight = -1;

            // run a self-pruning DFS on the directory graph and find the best match but maintain the search order using a hybrid queue-stack i.e alphabetical breadth first search order but depth first search pruning
            var frontInsertQueue = new FrontInsertQueue<AnimeDirectoryGraph.Node>();
            foreach (var node in _root.Children)
            {
                frontInsertQueue.Enqueue(node);
            }

            while (frontInsertQueue.Count > 0)
            {
                var currentNode = frontInsertQueue.Pop();
                var intersect =  UtillExtensions.IndexedListIntersect(currentNode.Self.SearchSet, searchSet);
                var matchWeight = intersect.Count();
                //perfect match found if both sets are equal
                bool perfectMatch = matchWeight == currentNode.Self.SearchSet.Count 
                                                && matchWeight == searchSet.Count 
                                                && searchSet.Count == currentNode.Self.SearchSet.Count;
                if (perfectMatch)
                {
                    return currentNode.Self;
                }

                // Update best match if current match weight is better and greater than 0 i.e at least one tag matches
                if (matchWeight >= bestMatchWeight && matchWeight > 0)
                {
                    bestMatchWeight = matchWeight;
                    bestMatch = currentNode.Self;
                }
                // Enqueue all child nodes that are worth exploring i.e same (non zero) or higher match weight than the current match weight, if there are child nodes to explore
                if (currentNode.Children == null)
                {
                    continue;
                }
                foreach (var child in currentNode.Children)
                {
                    var childMatchWeight = UtillExtensions.IndexedListIntersect(child.Self.SearchSet, searchSet).Count();
                    if (childMatchWeight >= matchWeight && childMatchWeight > 0) // child can be worth exploring
                    {
                        if (child.Self.SearchSet.Count <= searchSet.Count)
                        { // a child larger than search set will be a further deviation from a perfect match
                            frontInsertQueue.AddChild(child);
                        }
                    }

                }
            }
            // return the best match found or null if no match found
            return bestMatch;
        }

        private void initGraph()
        {
            foreach (AnimeFolder folder in _nodes)
            {
                insertNode(folder, _root);
            }
        }
        /**
         * Builds the graph by inserting based on search set intersection, using a greedy DFS approach.
         */
        private void insertNode(AnimeFolder folder, Node parent)
        {
            Node currentParent = parent;

            while (true)
            {
                // check if current parent is a leaf node, if so, insert here
                if (currentParent.isLeaf())
                {
                    Node newNode = new Node(folder);
                    currentParent.AddChild(newNode);
                    return;
                }

                bool inserted = false;
                if (currentParent.Children != null)
                {
                    foreach (Node child in currentParent.Children)
                    {
                        //get intersection count with current parent 
                        var intersectionCountToBeat = 0;
                        if (currentParent.Self != null)
                        {
                            intersectionCountToBeat = currentParent.Self.SearchSet.Intersect(folder.SearchSet).Count();
                        }
                        //see if any child has a higher intersection count than the current parent, if so, move down to that child and continue
                        if (child.Self.SearchSet.Intersect(folder.SearchSet).Count() > intersectionCountToBeat)
                        {
                            currentParent = child;
                            inserted = true;
                            break;
                        }
                    }
                }

                if (!inserted)
                {
                    Node newNode = new Node(folder);
                    currentParent.AddChild(newNode);
                    return;
                }
            }
        }


        public class Node
        {
            AnimeFolder _self;
            List<Node> children;

            internal Node(AnimeFolder self)
            {
                _self = self;
            }

            internal void AddChild(Node child)
            {
                if (children == null)
                {
                    children = new List<Node>();
                }
                children.Add(child);
            }

            public AnimeFolder Self
            {
                get { return _self; }
            }

            public List<Node> Children
            {
                get { return children; }
            }


            override
            public string ToString()
            {
                if (_self != null)
                {
                    return _self.ToString();
                }
                else
                {
                    return "Root";
                }
            }

            internal bool isLeaf()
            {
                return children == null || children.Count == 0;
            }

            internal bool isRoot()
            {
                return _self == null;
            }
        }
    }
}
