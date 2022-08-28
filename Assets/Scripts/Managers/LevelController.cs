using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string NextLevel = "";
    public ExitController[] exits;
    private CircleMask[] circleMasks = new CircleMask[2];
    private FadeInUIText text;

    AudioSource audioSource;
    bool didComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        circleMasks[0] = GameObject.Find("Orange").transform.Find("Eyes").transform.GetChild(0).GetComponent<CircleMask>();
        circleMasks[1] = GameObject.Find("Blue").transform.Find("Eyes").transform.GetChild(0).GetComponent<CircleMask>();
        if (GameObject.Find("Text") != null) text = GameObject.Find("Text").GetComponent<FadeInUIText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckExits()
    {
        if (exits[0].CheckComplete() && exits[1].CheckComplete())
        {
            if (didComplete) return;
            didComplete = true;
            Debug.Log("Level Complete");
            if (NextLevel != "")
            {
                StartCoroutine(GoToNext());
            }
        }
    }

    IEnumerator GoToNext()
    {
        if (text != null) text.Hide();
        audioSource.PlayOneShot(audioSource.clip);
        circleMasks[0].Hide();
        circleMasks[1].Hide();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(NextLevel);
    }
}
