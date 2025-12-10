class Testing
{
    public static void Main(string[] args)
    {
        Graph building = new Graph(); //object for Graph class
        building.InitializeBuilding(); //populates with all nodes and edges necessary for building
        HistoryManager historyManager = new HistoryManager(); //object for HistoryManager class
        Direction direction = new Direction(); //object for Direction class 
        List<Node> path = Dijkstra.FindShortestPath(building, "Rm 302", "Rm 317"); //the rooms would be user inputted in reality 
        //basically Dijkstra.FindShortestPath(building, startNode, endNode) essential for path making
        historyManager.AddEntry("Rm 302", "Rm 317", path); //adds to history as a stack entry

        Console.WriteLine("Path:"); 
        foreach (var node in path)  //not needed just proof of where each path goes
        {
            Console.WriteLine(node.Name);
        }

        List<string> directions = direction.BuildDirections(path); //builds list of path that was made to use for directions 
        //calls BuildDirections method to make the directions via Directions class

        Console.WriteLine("\nDirections:");
        foreach (var step in directions) //what would be used for the directions on the app 
        {
            Console.WriteLine(step);
        }

        historyManager.GetList(); //gets the history list of previous paths taken
        Console.WriteLine("\nHistory:");
        foreach (var entry in historyManager.GetList()) //displays the history of paths taken
        {
            Console.WriteLine(entry.ToString());
        }
    }
}
