using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    int x_coord, y_coord;
    public bool[] NeighbourList = new bool[4];

    public int availableRooms;
    public Room(int x, int y)
    {
        availableRooms = 4;
        x_coord = x;
        y_coord = y;
    }

    public string getPrefabName()
    {
        string prefabName = "Room_";

            if(NeighbourList[0] == true)
            {
                prefabName += "N";
            }
            if(NeighbourList[1] == true)
            {
                prefabName += "E";
            }
            if(NeighbourList[2] == true)
            {
                prefabName += "W";
            }
            if(NeighbourList[3] == true)
            {
                prefabName += "S";
            }
        
        return prefabName;
    }

}
