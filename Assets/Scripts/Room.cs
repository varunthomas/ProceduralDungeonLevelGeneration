using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    int x_coord, y_coord;
    public List<char> NeighbourList = new List<char>();
    public Room(int x, int y)
    {
        x_coord = x;
        y_coord = y;
    }

    public string getPrefabName()
    {
        string prefabName = "Room_";
        foreach(char dir in NeighbourList)
        {
            if(dir == 'N')
            {
                prefabName += "N";
            }
            else if(dir == 'E')
            {
                prefabName += "E";
            }
            else if(dir == 'W')
            {
                prefabName += "W";
            }
            else if(dir == 'S')
            {
                prefabName += "S";
            }
        }
        return prefabName;
    }

}
