using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        var screenPoint = _camera.WorldToScreenPoint(transform.position);
        screenPoint.x = Input.mousePosition.x;
        transform.position = _camera.ScreenToWorldPoint(screenPoint);
    }
}
