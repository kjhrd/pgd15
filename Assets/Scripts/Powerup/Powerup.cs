using UnityEngine;

public class Powerup : MonoBehaviour
{
    public string type = "time+";

    public float value = 0f;

    public bool isPickable = true;

    public void Update()
    {
        if ( !isPickable )
        {
            Destroy( gameObject );
        }
    }
}
