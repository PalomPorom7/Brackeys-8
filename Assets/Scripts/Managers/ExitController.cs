using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    [SerializeField]
    private PlayerState targetState;

    [SerializeField]
    private LevelController levelController;

    [SerializeField]
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.GetComponentInParent<Player>();
            levelController.CheckExits();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player == collision.gameObject.GetComponentInParent<Player>())
            player = null;
    }

    public bool CheckComplete()
    {
        return player != null && player.State == targetState;
    }
}
