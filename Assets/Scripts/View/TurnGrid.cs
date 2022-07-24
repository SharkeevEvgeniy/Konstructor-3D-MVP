using UnityEngine;

public class TurnGrid : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private GridViewConfig _config;

    private float _powerRotateX;
    private float _powerRotateY;

    private Vector3 _deltaPos;
    private Vector3 _lastPos;

    private void Start()
    {
        _powerRotateX = _config.PowerRotateX;
        _powerRotateY = _config.PowerRotateY;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _lastPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            _deltaPos = Input.mousePosition - _lastPos;
            _target.RotateAround(_target.position, new Vector3(1, 0, 1), _deltaPos.y / _powerRotateY);
            _target.localRotation *= Quaternion.Euler(0f, -_deltaPos.x / _powerRotateX, 0f);
            _lastPos = Input.mousePosition;
        }
    }
}
