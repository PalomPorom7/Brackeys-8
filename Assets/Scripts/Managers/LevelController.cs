using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LevelController : MonoBehaviour
{
    private Scene current;

    [SerializeField]
    private string nextLevel = "";

    [SerializeField]
    private ExitController[] exits;

    [SerializeField]
    private CircleMask[] circleMasks = new CircleMask[2];

    [SerializeField]
    private FadeInUIText text;

    private AudioSource audioSource;
    private bool didComplete = false;

    private void Awake()
    {
        current = SceneManager.GetActiveScene();
        audioSource = GetComponent<AudioSource>();
    }

    public void Reset()
    {
        SceneManager.LoadScene(current.name);
    }

    public void CheckExits()
    {
        if (exits[0].CheckComplete() && exits[1].CheckComplete())
        {
            if (didComplete)
                return;

            didComplete = true;

            if (nextLevel != "")
                StartCoroutine(GoToNext());
        }
    }

    private IEnumerator GoToNext()
    {
        if (text != null)
            text.Hide();

        audioSource.PlayOneShot(audioSource.clip);
        circleMasks[0].Hide();
        circleMasks[1].Hide();

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(nextLevel);
    }
}
