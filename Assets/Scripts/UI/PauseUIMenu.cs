using UnityEngine;
using UnityEngine.UI;

public class PauseUIMenu : UIMenu
{
    [SerializeField] private Button continueButton;
    [SerializeField] private GameManager gameManager;
    
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenu;
    
    protected override void Awake()
    {
        base.Awake();
        continueButton.onClick.AddListener(Resume);
    }

    void OnEnable()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.TogglePause();
            RefreshMenu();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        continueButton.onClick.RemoveListener(Resume);
    }

    public void Resume()
    {
        if (gameManager.IsPaused)
            gameManager.TogglePause();
        
        RefreshMenu();
    }

    private void RefreshMenu()
    {
        pauseMenu.SetActive(gameManager.IsPaused);

        if (gameManager.IsPaused)
            ShowMain();
    }
}
