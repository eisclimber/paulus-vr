using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayItem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _numberText;

    [SerializeField]
    private TMP_Text _nameText;

    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private Image _background;


    public void DisplayScore(int number, string name, string score, Color backgroundColor)
    {
        _numberText.text = $"{number + 1}.";
        _nameText.text = name;
        _scoreText.text = score;
        _background.color = backgroundColor;
    }
}
