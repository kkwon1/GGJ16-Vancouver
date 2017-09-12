using UnityEngine;
using System.Collections;

public class groundmonster : MonoBehaviour {

    // Monsters on the ground move back and forth from min and max x-positions

    public float max;
    public float min;

    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 12.5f;
    }

    void Update () {

        transform.position = new Vector3(Mathf.PingPong(Time.time * 4, max - min) + min, transform.position.y, transform.position.z);

    }
}
