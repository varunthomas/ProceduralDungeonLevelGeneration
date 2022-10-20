public class Obstacle
{

    float coordX;
    float coordY;
    string obstName;
    public bool isDestroyed;

    public Obstacle(string s, float x, float y)
    {
        obstName = s;
        coordX = x;
        coordY = y;
        isDestroyed = false;
    }

    public bool IsObstacleFound(float[] coordList)
    {
        if(coordList[0] == coordX && coordList[1] == coordY)
        {
            return true;
        }
        return false;
    }

    public void DestroyObstacle()
    {
        isDestroyed = true;

    }
}
