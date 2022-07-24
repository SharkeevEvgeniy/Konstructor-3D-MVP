using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private CameraViewConfig _config;

    private float _powerScalling;
    private float _minScale;
    private float _maxScale;

    private float _fieldOfView;

    private void Awake()
    {
        _fieldOfView = _camera.fieldOfView;

        _powerScalling = _config.PowerScalling;
        _minScale = _config.MinScale;
        _maxScale = _config.MaxScale;
    }

    private void Update()
    {
        float deltaScrollWheel = Input.GetAxis("Mouse ScrollWheel");

        _fieldOfView -= deltaScrollWheel * _powerScalling;
        _fieldOfView = Mathf.Clamp(_fieldOfView, _minScale, _maxScale);

        _camera.fieldOfView = _fieldOfView;
    }
}
