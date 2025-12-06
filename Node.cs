class Node
{
    public string Name { get; set;}
    public Coordinates Position { get; set; }
    List<Edge> OutgoingEdges { get; set; } = new List<Edge>();

    public void AddEdge(Node to, double weight)
    {
        OutgoingEdges.Add(new Edge(this, to, weight));
    }
    
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public Node (string name, int x, int y)
    {
        Name = name;
        Position = new Coordinates
        {
            X = x,
            Y = y
        };
    }
}
