class Node
{
    public string Name { get; set;}
    public Coordinates Position { get; set; }
    public double Distance { get; set; } = double.PositiveInfinity;
    public Node Previous { get; set; } = null;
    
    List<Edge> OutgoingEdges { get; set; } = new List<Edge>();

    public void AddEdge(Node to, double weight)
    {
        OutgoingEdges.Add(new Edge(this, to, weight));
    }
    
    public class Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public Node (string name, double x, double y)
    {
        Name = name;
        Position = new Coordinates
        {
            X = x,
            Y = y
        };
    }
}
