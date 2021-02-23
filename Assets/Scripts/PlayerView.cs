
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetHoriz;
    public Vector3 offsetVert;
    private bool flag = true;
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Landscape)
        {
            transform.position = player.position + offsetHoriz;
            if (flag)
                Debug.Log("Landscape");
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        { 
            transform.position = player.position + offsetVert;
            if (flag)
                Debug.Log("hello");
        }
        flag = false;
    }
}
