using UnityEngine;

public class GroundFollow : MonoBehaviour
{

    public Transform target;
    private Vector3 newLocation;
    public Vector3 offset;

    void Update()
    {
        //Lock x & y to their original position in scene
        newLocation.x = transform.position.x + offset.x;
        newLocation.y = transform.position.y + offset.y;
        
        //set z to follow target
        newLocation.z = target.position.z + offset .z;

        //update to new transform position
        transform.position = newLocation;
    }
}
