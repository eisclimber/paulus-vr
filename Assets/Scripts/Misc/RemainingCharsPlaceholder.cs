using TMPro;
using UnityEngine;

public class RemainingCharsPlaceholder : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private string _freeCharacter = "_";

    [SerializeField]
    private string _occupiedCharacter = " ";


    private int MaxLength
    {
        get => _inputField != null ? _inputField.characterLimit : -1;
    }

    private void OnEnable()
    {
        if (_inputField == null)
        {
            Debug.LogWarning("No input field provided. Can't generate placeholder string.", this);
        }

        if (_text == null)
        {
            Debug.LogWarning("No text provided. Can't display placeholder string.", this);
        }
    }


    public void UpdatePlaceholder(string text)
    {
        if (text.Length >= MaxLength)
        {
            Debug.LogWarning($"Text provided is too long! Max Length is {MaxLength}.");
        }

        string placeholder = "";
        for (int i = 0; i < MaxLength; i++)
        {
            placeholder += i < text.Length ? _occupiedCharacter : _freeCharacter;
        }

        _text.text = placeholder;
    }
}
