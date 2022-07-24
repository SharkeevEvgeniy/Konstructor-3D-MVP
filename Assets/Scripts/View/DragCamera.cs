using UnityEngine;

public class DragCamera : MonoBehaviour
{
    [SerializeField] CameraViewConfig _config;

    private Vector3 _deltaPos;
    private Vector3 _lastPos;

    private float _powerDragX;
    private float _powerDragY;

    private void Start()
    {
        _powerDragX = _config.PowerDragX;
        _powerDragY = _config.PowerDragY;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            _lastPos = Input.mousePosition;
        }
       
        if (Input.GetMouseButton(2))
        {
            _deltaPos = Input.mousePosition - _lastPos;
            Camera.main.transform.localPosition += new Vector3(-_deltaPos.x / _powerDragX, -_deltaPos.y / _powerDragY, -_deltaPos.x / _powerDragX);
            _lastPos = Input.mousePosition;
        }
    }
}
