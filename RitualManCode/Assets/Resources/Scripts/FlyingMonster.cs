using UnityEngine;
using System.Collections;

public class FlyingMonster : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb2d;
    public Vector3 speed = new Vector3(0, 0, 0);
    public Collider2D platform;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
    }

    // If the player is within a certain range of a flying mosnter, it
    // chases the player
    void Update()
    {
        if (Mathf.Abs(rb2d.transform.position.x - player.transform.position.x) < 20)
        {
            if (rb2d.transform.position.x - player.transform.position.x < 0 && rb2d.transform.position.y - player.transform.position.y + 1 < 0)
            {
                rb2d.transform.Translate(Vector3.right * 1 * Time.deltaTime, Space.World);
                rb2d.transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
            }
            if (rb2d.transform.position.x - player.transform.position.x > 0 && rb2d.transform.position.y - player.transform.position.y + 1 < 0)
            {
                rb2d.transform.Translate(Vector3.left * 1 * Time.deltaTime, Space.World);
                rb2d.transform.Translate(Vector3.up * 1 * Time.deltaTime, Space.World);
            }
            if (rb2d.transform.position.x - player.transform.position.x < 0 && rb2d.transform.position.y - player.transform.position.y + 1 > 0)
            {
                rb2d.transform.Translate(Vector3.right * 1 * Time.deltaTime, Space.World);
                rb2d.transform.Translate(Vector3.down * 1 * Time.deltaTime, Space.World);
            }
            if (rb2d.transform.position.x - player.transform.position.x > 0 && rb2d.transform.position.y - player.transform.position.y + 1 > 0)
            {
                rb2d.transform.Translate(Vector3.left * 1 * Time.deltaTime, Space.World);
                rb2d.transform.Translate(Vector3.down * 1 * Time.deltaTime, Space.World);
            }
        }
    }
}
