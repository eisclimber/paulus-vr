using ExPresSXR.Misc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;


namespace ExPresSXR.UI
{
    public class WorldSpaceKeyboard : MonoBehaviour
    {
        [SerializeField]
        private string _inputText = "";
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;

                if (_inputField != null)
                {
                    string prefix = _inputText.StartsWith(_textPrefix) ? "" : _textPrefix;
                    string suffix = _inputText.EndsWith(_textSuffix) ? "" : _textSuffix;
                    _inputField.text = prefix + _inputText + suffix;
                }
            }
        }

        [SerializeField]
        private string _textPrefix = "";

        [SerializeField]
        private string _textSuffix = "​";

        [SerializeField]
        private CapsMode _capsMode = CapsMode.Toggle;
        public CapsMode CapsMode
        {
            get => _capsMode;
            set
            {
                _capsMode = value;

                // Always start with tabs of if not always upper
                CapsActive = _capsMode == CapsMode.AlwaysUpper;

                if (_capsButton != null)
                {
                    // Update the model if forced always upper
                    if (_capsButton.gameObject.TryGetComponent(out ButtonToggler toggler))
                    {
                        toggler.pressed = CapsMode == CapsMode.AlwaysUpper;
                    }

                    // Can't interact if one mode is forced
                    _capsButton.interactable = CapsMode != CapsMode.AlwaysUpper && CapsMode != CapsMode.AlwaysLower;
                }
            }
        }

        [SerializeField]
        private bool _capsActive = false;
        public bool CapsActive
        {
            get => _capsActive;
            set
            {
                _capsActive = value;
            }
        }

        [SerializeField]
        private TMP_InputField _inputField;

        [SerializeField]
        private Button _capsButton;

        [Space]

        public UnityEvent<string> OnTextEntered;
        public UnityEvent<string> OnTextChanged;


        private void Awake()
        {
            if (_inputField != null)
            {
                _inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
            }

            if (_capsButton != null)
            {
                if (_capsButton != null && _capsButton.gameObject.TryGetComponent(out ButtonToggler toggler))
                {
                    toggler.OnToggleChanged.AddListener(ChangeCapsActive);
                }
            }
        }


        public void ConfirmText()
        {
            OnTextEntered.Invoke(InputText);
        }

        public void AppendToText(string stringToAppend)
        {
            // This will update the text displayed via the setter function
            string rawValue = CapsActive ? stringToAppend.ToUpper() : stringToAppend.ToLower();
            if (_textSuffix != "" && _inputText.EndsWith(_textSuffix)) // Remove suffix if present
            {
                _inputText = _inputText[..^_textSuffix.Length];
            }
            InputText += rawValue + _textSuffix;

            if (CapsActive && _capsMode == CapsMode.OneCharUpper)
            {
                CapsActive = !CapsActive;

                if (_capsButton != null && _capsButton.gameObject.TryGetComponent(out ButtonToggler toggler))
                {
                    toggler.pressed = CapsActive;
                }
            }

            OnTextChanged.Invoke(_inputText);
        }

        public void RemoveLastFromText()
        {
            if (_inputText.Length > 0)
            {
                int numToStrip = _inputText.EndsWith(_textSuffix) ? _textSuffix.Length + 1 : 1;
                string newText = _inputText[..^numToStrip];
                newText = newText != _textPrefix ? newText + _textSuffix : "";
                InputText = newText;

                OnTextChanged.Invoke(_inputText);
            }
        }

        public void ClearText()
        {
            InputText = "";
            OnTextChanged.Invoke(_inputText);
        }


        public void ChangeCapsActive(bool newCaps)
        {
            CapsActive = newCaps;
        }


        // Allow text input via keyboard
        private void OnInputFieldValueChanged(string newValue)
        {
            if (_inputText != newValue)
            {
                _inputText = newValue;
            }
        }

        // Allows in-editor changes
        private void OnValidate()
        {
            InputText = _inputText;
            CapsMode = _capsMode;
        }
    }


    public enum CapsMode
    {
        Toggle,
        OneCharUpper,
        AlwaysUpper,
        AlwaysLower
    }
}