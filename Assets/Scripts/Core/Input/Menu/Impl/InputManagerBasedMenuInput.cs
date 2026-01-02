using System;
using UnityEngine;

namespace Core.Input.Menu.Impl
{

    public class InputManagerBasedMenuInput : InputProfileBehaviour, IMenuInput
    {
        public event Action OnEscaped;

        private void UpdateEscapeInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                OnEscaped?.Invoke();
            }
        }

        private void Update()
        {
            UpdateEscapeInput();
        }
    }

}
