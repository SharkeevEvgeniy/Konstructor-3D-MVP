using UnityEngine;
using UnityEngine.UI;
using RuntimeHandle;

public class GizmoView : MonoBehaviour
{
    private GizmoPresenter _gizmoPresenter;

    [SerializeField] private Image[] _gizmoImages;
    [SerializeField] private Image _gizmoSwapImage;

    [SerializeField] private ColorsHolder _colorsHolder;

    private bool _useSnap;

    public void Initialization(Transform target)
    {
        var transformHandle = RuntimeTransformHandle.Create(target, HandleType.POSITION);
        transformHandle.autoScaleFactor = _gizmoPresenter.GetGizmoModel().AutoScaleFactor;
        _gizmoPresenter.SetTransformHandle(transformHandle);
    }

    public void SetPresenter(GizmoPresenter gizmo) => _gizmoPresenter = gizmo;

    public void SetStateOnClick(int index) => _gizmoPresenter.SetState(index);

    public void SetColor(int index)
    {
        _gizmoImages[index].color = _colorsHolder.PressedGizmo;
    }

    public void ResetColor(int index)
    {
        _gizmoImages[index].color = _colorsHolder.StayGizmo;
    }

    public void ResetAll()
    {
        foreach (var image in _gizmoImages)
        {
            image.color = _colorsHolder.StayGizmo;
        }
    }

    public void ChangeSwapColor(bool value)
    {
        _gizmoSwapImage.color = value ? _colorsHolder.PressedGizmo : _colorsHolder.StayGizmo;
    }

    public void SwitchSwap()
    {
        _useSnap = !_useSnap;

        if(_useSnap)
        {
            float snapScale = _gizmoPresenter.GetGizmoModel().SnapScale;
            _gizmoPresenter.GetTransformHandle().positionSnap = new Vector3(snapScale, snapScale, snapScale);
        }else
        {
            _gizmoPresenter.GetTransformHandle().positionSnap = Vector3.zero;
        }

        ChangeSwapColor(_useSnap);
    }
}
