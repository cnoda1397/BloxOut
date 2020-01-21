using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject leftWallPrefab;
    //public GameObject rightWallPrefab;
    int zSpawn = 150; //deistance to spawn 
    int xFloor = 20;
    int yWall = 10;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Generate()
    {
        var leftWall = Instantiate(leftWallPrefab);
        //var rightWall = Instantiate(rightWallPrefab);
        //GENERATE RNG FOR WIDTHS OF WALLS
        int lengthLeftWall = Random.Range(1, (xFloor - 2)); //width of wall starting from left edge of floor to 1 space from right wall
        int lengthRightWall = Random.Range(1, (xFloor - 2) - lengthLeftWall);     //width of wall starting from right edge of floor to 1 space from left wall
        int xPoint = lengthRightWall - lengthLeftWall; //This logic probably need some tweeking. Idea is that there should be a space between right edge of left wall and left edge of right
        
        //GENERATE RNG FOR HOW MANY LEVELS OF POINTS
        int yPoint = Random.Range(4, 40); //At some point, spawn red cubes in line to limit how high the player should grow. if player hits this line: GAME OVER or lose life point


        //rightWall.GetComponent<Transform>().localScale = new Vector3(lengthRightWall, yWall, 1);
        //rightWall.GetComponent<Transform>().position = new Vector3(lengthRightWall + xFloor / 2, 1, 125);
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

        //Change values IN EVERYTHING
        leftWall.GetComponent<Transform>().localScale = new Vector3(lengthLeftWall, yWall, 1);
        leftWall.GetComponent<Transform>().position = new Vector3((float)lengthLeftWall / 2 - (float)xFloor / 2, 5.5f, 125);
        //if (lengthLeftWall % 2 == 0)
        //    leftWall.GetComponent<Transform>().position = new Vector3(lengthLeftWall / 2 - xFloor / 2 + 1f, 1, 125);
        //else
        //    leftWall.GetComponent<Transform>().position = new Vector3(lengthLeftWall / 2 - xFloor / 2 + 1f, 1, 125);

        /*rightWall.GetComponent<Transform>().localScale = new Vector3(lengthRightWall, yWall, 1);
        if (lengthRightWall % 2 != 0)
            rightWall.GetComponent<Transform>().position = new Vector3(xFloor / 2 - lengthRightWall / 2, 1, 125);
        else
            rightWall.GetComponent<Transform>().position = new Vector3(xFloor / 2 - lengthRightWall / 2 - .5f, 1, 125);*/

    }
}
