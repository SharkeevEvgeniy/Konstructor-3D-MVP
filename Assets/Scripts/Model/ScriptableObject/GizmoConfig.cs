using UnityEngine;

[CreateAssetMenu(fileName = "Config gizmo", menuName = "ScriptableObjects/Gizmo", order = 4)]
public class GizmoConfig : ScriptableObject
{
    public float AutoScaleFactor;
    public bool UseSnap;
    public float SnapScale;
}

