using TMPro;
using UnityEngine;

public class TutorialTexts : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string[] _texts;
    
    [Space]

    [SerializeField]
    private TMP_Text _text;

    private void OnEnable()
    {
        if (_text == null && !TryGetComponent(out _text))
        {
            Debug.LogError("Did not find a text component to display tutorial text.", this);
        }
    }

    public void TriggerTexts(int step)
    {
        if (step >= 0 && step < _texts.Length && _texts[step] != "")
        {
            _text.text = _texts[step];
        }
    }
}