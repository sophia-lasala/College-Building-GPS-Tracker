class Direction
{
    public List<string> BuildDirections(List<Node> path)
    {
        var directions = new List<string>();

        if (path.Count < 2)
        {
            directions.Add("you're already at the destination");
            return directions;
        }
         
        string lastFacing = "east";

        for (int i = 0; i < path.Count - 1; i++)
        {
            Node current = path[i];
            Node next = path[i + 1];

            double dx = next.Position.X - current.Position.X;
            double dy = next.Position.Y - current.Position.Y;

            string step = $"{current.Name} → {next.Name}: ";
            string facing;

            if (dx > 0) facing = "east";
            else if (dx < 0) facing = "west";
            else facing = lastFacing;

            if (dx != 0)
            {
                step += "go straight";
            }
            else if (dy != 0)
            {
                if (facing == "east")
                {
                    if (dy > 0) step += "turn left";
                    else step += "turn right";
                }
                else 
                {
                    if (dy > 0) step += "turn right";
                    else step += "turn left";
                }
            }

            lastFacing = facing;

            directions.Add(step);
        }

        return directions;
    }

}
