class Node
{
    public string Name { get; set;}
    public Coordinates Position { get; set; }
    public double Distance { get; set; } = double.PositiveInfinity; //default value to prevent errors 
    public Node? Previous { get; set; } = null; //default value to prevent errors 
    public List<Edge> OutgoingEdges { get; set; } = new List<Edge>(); //list all edges will be added to for pathfinding

    public void AddEdge(Node to, double weight) ////adds new Edge to list
    {
        OutgoingEdges.Add(new Edge(this, to, weight));  
    }
    
    public class Coordinates //organizes x and y values into one 
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public Node (string name, double x, double y) //constructor that forms Node object 
    {
        Name = name;
        Position = new Coordinates
        {
            X = x,
            Y = y
        };
    }
}
