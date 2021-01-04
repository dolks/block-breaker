using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    float randomFactor = 1f;
    Vector2 paddleToBallVector;
    bool launched = false;
    Rigidbody2D rigidBody2D;
    [SerializeField] Vector2 maxVelocity = new Vector2(4, 4);

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            launched = true;
            rigidBody2D.velocity = new Vector2(1f, 5f);
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityRandomness = new Vector2(
            Random.Range(0, randomFactor), 
            Random.Range(0, randomFactor));
        if (launched)
        {
            GetComponent<AudioSource>().Play();
            if (rigidBody2D.velocity.x > maxVelocity.x)
            {
                rigidBody2D.velocity.Set(maxVelocity.x, rigidBody2D.velocity.y);
            }
            if (rigidBody2D.velocity.y > maxVelocity.y)
            {
                rigidBody2D.velocity.Set(rigidBody2D.velocity.x, maxVelocity.y);
            }
            rigidBody2D.velocity += velocityRandomness;
        }
    }
}
