using UnityEngine;

[CreateAssetMenu(menuName = "Hovercraft/Control/Schema/NormalHovercraftControlSchema", fileName = "NormalHovercraftControlSchema", order = 0)]
public class NormalHovercraftControlSchema : BaseHovercraftControlSchema
{
    public override void Control(Hovercraft hovercraft, Vector3 input)
    {
        var transform = hovercraft.transform;
        UpdateEmitters(hovercraft.LeftPropulsionEmitter, Mathf.Clamp(input.x,0, 1), transform.right);
        UpdateEmitters(hovercraft.RightPropulsionEmitter, Mathf.Clamp(input.x,-1, 0), transform.right);
        UpdateEmitters(hovercraft.PropulsionEmitter, input.z, transform.forward);
        UpdateAntiGravityEmitters(hovercraft.AntAntiGravityEmitters, transform.up, hovercraft.LevitationDistance);
    }
}