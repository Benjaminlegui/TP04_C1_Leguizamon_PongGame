using UnityEngine;

public class FieldSideSwitch : MonoBehaviour
{
    [SerializeField] private float side = 0f;
    public float Side => side;
    
    public void ChangeSide()
    {
        side *= -1f;
    }

    public void SetInitialSide(float value)
    {
        side = value;
    }
}
