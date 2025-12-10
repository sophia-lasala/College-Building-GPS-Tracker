class HistoryManager
{
    private Stack<History> historyStack = new Stack<History>();

    public void AddEntry(string start, string end, List<Node>? path) //it should already grab the previous path so it doesn't need to be rerun
        //if it doesn't just make some variables and rerun the FindShortestPath command
    {
        History history = new History(start, end, path);
        historyStack.Push(history);
    }

     public List<History> GetList() //*important* converts the stack to a list so when a user clicks on an entry, its not limited by stack rules
    {
        return historyStack.ToList(); 
    }
}
