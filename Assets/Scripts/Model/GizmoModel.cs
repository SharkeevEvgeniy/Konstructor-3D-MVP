using RuntimeHandle;

public class GizmoModel
{
    private HandleType _handleType;
    private float _autoScaleFactor;
    private bool _useSnap;
    private float _snapScale;

    public HandleType HandleType
    {
        get
        {
            return _handleType;
        }
        set
        {
            _handleType = value;
        }
    }

    public float AutoScaleFactor
    {
        get
        {
            return _autoScaleFactor;
        }
        set
        {
            _autoScaleFactor = value;
        }
    }

    public bool UseSnap
    {
        get
        {
            return _useSnap;
        }
        set
        {
            _useSnap = value;
        }
    }

    public float SnapScale
    {
        get
        {
            return _snapScale;
        }
        set
        {
            _snapScale = value;
            if (_snapScale > 1f)
                _snapScale = 1f;
        }
    }
}
