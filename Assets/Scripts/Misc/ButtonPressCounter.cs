using System;
using System.Linq;
using ExPresSXR.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPressCounter : MonoBehaviour
{
    [SerializeField]
    private BaseButton[] _buttons;

    private bool[] _pressed;


    public UnityEvent<int> OnNewButtonPressed;
    public UnityEvent[] OnButtonsPressed;
    public UnityEvent OnAllPressed;
    public UnityEvent OnReset;

    private void Awake()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            // Can't remove delegate, so we'll use awake
            _buttons[i].OnPressed.AddListener(() => ChangePressedState(i, true));
        }
        Array.Resize(ref _pressed, _buttons.Length);
        Array.Resize(ref OnButtonsPressed, _buttons.Length);
    }

    private void ChangePressedState(int idx, bool pressed)
    {
        if (idx < 0 || idx >= _buttons.Length)
        {
            Debug.LogWarning("Invalid idx to set pressed state.", this);
            return;
        }

        bool newlyPressed = pressed && !_pressed[idx];
        _pressed[idx] = pressed;

        if (newlyPressed)
        {
            OnNewButtonPressed.Invoke(idx);
            OnButtonsPressed[idx].Invoke();

            if (_pressed.All(x => x))
            {
                OnAllPressed.Invoke();
            }
        }
    }

    [ContextMenu("Reset Pressed")]
    private void ResetPressed()
    {
        _pressed = new bool[_pressed.Length];
        OnReset.Invoke();
    }

    [ContextMenu("Emit All Pressed Event")]
    private void EmitAllPressedEvent() => OnAllPressed.Invoke();

    [ContextMenu("Press First")]
    private void PressFirst() => ChangePressedState(0, true);


    [ContextMenu("Press Second")]
    private void PressSecond() => ChangePressedState(1, true);


    [ContextMenu("Press Third")]
    private void PressThird() => ChangePressedState(2, true);
}
