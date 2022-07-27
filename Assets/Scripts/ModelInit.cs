using UnityEngine;

public class ModelInit : MonoBehaviour
{
    private GameObject _object;

    [SerializeField] private Transform _grid;

    [SerializeField] private GizmoView _gizmoView;

    [SerializeField] private GizmoConfig _config;

    public void SetModel(GameObject model) => _object = model;
   
    public void Initialize()
    {
        GizmoModel gizmoModel = new GizmoModel();
        gizmoModel.AutoScaleFactor = _config.AutoScaleFactor;
        gizmoModel.HandleType = RuntimeHandle.HandleType.POSITION;
        gizmoModel.UseSnap = _config.UseSnap;
        gizmoModel.SnapScale = _config.SnapScale;

        GizmoPresenter gizmoPresenter = new GizmoPresenter(gizmoModel, _gizmoView);

        _gizmoView.SetPresenter(gizmoPresenter);
        _gizmoView.Initialize(_object.transform);

        _object.AddComponent<MeshCollider>();
        _object.transform.SetParent(_grid);
        _object.transform.localPosition = Vector3.zero;
        _object.transform.localRotation = Quaternion.identity;
    }
}
