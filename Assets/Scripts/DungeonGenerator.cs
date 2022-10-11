using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
	public GameObject gridObject;
	public static DungeonGenerator instance;

    Room currentRoom;
    int num_rooms = 10;
    int room_num = 1;
    string prefabName;

	void Awake()
	{
		//Instance is null for first time load scene. First time Awake with instance as null (if statement) is called and then start is called.
        //Second time, else part is called but start is not called.
		if (instance == null)
        {
            //To prevent from dungeon to get loaded again on scene change we use DontDestroyOnLoad
            DontDestroyOnLoad (this.gameObject);
            instance = this;

            currentRoom = generateFirstRoom();
            
        }
        else
        {
            //instance.currentRoom is called, otherwise currentRoom will be null here. Everytime we use member variables in else case, ie when instance is set, we need to access it through that instance
            prefabName = instance.currentRoom.getPrefabName();
            GameObject roomObject = (GameObject) Instantiate (Resources.Load (prefabName));
            roomObject.transform.SetParent(gridObject.transform);
            //New dungeon object will be created everytime awake happens. We only want the first dungeon object so we will destroy all other dungeon object ie dungeon objects generated when instance not null
            Destroy (this.gameObject);
        }
		
	}
	
    // Start is called before the first frame update
    void Start()
    {
        prefabName = currentRoom.getPrefabName();
        GameObject roomObject = (GameObject) Instantiate (Resources.Load (prefabName));
        roomObject.transform.SetParent(gridObject.transform);
    }

    Room generateFirstRoom()
    {
        Queue<Room> roomsToCreate = new Queue<Room> ();
        float rand_val;
        int rand_dir_index = 0;
        Room room;
       
        Room firstRoom = new Room(room_num);
        room_num++;
        roomsToCreate.Enqueue(firstRoom);
        num_rooms--;

        int num_neighbours;
        //Assign direction by iterating through the queue
        while(roomsToCreate.Count > 0)
        {
            num_neighbours = Mathf.Min(num_rooms, Random.Range(1,5)); //Select the number of neighbors for the room randomly. If room size is less than 4, we need to make sure that min of num_rooms and random range is selected
            room = roomsToCreate.Dequeue();
            num_neighbours = Mathf.Min(num_neighbours, room.getAvailableNeighCount()); //We take min num_neigh obtained above with available neighbours for the room so that num neighbours does not exeed available free neighbours

            //Select the neighbours randomly
            for(int i = 0; i <num_neighbours; i++)
            {
                rand_val = Random.value; // 0.0-1.0
                rand_dir_index = getRandomDirection(rand_val, room)-1;
                AddNeighbour(rand_dir_index, room, roomsToCreate);

            }
        }
        
        
        return firstRoom;
    }

    //Create neighbour room. Increment number of rooms created. Update available free neighbours for the neighbour rooms. Also update the NeighbourRoom map for the current room and the neighbour room
    void AddNeighbour(int neigh_index, Room room, Queue<Room> roomsToCreate)
    {
        Room neighRoom = new Room(room_num);
        room_num++;
        if(neigh_index == 0)
        {
            neighRoom.NeighbourList[3] = true;
            neighRoom.NeighbourRoom[3] = room;
        }
        else if(neigh_index == 1)
        {
            neighRoom.NeighbourList[2] = true;
            neighRoom.NeighbourRoom[2] = room;
        }
        else if(neigh_index == 2)
        {
            neighRoom.NeighbourList[1] = true;
            neighRoom.NeighbourRoom[1] = room;
        }
        else if(neigh_index == 3)
        {
            neighRoom.NeighbourList[0] = true;
            neighRoom.NeighbourRoom[0] = room;
        }
        roomsToCreate.Enqueue(neighRoom);
        room.NeighbourRoom[neigh_index] = neighRoom;
        num_rooms--;
    }

    // We divide N,E,W,S into ranges. If rand_value is between 0-0.25 N is selected. If rand_val is between 0.25-0.5, S is selected and so on
    // We also need to make sure that the selected direction is available
    int getRandomDirection(float rand_val, Room room)
    {
        float frac = 0.25f;

        for(int id = 1; id <= 4; id++)
        {
            if(rand_val < (float)frac*id && room.NeighbourList[id-1] == false)
            {
                room.NeighbourList[id-1] = true;
                return id;
            }
        }

        //Edge case: rand_val is for selecting South but South is already set to true, so we set dir as N,E or W depending on availability 
        for(int i=1; i<4; i++)
        {
            if(room.NeighbourList[i-1] == false)
            {
                room.NeighbourList[i-1] = true;
                return i;
            }
        }
        return 0;
    }

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    public void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }
}