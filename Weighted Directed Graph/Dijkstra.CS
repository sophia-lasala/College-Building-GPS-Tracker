using System;
using System.Collections.Generic;

class Dijkstra
{
    public static List<Node> FindShortestPath(Graph graph, string startName, string targetName)
    {
        var nodes = graph.GetAllNodes();
        var unvisited = new HashSet<Node>();

        foreach (var node in nodes.Values)
        {
            node.Distance = double.PositiveInfinity;
            node.Previous = null;
            unvisited.Add(node);
        }

        Node start = graph.GetNode(startName);
        Node target = graph.GetNode(endName);
        start.Distance = 0;

        while (unvisited.Count > 0)
        {
            Node current = null;
            double smallestDist = double.PositiveInfinity;
            foreach (var n in unvisited)
            {
                if (n.Distance < smallestDistance)
                {
                    smallestDistance = n.Distance;
                    current = n;
                }
            }

            if (current == null)
                break;

            if (current == target)
                break;

            unvisited.Remove(current);

            foreach (var edge in current.OutgoingEdges)
            {
                Node neighbor = edge.To;
                if (!unvisited.Contains(neighbor))
                    continue;

                double previous = current.Distance + edge.Weight;
                if (previous < neighbor.Distance)
                {
                    neighbor.Distance = previous;
                    neighbor.Previous = current;
                }
            }
        }

        var path = new List<Node>();
        Node pathNode = target;
        while (pathNode != null)
        {
            path.Add(pathNode);
            pathNode = pathNode.Previous;
        }

        path.Reverse();
        return path;
    }
}
