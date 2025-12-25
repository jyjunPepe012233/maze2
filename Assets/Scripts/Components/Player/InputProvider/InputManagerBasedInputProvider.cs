using System;
using UnityEngine;

public class InputManagerBasedInputProvider : MonoBehaviour, IPlayerInputProvider
{
    public event Action onRotated;
    
    public event Action onMoved;
    
    public Vector2 RotationDirection { get; private set; }
    
    public Vector2 MoveDirection { get; private set; }
    
    public bool IsSprinting { get; private set; }

    private void UpdateRotationInput()
    {
        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");
        RotationDirection = new Vector2(x, y);
        if (RotationDirection.magnitude != 0)
        {
            onRotated?.Invoke();
        }
    }

    private void UpdateMoveInput()
    { 
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector2(horiz, vert).normalized;
        if (MoveDirection.magnitude != 0)
        {
            onMoved?.Invoke();
        }
    }

    private void UpdateSprintInput()
    {
        IsSprinting = Input.GetKey(KeyCode.LeftShift) && MoveDirection.magnitude != 0;
    }
    
    private void Update()
    {
        UpdateRotationInput();
        UpdateMoveInput();
        UpdateSprintInput();
    }
}
