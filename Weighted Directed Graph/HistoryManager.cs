class HistoryManager
{
    private Stack<History> historyStack = new Stack<History>();

    public void AddEntry(string start, string end, List<Node>? path)
    {
        History history = new History(start, end, path);
        historyStack.Push(history);
    }

     public List<History> GetList()
    {
        return historyStack.ToList(); 
    }
}
