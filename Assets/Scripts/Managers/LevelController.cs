using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string NextLevel = "";
    public ExitController[] exits;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckExits()
    {
        if (exits[0].CheckComplete() && exits[1].CheckComplete())
        {
            Debug.Log("Level Complete");
            if (NextLevel != "")
            {
                SceneManager.LoadScene(NextLevel);
            }
        }
    }
}
