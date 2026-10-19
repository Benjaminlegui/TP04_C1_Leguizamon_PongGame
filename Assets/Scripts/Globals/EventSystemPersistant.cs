using UnityEngine;

// Suggestion: "Persistant" está mal escrito, en inglés es "Persistent".
// Renombrá la clase y el archivo juntos desde el Project de Unity para no romper la referencia del prefab.
public class EventSystemPersistant : MonoBehaviour
{
    private static EventSystemPersistant _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}
