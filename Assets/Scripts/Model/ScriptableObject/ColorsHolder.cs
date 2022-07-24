using UnityEngine;

[CreateAssetMenu(fileName = "Colors", menuName = "ScriptableObjects/Colors", order = 1)]
public class ColorsHolder : ScriptableObject
{
    public Color StayButtonFormat;
    public Color PressedButtonFormat;
    public Color StayGizmo;
    public Color PressedGizmo;
}
