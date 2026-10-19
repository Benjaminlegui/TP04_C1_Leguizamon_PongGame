using UnityEngine;
using UnityEngine.UI;

// Suggestion: UIPlayBtn, UIBackToMain y UIExitBtn son el mismo script con una sola línea distinta (la llamada a SceneController).
// Con una clase base que haga el GetComponent, el AddListener y el OnDestroy, cada botón solo define su acción.
public class UIPlayBtn : MonoBehaviour
{
    private Button button;
    
    void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(Play);
        }
    }

    void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
    
    private void Play()
    {
        SceneController.Instance.Play();
    }
}
