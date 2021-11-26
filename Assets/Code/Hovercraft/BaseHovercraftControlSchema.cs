using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHovercraftControlSchema : ScriptableObject
{
    public abstract void Control(Hovercraft hovercraft, Vector3 input);
    
    protected virtual void UpdateEmitters(IEnumerable<PropulsionEmbitter> embitters, float input, Vector3 direction)
    {
        foreach (var embitter in embitters)
        {
            embitter.Output = input;
            embitter.Direction = direction;
        }
    }

    protected virtual void UpdateAntiGravityEmitters(IEnumerable<AntiGravityEmitter> antAntiGravityEmitters,
        Vector3 direction, float levitationDistance)
    {
        var emitterLength = levitationDistance + 0.5f;
        foreach (var emitter in antAntiGravityEmitters)
        {
            emitter.Length = emitterLength;
            emitter.Direction = direction;
        }
    }
}