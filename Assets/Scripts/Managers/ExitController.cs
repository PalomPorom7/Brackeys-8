using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public PlayerState targetState;
    public LevelController levelController;

    int stateID;
    bool didComplete = false;
    GameObject player;
    

    void Start()
    {
        stateID = targetState == PlayerState.horizontal ? 6 : 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            didComplete = player.layer == stateID;
        }
        else
        {
            didComplete = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            didComplete = player.layer == stateID;
            levelController.CheckExits();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && player == collision.gameObject)
        {
            player = null;
        }
    }

    public bool CheckComplete()
    {
        return didComplete;
    }
}
