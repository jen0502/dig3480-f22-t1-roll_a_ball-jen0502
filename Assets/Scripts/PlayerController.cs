using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;
    private int lives;

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Set the count to zero 
        count = 0;
        lives = 3;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
        }
        if (count == 12) 
{
    transform.position = new Vector3(39.66f, 0.5f, .37f); 
}
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 20)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
        livesText.text = "Lives: " + lives.ToString();

        if (lives == 0)
        {
            loseTextObject.SetActive(true);

        }
    }
}

