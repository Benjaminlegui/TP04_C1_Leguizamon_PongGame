using UnityEngine;
using UnityEngine.UI;

public class UIBackToMain : MonoBehaviour
{
    private Button button;
    
    void Awake()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(BackToMain);
        }
    }

    void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
    
    private void BackToMain()
    {
        SceneController.Instance.GoToMainMenu();
    }
}
