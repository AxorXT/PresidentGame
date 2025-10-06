using UnityEngine;

public class PersistentPlayer : MonoBehaviour
{
    private static PersistentPlayer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya
        }
        else
        {
            Destroy(gameObject); // Evita duplicados si vuelves al lobby
        }
    }
}
