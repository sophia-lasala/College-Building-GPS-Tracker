using System;
using System.Collections.Generic; 
//implements basic data structures 

class Dijkstra //based on Dijkstra's algorithm 
{
    public static List<Node> FindShortestPath(Graph graph, string startName, string endName) //needs to be called for pathmaking
    {
        var nodes = graph.GetAllNodes(); //store all nodes from graph within nodes variable
        var unvisited = new HashSet<Node>(); //creates hashset per node marking it either visited or unvisited 

        foreach (var node in nodes.Values) //set for each node value, make sure no data from previous searches are left
        {
            node.Distance = double.PositiveInfinity; //have an automatic high positive number to ensure paths always work
            node.Previous = null; //no previous node
            unvisited.Add(node); //add to HashSet
        }

        Node start = graph.GetNode(startName); // Node = (startName, endName, distance) 
        Node end = graph.GetNode(endName);
        start.Distance = 0;

        while (unvisited.Count > 0) // continues into all nodes needed are accessed 
        {
            Node? current = null!; //reset to default after each node
            double smallestDistance = double.PositiveInfinity; //reset to default after each node
            foreach (var n in unvisited) // each node in the hash set marked as unvisitied 
            {
                if (n.Distance < smallestDistance) //if node's distance is smaller it becomes the smallest distance until the best route is formed
                {
                    smallestDistance = n.Distance;
                    current = n;
                }
            }

            if (current == null!) //means node is not apart of the optimal route
                break;

            if (current == end) //reached the end node specified by the user
                break;

            unvisited.Remove(current); //removes from hashset so it's not selected again 

            foreach (var edge in current.OutgoingEdges) // calls list from Node class, accessed by Graph class when adding edges 
            {
                Node neighbor = edge.To; 
                if (!unvisited.Contains(neighbor)) //if neighbor isn't contained in unvisited HashSet
                    continue;

                double previous = current.Distance + edge.Weight; //all edge weights are 1 for our purposes so current Distance + 1 
                if (previous < neighbor.Distance) // if previous is less distance then neighbor 
                {
                    neighbor.Distance = previous; // then previous becomes distance
                    neighbor.Previous = current; // current is set to previous fo next node
                }
            }
        }

        var path = new List<Node>(); // where the path made is stored 
        Node pathNode = end; 
        while (pathNode != null) // if the last node isn't reached 
        {
            path.Add(pathNode); // add to list
            pathNode = pathNode.Previous; //goes from end to start of path
        }

        path.Reverse(); //reverses so its start to end
        return path; //returns final path
    }

    
}
