using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string NextLevel = "";
    public ExitController[] exits;
    public CircleMask[] circleMasks;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                StartCoroutine(GoToNext());
            }
        }
    }

    IEnumerator GoToNext()
    {
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(NextLevel);
    }
}
