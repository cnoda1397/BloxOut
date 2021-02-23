using System.Collections;
using UnityEngine;
 
public class ProceduralGeneration : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject pointPrefab;

    //public GameObject rightWallPrefab;
    int zSpawn = 125; //distance to spawn 
    int xFloor = 20; //width of floor
    int yFloor = 1; //height of floor
    int yWall = 10; //height of wall
    float yWallSpawn = 5.5f; //height to spawn walls = .5yWall + .5yFloor
    float spawnTimer = 5f;
    public int spawnCount = 0;
    public float fwd = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
    }

    // Update is called once per frame
    IEnumerator Generate()
    {
        while (FindObjectOfType<GameManager>().isAlive)
        {
            Debug.Log(Time.time);
            var leftWall = Instantiate(wallPrefab);
            var rightWall = Instantiate(wallPrefab);
            //GENERATE RNG FOR WIDTHS OF WALLS
            int lengthLeftWall = Random.Range(1, (xFloor - 2)); //width of wall starting from left edge of floor to 1 space from right wall
            int lengthRightWall = Random.Range(1, (xFloor - 2) - lengthLeftWall);  //width of wall starting from right edge of floor to 1 space from left wall
            int xSpace = xFloor - lengthRightWall - lengthLeftWall; //space between the left and right walls
            float xLeft = (float)(lengthLeftWall - xFloor) / 2; //xCoord to spawn left wall
            float xRight = (float)(xFloor - lengthRightWall) / 2; //xCoor to spawn right wall
                                                                  //GENERATE RNG FOR HOW MANY LEVELS OF POINTS
            int ySpace = Random.Range(2, yWall);
            int yTop = yWall - ySpace;
            var topWall = Instantiate(wallPrefab);
            float xSpaceMid = xLeft + (float)(lengthLeftWall + xSpace) / 2; // 
            float ySpaceMid = (float)yWall - (float)yTop / 2 + (float)yFloor / 2;

            //wall prefabs are instantiated but we need to resize and move into position

            leftWall.GetComponent<Transform>().localScale = new Vector3(lengthLeftWall, yWall, 1);
            leftWall.GetComponent<Transform>().position = new Vector3(xLeft, yWallSpawn, zSpawn);

            rightWall.GetComponent<Transform>().localScale = new Vector3(lengthRightWall, yWall, 1);
            rightWall.GetComponent<Transform>().position = new Vector3(xRight, yWallSpawn, zSpawn);

            topWall.GetComponent<Transform>().localScale = new Vector3(xSpace, yTop, 1);
            topWall.GetComponent<Transform>().position = new Vector3(xSpaceMid, ySpaceMid, zSpawn);

            //link all 3 walls together - left=>top , top=>right

            leftWall.AddComponent<FixedJoint>();
            leftWall.GetComponent<FixedJoint>().connectedBody = topWall.GetComponent<Rigidbody>();
            topWall.AddComponent<FixedJoint>();
            topWall.GetComponent<FixedJoint>().connectedBody = rightWall.GetComponent<Rigidbody>();


            //Spawn Points:
            float xSpaceStart = xSpaceMid - (float)xSpace / 2; //need this bc the space does not begin at 0. this is more clean than changing both limits of j
            float ySpaceStart = (float)yFloor / 2 + .25f;
            for (float i = ySpaceStart; i < ySpace + (float)yFloor / 2; i += .5f)
            {
                for (float j = .25f; j < xSpace; j += .5f)
                {
                    var point = Instantiate(pointPrefab);
                    point.GetComponent<Transform>().position = new Vector3(xSpaceStart + j, i, zSpawn);
                }
            }
            if (spawnTimer > 2f)
            {
                spawnCount++;
                fwd += 2f;
                spawnTimer -= 1f;
            }
            yield return new WaitForSeconds(spawnTimer);
        }
    }
        /*
         Algorithm for spawning walls:
         * get x's
         * Instantiate leftWall at xLeftWall/2 - 5      //spawn center of wall at half distance from left edge of floor
         * Instantiate rightWall at xRightWall/2 + 5    //spawn center of wall at half distance from right edge of floor
         Algorithm for spawning Points:
         * get x and y
         * for(height = 0, height < y, height+= .25){   //spawn 4 points every cube width
         *  for(width = 0, width < x, width += .25){
         *      
         *  
         */
}
