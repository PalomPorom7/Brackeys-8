using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private AudioSource audioSource;

    [SerializeField]
    private LevelController level;

    [Header("Move")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;
    private float input;
    private Vector2 velocity;

    [Header("Jump")]
    [SerializeField]
    private GroundedCollider feet;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private float maxJumpHeight;
    private float jumpForce;

    [Header("Switch")]
    [SerializeField]
    private SpriteRenderer indicator;
    [SerializeField]
    private PlayerState state;

    public StateController  stateController;

    public PlayerState State => state;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();

        jumpForce = Mathf.Sqrt(maxJumpHeight * -2 * Physics2D.gravity.y * body.gravityScale) * body.mass;

        if(stateController == null)
            stateController = GetComponent<StateController>();
        
        feet.OnJumpEvent.AddListener(() => {
            // slight animmation here
        });

        feet.OnLandEvent.AddListener(() => {
            // Also maybe add some dust particles and animation
        });
    }

    public void Move(float x)
    {
        input = x;
    }
    private void FixedUpdate()
    {
        velocity = body.velocity;

        if (input == 0)
            velocity.x = Mathf.MoveTowards(velocity.x, 0, acceleration);
        else
            velocity.x += input * moveSpeed * acceleration;

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        body.velocity = velocity;
    }

    public void StartJump()
    {
        if (!feet.isGrounded && !feet.isSwimming)
            return;

        audioSource.PlayOneShot(jumpSound);

        if (feet.isSwimming)
            body.AddForce(new Vector2(0, jumpForce * 0.67f), ForceMode2D.Impulse);

        else if (feet.isGrounded)
            body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void StopJump()
    {
        if (body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, 0);
    }
    public void ChangeState()
    {
        if (state == PlayerState.horizontal)
            state = PlayerState.vertical;
        else
            state = PlayerState.horizontal;

        stateController.ChangeState();

        level.CheckExits();
    }

    public void SetActive(bool active)
    {
        indicator.enabled = active;

        if (active)
            return;

        Move(0);
        StopJump();
    }

    public void Happy(bool hasInput)
    {
        stateController.Happy(hasInput);
    }
}
