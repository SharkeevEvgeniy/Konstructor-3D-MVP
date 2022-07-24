using RuntimeHandle;

public class GizmoPresenter 
{
    private GizmoModel _gizmoModel;
    private GizmoView _gizmoView;

    private RuntimeTransformHandle _transformHandle;
    private HandleType _handleType;

    public GizmoPresenter(GizmoModel model, GizmoView view)
    {
        _gizmoModel = model;
        _gizmoView = view;
    }

    public GizmoModel GetGizmoModel() => _gizmoModel;

    public void SetState(int index)
    {
        _handleType = (HandleType)index;
        _transformHandle.type = _handleType;
        _gizmoView.ResetAll();
        _gizmoView.SetColor(index);
    }
         
    public RuntimeTransformHandle GetTransformHandle() => _transformHandle;

    public void SetTransformHandle(RuntimeTransformHandle transformHandle) => 
        _transformHandle = transformHandle;
}
