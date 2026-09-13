using UnityEngine;
using TMPro;

public class UIInputColor : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;

    private TMP_Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void OnEnable()
    {
        Color current = settings.PlayerColor;

        int index = dropdown.options.FindIndex(
            option => option.color.Equals(current));

        if (index >= 0)
            dropdown.SetValueWithoutNotify(index);

        dropdown.RefreshShownValue();
        dropdown.onValueChanged.AddListener(ChangeColor);
    }

    private void OnDisable()
    {
        dropdown.onValueChanged.RemoveListener(ChangeColor);
    }

    private void ChangeColor(int index)
    {
        Color selected = dropdown.options[index].color;
        settings.SetPlayerColor(selected);
    }
}
