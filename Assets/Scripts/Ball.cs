using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;

    // state
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;
    private Rigidbody2D rb;

    // Cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;

        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rb.velocity = new Vector2(xPush, yPush);
            rb.simulated = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,
                    paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}