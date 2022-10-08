using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
	public GameObject gridObject;
    private int[] neighborPresent;
    string level = "Room_NEWS";
	public static DungeonGenerator instance;

    
    Room currentRoom;
    int num_rooms = 5; //Minimum 5 rooms
    int gridSize;
    Room[,] rooms;
    char[] dirArray = new char[4];
 

	void Awake()
	{
		
		if (instance == null)
        {
            DontDestroyOnLoad (this.gameObject);
            instance = this;

            dirArray[0] = 'N';
            dirArray[1] = 'E';
            dirArray[2] = 'W';
            dirArray[3] = 'S';
            
            //max row and col size  if even = num_rooms +1 by num_rooms +1
            // max row and col size if odd = num_rooms by num_rooms
            if(num_rooms%2 == 0)
            {
                gridSize = num_rooms+1;
            }
            else
            {
                gridSize = num_rooms;
            }
            //rooms = new Room[gridSize][gridSize];

            currentRoom = generateFirstRoom();
            Debug.Log("Awake 1");
            
        }
        else
        {
            level = "Room_NEW";
            Debug.Log("Awake 2");
        }
		
	}
	
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        string prefabName;
        prefabName = currentRoom.getPrefabName();
        GameObject roomObject = (GameObject) Instantiate (Resources.Load (prefabName));
        roomObject.transform.SetParent(gridObject.transform);
        //num_rooms--;
        //BoxCollider2D dungeonDoor = roomObject.GetComponentInChildren<BoxCollider2D> ();
        //dungeonDoor.tag = "DungeonDoor";
        //GenerateDungeon();
    }

    // Update is called once per frame
    void Update()
    {
    }

    Room generateFirstRoom()
    {
        List<float> random_neigh_list = new List<float>() {0.25f,0.5f,0.75f,1.0f}; //This list is for randomly selecting a direction
        float rand_val;
        int rand_dir_index = 0;

        Room room = new Room(gridSize/2, gridSize/2);
        //middle = row_size or col_size /2
        //rooms[gridSize/2][gridSize/2] = room;
        num_rooms--;

        int num_neighbours = Random.Range(1,5); //Select the number of neighbors for the room randomly

        //Assign direction by iterating through min of num_rooms and num_neighbours
        for(int neighbour_index = 0; neighbour_index < Mathf.Min(num_rooms, num_neighbours); neighbour_index++)
        {
            rand_val = Random.value; //0.0 to 1.0
            foreach(float rand_neigh_index in random_neigh_list)
            {
                if(rand_val <= rand_neigh_index)
                {
                    AddNeighbour(rand_dir_index, room);
                    Debug.Log("rand idx " + rand_dir_index);
                    random_neigh_list.RemoveAt(rand_dir_index);
                    break;
                }
                rand_dir_index++;
            }
        }
        
        
        return room;
    }

    void AddNeighbour(int neigh_index, Room room)
    {
        char neighbour_dir = dirArray[neigh_index];
        if(neighbour_dir == 'N')
        {
            room.NeighbourList.Add('N');
        }
        else if(neighbour_dir == 'E')
        {
            room.NeighbourList.Add('E');
        }
        else if(neighbour_dir == 'W')
        {
            room.NeighbourList.Add('W');
        }
        else if(neighbour_dir == 'S')
        {
            room.NeighbourList.Add('S');
        }
    }
    /*void GenerateDungeon()
    {
        Room currentRoom;
        neighborPresent[0] = Random.Range(0,2); //N
        neighborPresent[1] = Random.Range(0,2); //E
        neighborPresent[2] = Random.Range(0,2); //W
        neighborPresent[3] = Random.Range(0,2); //S

        if(neighborPresent[0] == 0 && neighborPresent[1] == 0 && neighborPresent[2] == 0 && neighborPresent[3] == 0) //Invalid case. Set room as north
        {
            neighborPresent[0] = 1;
        }

        string prefabName = getPrefabName(neighborPresent);
        currentRoom.setPrefab(prefabName);

        currentRoom.generate
        GameObject roomObject = (GameObject) Instantiate (Resources.Load (prefabName));
        roomObject.transform.SetParent(gridObject.transform);
    }

    void getPrefabName(int neighborPresent)
    {
        string key = "Room_";

        if(neighborPresent[0] == 1)
        {
            key += "N";
        }
        if(neighborPresent[1] == 1)
        {
            key += "E";
        }        
        if(neighborPresent[2] == 1)
        {
            key += "W";
        }
        if(neighborPresent[3] == 1)
        {
            key += "S";
        }
    }*/

    void setCurrentRoom(Room room)
    {
        currentRoom = room;
    }
}
