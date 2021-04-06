
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetHoriz;
    public Vector3 offsetVert;
    private bool debug = false;
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Landscape)
        {
            transform.position = player.position + offsetHoriz;
            if (debug)
                Debug.Log("Landscape");
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        { 
            transform.position = player.position + offsetVert;
            if (debug)
                Debug.Log("Portrait");
        }
        debug = false;
    }
}
