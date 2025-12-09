class Edge
{
    //Edge based on neighboring nodes and the weight
    public Node From { get; } 
    public Node To { get; }
    public double Weight { get; }

    public Edge(Node from, Node to, double weight) //constructor to create Edge object
    {
        From = from;
        To = to;
        Weight = weight;
    }
}
