using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StickmanController : MonoBehaviour
{
    // Most of player behavior is implemented here
    private Rigidbody2D rb2d;
    private int health = 5;
    private int lives = 3;
    private int skull = 0;
    private string sblood = "skull:  ";
    private string slives = "lives:  ";
    private string shealth = "health:  ";
    private GUIStyle textStyle = new GUIStyle();

    string checkpoint;
    string nextDoor;
    string previousDoor;
    string currentTrap;

    // Displays number of skulls, lives, and health of player on top left of camera frame
    void OnGUI()
    {
        textStyle.fontSize = 40;
        GUI.Label(new Rect(10, 10, 200, 20), sblood + skull.ToString() + "/15  " + slives + lives.ToString() + "  " + shealth + health.ToString(), textStyle);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        checkpoint = "Door2";
        textStyle.normal.textColor = Color.white;
    }

    // Updates check for number of skulls. 15 means game is over.
    // Checks for key inputs that make the player move/jump/open doors
    void Update()
    {
        
        if (skull == 15)
        {
            SceneManager.LoadScene("Win screen");
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * 5 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * 5 * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown("space")) {
            if (rb2d.IsTouchingLayers())
            {
                rb2d.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            }
    }

        if (Input.GetKeyDown("up"))
        {

            if (gameObject.transform.position.x - GameObject.Find(previousDoor).transform.position.x < 1 &&
                gameObject.transform.position.x - GameObject.Find(previousDoor).transform.position.x > -1)
            {
                gameObject.transform.position = GameObject.Find(nextDoor).transform.position;
            }

            if (currentTrap.Substring(0, currentTrap.Length - 1).Equals("Trap"))
            {
                if (gameObject.transform.position.x - GameObject.Find(currentTrap).transform.position.x < 1 &&
                gameObject.transform.position.x - GameObject.Find(currentTrap).transform.position.x > -1)
                {
                    if (lives > 0)
                    {
                        if (health > 0)
                        {
                            health--;
                        }
                        if ( health==0)
                        {

                            gameObject.transform.position = GameObject.Find(checkpoint).transform.position;
                            lives--;
                            health = 5;
                        }

                        if (lives == 0)
                        {
                            SceneManager.LoadScene("End Screen");
                        }
                    }
                }
            }
        }
    }

    // Implementation of behavior of trigger objects.
    // Damaging traps, monsters, lives, collectibles, etc.
    void OnTriggerEnter2D(Collider2D other)
    {
        string name = other.gameObject.name;
        if (other.gameObject.CompareTag("Respawn"))
        {
            if (lives > 0)
            {
                if (health > 0)
                {
                    health--;
                }
                if (health == 0)
                {
                    gameObject.transform.position = GameObject.Find(checkpoint).transform.position;
                    lives--;
                    health = 5;
                }

                if (lives == 0)
                {
                    SceneManager.LoadScene("End Screen");
                }
            }
        }
        if (other.gameObject.CompareTag("heart"))
        {
            if (health <5)
            {
                other.gameObject.SetActive(false);
                health++;
            }
        }
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            skull++;
        }

        if (other.gameObject.CompareTag("Door"))
        {
            checkpoint = name;
            if (name.Substring(name.Length - 1).Equals("a"))
            {
                nextDoor = name.Substring(0, name.Length - 1);
                previousDoor = name;
            }
            else {
                nextDoor = name + "a";
                previousDoor = name;
            }
        }

        if (other.gameObject.CompareTag("trap"))
        {
            currentTrap = name;
        }
    }



}