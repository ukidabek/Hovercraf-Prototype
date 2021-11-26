using UnityEngine;

[CreateAssetMenu(menuName = "Hovercraft/Control/Schema/SideHovercraftControlSchema", fileName = "SideHovercraftControlSchema", order = 0)]
public class SideHovercraftControlSchema : BaseHovercraftControlSchema
{
    public override void Control(Hovercraft hovercraft, Vector3 input)
    {
        var transform = hovercraft.transform;
        UpdateEmitters(hovercraft.LeftSidePropulsionEmitter, Mathf.Clamp(input.x,0, 1), transform.right);
        UpdateEmitters(hovercraft.RightSidePropulsionEmitter, Mathf.Clamp(input.x,-1, 0), transform.right);
        UpdateEmitters(hovercraft.PropulsionEmitter, input.z, transform.forward);
        UpdateAntiGravityEmitters(hovercraft.AntAntiGravityEmitters, transform.up, hovercraft.LevitationDistance);
  
    }
}