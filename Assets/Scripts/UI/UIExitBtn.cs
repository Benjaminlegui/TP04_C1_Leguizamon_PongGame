using UnityEngine;
using UnityEngine.UI;

public class UIExitBtn : MonoBehaviour
{
    private Button button;
    void Awake()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
                gameObject.SetActive(false);
        #else
                button = GetComponent<Button>();

                if (button != null)
                {
                    button.onClick.AddListener(Exit);
                }
        #endif
    }

    void OnDestroy()
    {
        if (button != null)
            button.onClick.RemoveAllListeners();
    }
    
    private void Exit()
    {
        SceneController.Instance.Quit();
    }
}
