using UnityEngine;
using System.Collections;

public class platformController : MonoBehaviour
{
    // Moves platforms back and forth from min and max x-positions

    public float max;
    public float min;
    
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 3;
    }
    
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);
    }
}
