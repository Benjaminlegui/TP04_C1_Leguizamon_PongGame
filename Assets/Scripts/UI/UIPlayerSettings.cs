using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerSettings : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private GameObject playerSpeed;
    [SerializeField] private GameObject playerSize;
    [SerializeField] private TMP_Dropdown dropdown;
    
    private Slider  playerSpeedSlider;
    private Slider playerSizeSlider;
    private Color playerColor => playerSettings.PlayerColor;

    private const string SliderFormat = "F1";
    
    void Awake() 
    {
        if (playerSpeed != null)
        {
            playerSpeedSlider = playerSpeed.GetComponentInChildren<Slider>();
            playerSpeedSlider.SetValueWithoutNotify(playerSettings.PlayerSpeed);
            playerSpeedSlider.onValueChanged.AddListener(OnSpeedChange);
            
            playerSpeed.GetComponentInChildren<TMP_Text>().text = playerSettings.PlayerSpeed.ToString(SliderFormat);
        }

        if (playerSize != null)
        {
            playerSizeSlider = playerSize.GetComponentInChildren<Slider>();
            playerSizeSlider.SetValueWithoutNotify(playerSettings.PlayerSize);
            playerSizeSlider.onValueChanged.AddListener(OnSizeChange);
            
            playerSize.GetComponentInChildren<TMP_Text>().text = playerSettings.PlayerSize.ToString(SliderFormat);
        }
    }

    private void OnSizeChange(float value)
    {
        playerSettings.SetPlayerSize(value);
        playerSize.GetComponentInChildren<TMP_Text>().text = playerSettings.PlayerSize.ToString(SliderFormat);
    }

    private void OnSpeedChange(float value)
    {
        playerSettings.SetPlayerSpeed(value);
        playerSpeed.GetComponentInChildren<TMP_Text>().text = playerSettings.PlayerSpeed.ToString(SliderFormat);
    }
}
