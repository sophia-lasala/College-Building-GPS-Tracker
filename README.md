# Graph-Based Indoor Navigation System

A basic navigation tool centered around a campus building's floor plan. Featuring an Android App interface, incoming students can use this tool to locate their classes and other important rooms within the building. This allows for a smoother transition into college life and makes maps more interactable and easier to understand. 

## How it Works 

### Frontend

The frontend of the code uses .NET Maui to simulate an Android-based app interface. A coordinate grid was implemented on top of a floor plan of the building in order to dynamically render navigation paths between the starting and ending points. While accounting for user-friendly GUI and a visually appealing interface. The app features multiple pages:

1. The starting page featuring drop down menus of the place the user is starting versus where they want to go. It also implements a visual graph showing the route the user must take, text-based directions, and a way to click their direction history up to the last five.
2. A page featuring an embedded video link showing the campus building the navigation system was built upon.
3. A credit pages highlighting who worked on the application.

(Worked on by Shalini Daniel) 

### Backend 

The backend of the code uses a directed weighted graph in order to account for hallways and only one entrance to a given room. Nodes were used to identify hallways and rooms, while edges were used to properly connect each room to it's hallway segment. Dijkstra's Algorithm was then implemented to find the ideal path between a starting node and an ending node. After this, user-friendly features were implemented. Step-by-step text-based instructions were produced by accounting for which direction the user would be facing after each node to properly specify which way a user would be going (ex: "straight", "left", or "right"). Lastly, a history feature was implemented that stored previous directions using a Stack. 

(Worked on by Sophia LaSala) 

## Plans for the Future 

For the future, we would like to create a more complicated algorithm that is able to handle multiple floors and complicated floor plans. Ultimately, creating a navigation system for a whole college. Additionally, we would like to implement an estimated time of arrival feature using the weights already implemented on the graph. Lastly, we would like to add more user-friendly features, such as the ability to search for starting and ending locations, and more helpful information on the college such as opening and closing times for specific buildings. 
