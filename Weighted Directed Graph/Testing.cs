class Testing
{
    public static void Main(string[] args)
    {
        Graph building = new Graph();
        building.InitializeBuilding();

        Direction direction = new Direction();
        List<Node> path = Dijkstra.FindShortestPath(building, "Rm 302", "Rm 317");

        Console.WriteLine("Path:");
        foreach (var node in path)
        {
            Console.WriteLine(node.Name);
        }

        List<string> directions = direction.BuildDirections(path);

        Console.WriteLine("\nDirections:");
        foreach (var step in directions)
        {
            Console.WriteLine(step);
        }
    }
}
