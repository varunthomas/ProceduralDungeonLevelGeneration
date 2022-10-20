using System.Collections.Generic;
using UnityEngine;
public class Room
{

    public int room_num;
    int entryPoint;
    List<float[]> obstMap = new List<float[]>(); //List of coordinates(x,y)
    public bool[] NeighbourList = new bool[4];
    public Room[] NeighbourRoom = new Room[4];
    List<Obstacle> obstList = new List<Obstacle>();


    

    public Room(int n)
    {
        room_num = n;
    }

    public void AddObstacle(float x, float y)
    {    
        Debug.Log("Calling add neighbour for room " + room_num);
        if(isRockOverlapping(x,y) || isEntranceOverlapping(x,y))
        {
            return;
        }

        float[] obstacleCoord = new float[2];
        Obstacle obstacle = new Obstacle("Rock", x, y); 
        AddObstacleInstance(obstacle);
        obstacleCoord[0] = x;
        obstacleCoord[1] = y;
        Debug.Log("Adding obst x: " + obstacleCoord[0] + " y: " +obstacleCoord[1]);
        obstMap.Add(obstacleCoord);
    }

    //Check if the coordinates of the new rock overlaps with any existing rocks.
    bool isRockOverlapping(float x, float y)
    {
        for(int j = 0; j < obstMap.Count; j++)
        {
            if((obstMap[j][0] <= x && x <= obstMap[j][0] + 0.9077368f) || (x <= obstMap[j][0] && obstMap[j][0] <= x + 0.9077368f))
            {
                //dont add
                return true;
            }
            if((obstMap[j][1] <= y && y <= obstMap[j][1] + 0.8923962f) || (y <= obstMap[j][1] && obstMap[j][1] <= y + 0.8923962f))
            {
                //dont add
                return true;
            }

        }
        return false;
    }

    bool isEntranceOverlapping(float x, float y)
    {
        //Check if Rock is at North entrance
        if((y >= 1.97f && y <= 3.04f) && (x >= 0f && x <= 1f))
        {
            Debug.Log("overlapping player N " + x  + " " + y + " roomnum " + room_num);
            return true;
        }
       //Check if Rock is at South entrance
        if((y >= -3.0f && y <= -1.97f) && (x >= -1.16f && x <= -0.28f))
        {
            Debug.Log("overlapping player S  " + x  + " " + y + " roomnum " + room_num);
            return true;
        }
        //Check if Rock is at East entrance
        if((y >= -0.17f && y <= 1.23f) && (x >= -9.93f && x <= -8.85f))
        {
            Debug.Log("overlapping player E " + x  + " " + y + " roomnum " + room_num);
            return true;
        }
        //Check if Rock is at West entrance
        if((y >= -0.28f && y <= 1.12f) && (x >= 8.86f && x <= 10f))
        {
            Debug.Log("overlapping player W  " + x  + " " + y + " roomnum " + room_num);
            return true;
        }
        
        return false;

    }
    public List<float[]> getObstacleCoord()
    {
        return  obstMap;
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

    void AddObstacleInstance(Obstacle obstacle)
    {
        obstList.Add(obstacle);
    }

    public Obstacle FindObstInstance(float[] coordList)
    {
        foreach(Obstacle obs in obstList)
        {
            if(obs.IsObstacleFound(coordList))
            {
                return obs;
            }
        }
        return null;
    }
}
