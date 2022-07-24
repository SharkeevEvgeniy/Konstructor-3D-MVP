using UnityEngine;

[CreateAssetMenu(fileName = "Config camera", menuName = "ScriptableObjects/Camera", order = 2)]
public class CameraViewConfig : ScriptableObject
{
    public float PowerDragX;
    public float PowerDragY;
    public float PowerScalling;
    public float MinScale;
    public float MaxScale;
}
