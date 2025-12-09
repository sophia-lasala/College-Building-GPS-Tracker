class Graph
{
    private Dictionary<string, Node> nodes = new Dictionary<string, Node>(); //houses strings (names) and Node objects

    public Dictionary<string, Node> GetAllNodes() //accesses all nodes  
    {
        return nodes;
    }
    
    public void AddNode(Node node) //how nodes are added to Dictionary 
    {
        nodes[node.Name] = node;
    }

    public Node GetNode(string name) //accessing a specific node 
    {
        return nodes[name];
    }

    public void AddEdge(string fromName, string toName, double weight) //how edges are added to Dictionary 
    {
        Node from = GetNode(fromName);
        Node to = GetNode(toName);
        from.AddEdge(to, weight);
    }

    public void AddBidirectionalEdge(string a, string b, double weight) //this is a weighted directed graph however the directions 
        //are only needed to prevent pathfinding to skip hallways, therefore each edge that is allowed is bidirectional 
    {
        AddEdge(a, b, weight); //puts in both the forward direction
        AddEdge(b, a, weight); //and the reverse direction when following this method 
    }

    public void InitializeBuilding() //manually populates nodes and edges necessary for the building, *needs to be called* 
    {
        //From left to right
        // Nodes
        AddNode(new Node("Exit A", 0, 0));

        AddNode(new Node("Rm 301", 1, -1));
        AddNode(new Node("Rm 302", 1, 1));
        AddNode(new Node("Hall 301302", 1, 0));

        AddNode(new Node("Rm 303", 2, -1));
        AddNode(new Node("Rm 304", 2, 1));
        AddNode(new Node("Hall 303304", 2, 0));

        AddNode(new Node("Rm 305", 3, -1));
        AddNode(new Node("Rm 306", 3, 1));
        AddNode(new Node("Rm 306 A", 3.25, 1));
        AddNode(new Node("Rm 306 B", 3.75, 1));
        AddNode(new Node("Hall 305306", 3, 0));

        AddNode(new Node("Rm 308", 4, 1));
        AddNode(new Node("Rm 317", 4, -1));
        AddNode(new Node("Men's Restroom", 4.5, -1));
        AddNode(new Node("Hall 308317", 4, 0));

        AddNode(new Node("Rm 310", 5, 1));
        AddNode(new Node("Women's Restroom", 5, -1));
        AddNode(new Node("Exit B", 5.5, -1));
        AddNode(new Node("Hall 310", 5, 0));

        AddNode(new Node("Rm 312", 6, 1));
        AddNode(new Node("Rm 312 A", 6.25, 1));
        AddNode(new Node("Rm 312 B", 6.75, 1));
        AddNode(new Node("Rm 307", 6, -1));
        AddNode(new Node("Hall 307312", 6, 0));

        AddNode(new Node("Rm 314", 7, 1));
        AddNode(new Node("Rm 309", 7, -1));
        AddNode(new Node("Hall 309314", 7, 0));

        AddNode(new Node("Rm 316", 8, 1));
        AddNode(new Node("Rm 311", 8, -1));
        AddNode(new Node("Hall 311316", 8, 0));

        AddNode(new Node("Exit C", 9, 0));

        // Edges
        AddBidirectionalEdge("Exit A", "Hall 301302", 1);
        AddBidirectionalEdge("Hall 301302", "Rm 301", 1);
        AddBidirectionalEdge("Hall 301302", "Rm 302", 1);

        AddBidirectionalEdge("Rm 303", "Hall 303304", 1);
        AddBidirectionalEdge("Rm 304", "Hall 303304", 1);
        AddBidirectionalEdge("Hall 301302", "Hall 303304", 1);

        AddBidirectionalEdge("Rm 305", "Hall 305306", 1);
        AddBidirectionalEdge("Rm 306", "Hall 305306", 1);
        AddBidirectionalEdge("Rm 306 A", "Hall 305306", 1);
        AddBidirectionalEdge("Rm 306 B", "Hall 305306", 1);
        AddBidirectionalEdge("Hall 303304", "Hall 305306", 1);

        AddBidirectionalEdge("Rm 308", "Hall 308317", 1);
        AddBidirectionalEdge("Rm 317", "Hall 308317", 1);
        AddBidirectionalEdge("Men's Restroom", "Hall 308317", 1);
        AddBidirectionalEdge("Hall 305306", "Hall 308317", 1);

        AddBidirectionalEdge("Rm 310", "Hall 310", 1);
        AddBidirectionalEdge("Women's Restroom", "Hall 310", 1);
        AddBidirectionalEdge("Exit B", "Hall 310", 1);
        AddBidirectionalEdge("Hall 308317", "Hall 310", 1);

        AddBidirectionalEdge("Rm 312", "Hall 307312", 1);
        AddBidirectionalEdge("Rm 312 A", "Hall 307312", 1);
        AddBidirectionalEdge("Rm 312 B", "Hall 307312", 1);
        AddBidirectionalEdge("Rm 307", "Hall 307312", 1);
        AddBidirectionalEdge("Hall 310", "Hall 307312", 1);

        AddBidirectionalEdge("Rm 314", "Hall 309314", 1);
        AddBidirectionalEdge("Rm 309", "Hall 309314", 1);
        AddBidirectionalEdge("Hall 307312", "Hall 309314", 1);

        AddBidirectionalEdge("Rm 316", "Hall 311316", 1);
        AddBidirectionalEdge("Rm 311", "Hall 311316", 1);
        AddBidirectionalEdge("Hall 309314", "Hall 311316", 1);
        AddBidirectionalEdge("Hall 311316", "Exit C", 1);
    }
}
