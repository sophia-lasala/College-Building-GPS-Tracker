class History
{
    // class to store history (I know captain obvious)
    public string LastStart { get; set; }
    public string LastEnd { get; set; }
    public List<Node>? LastPath { get; set; }

    public History( string start, string end, List<Node>? path)
    {
        LastStart = start;
        LastEnd = end;
        LastPath = path;
    }

     public override string ToString()
    {
        return $"{LastStart} → {LastEnd}";
    }
} 
