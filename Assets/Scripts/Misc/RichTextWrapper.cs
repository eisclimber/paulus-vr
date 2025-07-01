using TMPro;
using UnityEngine;

public class RichTextWrapper : MonoBehaviour
{
    [SerializeField]
    private string _richTextDisplayTemplate = "<mspace=1em>{0}</mspace>​";

    [SerializeField]
    private TMP_Text _text;


    public void UpdateText(string text)
    {
        if (_text != null)
        {
            _text.text = string.Format(_richTextDisplayTemplate, text);
        }
        else
        {
            Debug.LogError("No text provided to display the text.", this);
        }
    }
}
