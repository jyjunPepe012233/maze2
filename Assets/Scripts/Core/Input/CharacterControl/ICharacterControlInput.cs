using System;
using UnityEngine;

namespace Core.Input.CharacterControl
{

    public interface ICharacterControlInput
    {
        event Action OnRotated;
    
        event Action OnMoved;

        event Action OnInteracted;
    
        Vector2 RotationDirection { get; }

        Vector2 MoveDirection { get; }
    
        bool IsSprinting { get; }
    }

}
