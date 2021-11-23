using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float strafeSpeed;
    public float sensitivity;

    PlayerControls controls;
    PlayerControls.PlayerActions actions;

    Vector2 rawMoveAxisInput;
    float horizontalInput;

    private GameManager gameManager;
    private Score score;
    private float highScore;

#region Initialize Controls

    private void Awake()
    {
        controls = new PlayerControls();
        actions = controls.Player;

        actions.Move.performed += ctx => rawMoveAxisInput = ctx.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

#endregion

    private void Start()
    {
        //cache GameManager, Score, and High Score
        gameManager = FindObjectOfType<GameManager>();
        score = FindObjectOfType<Score>();
        highScore = PlayerPrefs.GetFloat("HighScore");

        //load sensitivity setting and adjust to a percentage
        sensitivity = (PlayerPrefs.GetFloat("Sensitivity") + 50) / 100f;
    }

    private void Update()
    {
        //Update strafe direction
        horizontalInput = rawMoveAxisInput.x;
    }

    void FixedUpdate()
    {
        //Apply constant forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //Apply strafe force
        rb.AddForce(horizontalInput * strafeSpeed * sensitivity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        //End game if falling off platform
        if (rb.position.y < 0.25f)
        {
            gameManager.gameHasEnded = true;
            score.enabled = false;

            //update the high score
            if (rb.position.z >= highScore)
            {
                PlayerPrefs.SetFloat("HighScore", rb.position.z);
                gameManager.newHighScore = true;
            }
        }
    }
}
