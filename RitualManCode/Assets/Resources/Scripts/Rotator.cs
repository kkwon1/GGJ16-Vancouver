using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    // Moves objects back and forth from min and max x-positions
    // (template for the platform and ground monster scripts)

    public float max;
    public float min;

    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 12.5f;
    }
    
    void Update () {

        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.y, transform.position.z);

    }
}
