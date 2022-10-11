using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{

    public int room_num;
    public bool[] NeighbourList = new bool[4];
    public Room[] NeighbourRoom = new Room[4];

    public Room(int n)
    {
        room_num = n;
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

    public int getAvailableNeighCount()
    {
        int count = 0;
        for(int i=0 ; i<4; i++)
        {
            if(NeighbourList[i] == false)
            {
                count++;
            }
        }
        return count;
    }

    

}
