using System;
using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    [Serializable]
    public class OnInputChange : UnityEvent<Vector3>
    {
    }
    
    [Serializable]
    public class OnButtonDown : UnityEvent
    {
    }
    
    [Serializable]
    public class OnButtonUp : UnityEvent
    {
    }    
    [SerializeField] private KeyCode m_forward = KeyCode.W;
    [SerializeField] private KeyCode m_backward = KeyCode.S;
    [SerializeField] private KeyCode m_left = KeyCode.A;
    [SerializeField] private KeyCode m_right = KeyCode.D;
    [SerializeField] private KeyCode m_sideMode = KeyCode.LeftShift;

    public OnInputChange OnInputChangeCallback = new OnInputChange();
    public OnButtonDown OnSideModeOnCallback = new OnButtonDown();
    public OnButtonUp OnSideModeOffCallback = new OnButtonUp();
    
    [SerializeField] private Vector3 m_input = Vector3.zero;
    private void Update()
    {
        float forward = 0, side = 0;
        forward += Input.GetKey(m_forward) ? 1 : 0;
        forward += Input.GetKey(m_backward) ? -1 : 0;
        
        side += Input.GetKey(m_left) ? -1 : 0;
        side += Input.GetKey(m_right) ? 1 : 0;

        m_input.x = side;
        m_input.z = forward;
        
        OnInputChangeCallback.Invoke(m_input);
        if(Input.GetKeyDown(m_sideMode))
            OnSideModeOnCallback.Invoke();
        if(Input.GetKeyUp(m_sideMode))
            OnSideModeOffCallback.Invoke();
    }
}
