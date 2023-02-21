using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
