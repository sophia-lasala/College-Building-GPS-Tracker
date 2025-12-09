class Direction
{
    public List<string> BuildDirections(List<Node> path) //text based directions for pathmaking 
    {
        var directions = new List<string>(); //list that stores directions

        if (path.Count < 2) //implies start = end 
        {
            directions.Add("you're already at the destination");
            return directions;
        }
         
        string lastFacing = "east"; //sets as default direction being faced 

        for (int i = 0; i < path.Count - 1; i++) 
        {
            Node current = path[i];
            Node next = path[i + 1];

            double dx = next.Position.X - current.Position.X; //used to determine the horizontal direction by seeing how x changes
            double dy = next.Position.Y - current.Position.Y; //used to determine the vertical direction by seeing how y changes

            string step = $"{current.Name} → {next.Name}: "; 
            string facing;

            if (dx > 0) facing = "east"; // still facing east if change in x is positive
            else if (dx < 0) facing = "west"; //facing west if change in x is negative
            else facing = lastFacing; // if only moved vertically then way facing remains the same

            if (dx != 0) //if person stops moving on x axis then they will not begin moving on it again
            {
                step += "go straight";
            }
            else if (dy != 0) //means person did not yet go to a room or other location
            {
                if (facing == "east") //if facing east then y > 0 is left and y < 0 is right
                {
                    if (dy > 0) step += "turn left";
                    else step += "turn right";
                }
                else // facing west opposite directional cues
                {
                    if (dy > 0) step += "turn right";
                    else step += "turn left";
                }
            }

            lastFacing = facing; //continues after last step

            directions.Add(step); //adds to list
        }

        return directions; // once completed, returns list
    }

}
