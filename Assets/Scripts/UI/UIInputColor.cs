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

        // Warning: Color.Equals compara los cuatro floats por igualdad exacta. Además, después del primer golpe de pelota el SO
        // tiene un color random que no está en la lista, así que el dropdown queda mostrando el último valor elegido.
        // Guardá el índice elegido en lugar de buscarlo por color, o compará con tolerancia.
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
