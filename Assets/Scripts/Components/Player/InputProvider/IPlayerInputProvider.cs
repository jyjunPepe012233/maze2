using System;
using UnityEngine;

public interface IPlayerInputProvider
{
    event Action onRotated;
    
    event Action onMoved;
    
    Vector2 RotationDirection { get; }

    Vector2 MoveDirection { get; }
    
    bool IsSprinting { get; }
}
