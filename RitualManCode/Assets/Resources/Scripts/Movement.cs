using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    // Unused code (was developed to slow down player movement)

    Animator animator;
    public float timeToGo;
    public float moveSpeed;

    void Start()
    {
        timeToGo = Time.fixedTime + 0.2f;
        moveSpeed = 5.0f;
    }

    void FixedUpdate()
    {

        if (Time.fixedTime >= timeToGo)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
       timeToGo = Time.fixedTime + 0.2f;
        }
    }

