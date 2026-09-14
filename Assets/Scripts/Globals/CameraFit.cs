using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFit : MonoBehaviour
{
    [SerializeField] private float fieldHalfWidth = 8.75f;
    [SerializeField] private float minOrthographicSize = 5f;

    private Camera view;

    private void Awake()
    {
        view = GetComponent<Camera>();
    }

    private void Update()
    {
        view.orthographicSize = Mathf.Max(minOrthographicSize, fieldHalfWidth / view.aspect);
    }
}
