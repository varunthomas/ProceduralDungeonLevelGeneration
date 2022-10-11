
using UnityEngine;
public class Room
{

    public int room_num;
    int entryPoint;
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

    public void SetEntryPoint(int dir)
    {
        if(dir == 0)
        {
            entryPoint = 3;
        }
        else if(dir == 1)
        {
            entryPoint = 2;
        }
        else if(dir == 2)
        {
            entryPoint = 1;
        }
        else if(dir == 3)
        {
            entryPoint = 0;
        }
        Debug.Log("Entry point " + entryPoint);
    }

    public int GetEntryPoint()
    {
        return entryPoint;
    }

    public void SetPlayerPos(int entryPoint)
    {
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement> ();
        

        if(entryPoint == 0)
        {
            player.transform.position = new Vector2(0.59f, 3.0f);
            playerMovement.SetDirection(0);
        }
        else if(entryPoint == 1)
        {
            player.transform.position = new Vector2(9.1f, 0.48f);
            playerMovement.SetDirection(1);
        }
        else if(entryPoint == 2)
        {
            player.transform.position = new Vector2(-9.3f, 0.48f);
            playerMovement.SetDirection(2);
        }
        else if(entryPoint == 3)
        {
            player.transform.position = new Vector2(0.42f, -2.1f);
            playerMovement.SetDirection(3);
        }
    }
}
