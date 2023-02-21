using UnityEngine;

/*
 * Accepts all input from the player and directs it to the necessary game components
 */
public class InputController : MonoBehaviour
{
    [SerializeField]
    private LevelController level;

    [SerializeField]
    private Player player1, player2;

    private Player currentPlayer;
    private float horizontalInput;

    private void Start()
    {
        if(level == null)
            level = FindObjectOfType<LevelController>();

        currentPlayer = player1;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        if (Input.GetButtonDown("Reset"))
            level.Reset();

        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Switch"))
        {
            if(currentPlayer == player1)
            {
                player1.SetActive(false);
                currentPlayer = player2;
                player2.SetActive(true);
            }
            else if(currentPlayer == player2)
            {
                player2.SetActive(false);
                currentPlayer = player1;
                player1.SetActive(true);
            }
        }
        if(Input.GetButtonDown("Jump"))
            currentPlayer.StartJump();

        if(Input.GetButtonUp("Jump"))
            currentPlayer.StopJump();

        if(Input.GetButtonDown("ChangeState"))
        {
            player1.ChangeState();
            player2.ChangeState();
        }
        if(horizontalInput == 0)
            currentPlayer.Happy(false);
        else
            currentPlayer.Happy(true);
        
    }
    private void FixedUpdate()
    {
        currentPlayer.Move(horizontalInput);
    }
}
