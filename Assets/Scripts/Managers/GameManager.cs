using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Scene current;

    private void Start()
    {
        current = SceneManager.GetActiveScene();
    }
    public void Reset()
    {
        SceneManager.LoadScene(current.name);
    }
}
