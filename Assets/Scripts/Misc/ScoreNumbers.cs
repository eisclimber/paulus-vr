using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreNumbers : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Animator _animator;

    [Space]

    [SerializeField]
    private bool showSigns;

    [SerializeField]
    private bool _randomColor = true;

    [SerializeField]
    private float _randomColorSaturation = 0.9f;

    [SerializeField]
    private float _randomColorValue = 0.9f;


    public int Score
    {
        set
        {
            if (_text != null)
            {
                _text.text = showSigns ? value.ToString("+#;-#;0") : value.ToString();
            }
            else
            {
                Debug.LogError($"Could not display score '{value}', no Text to display set.");
            }
        }
    }

    private void OnEnable()
    {
        if (_randomColor)
        {
            _text.color = GetRandomHueColor();
        }
    }

    public void ShowRandomHueScore(int score)
    {
        _text.color = GetRandomHueColor();
        ShowScore(score);
    }


    public void ShowScore(int score, Color fontColor)
    {
        ShowScore(score);
        _text.color = fontColor;
    }


    public void ShowScore(int score, Color fontColor, Color outlineColor)
    {
        ShowScore(score);
        _text.color = fontColor;
        _text.outlineColor = outlineColor;
    }

    public void ShowScore(int score)
    {
        _text.text = score.ToString();
    }

    public void DestroySelf() => Destroy(gameObject);

    public Color GetRandomHueColor() => Color.HSVToRGB(Random.Range(0.0f, 1.0f), _randomColorSaturation, _randomColorValue);
}
