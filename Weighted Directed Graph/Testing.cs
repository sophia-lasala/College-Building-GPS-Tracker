class Testing{
    public static void Main(string[] args){
    Graph building = new Graph();
    building.InitializeBuilding();

    List<Node> path = Dijkstra.FindShortestPath(building, "Rm 301", "Exit B");

    Console.WriteLine("Path:");
    foreach (var node in path)
    {
        Console.WriteLine(node.Name);
    }
    }
}
