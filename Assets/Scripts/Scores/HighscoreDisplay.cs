using System;
using System.IO;
using UnityEngine;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _listItemPrefab;

    [SerializeField]
    private Color _aColor;

    [SerializeField]
    private Color _bColor;

    [SerializeField]
    private string _highscoreFileName;

    [SerializeField]
    private bool _useTestScores;


    private string _debugScores = "Foo 123\nBar 245\nFizz 2\nBuzz 1123\nPi 12\nPa 2\nPo 1";

    public string HighscoreSavePath
    {
        get
        {
#if UNITY_EDITOR
            return Path.Combine(Application.dataPath, _highscoreFileName);
#else
            return Path.Combine(Application.persistentDataPath, _highscoreFileName);
#endif
        }
    }


    public Scores LoadSavedScores()
    {
        // Nothing saved -> Return empty save
        if (!File.Exists(HighscoreSavePath))
        {
            return new("");
        }

        try
        {
            string scoresString = File.ReadAllText(HighscoreSavePath);
            return new(scoresString);
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception: {e.Message}");
            return new("");
        }
    }

    public int AddScore(string name, int score, Scores scores) => scores.AddScore(new Score(name, score));

    public void SaveScores(Scores scores)
    {
        try
        {
            File.WriteAllText(HighscoreSavePath, scores.GetSaveRepresenation());
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception: {e.Message}");
        }
    }


    [ContextMenu("Reset Scores")]
    public void ResetScores()
    {
        try
        {
            File.WriteAllText(HighscoreSavePath, "");
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception: {e.Message}");
        }
    }




    private void OnEnable()
    {
        if (_useTestScores)
        {
            DisplayTestScores();
        }
        else
        {
            DisplayScores();
        }
    }

    [ContextMenu("Load Test Scores")]
    public void DisplayScores()
    {
        string[] scores = _debugScores.Split(Environment.NewLine.ToCharArray());
        DisplayScores(scores);
    }

    [ContextMenu("Load Saved Scores")]
    public void DisplayTestScores()
    {
        string[] scores = _debugScores.Split(Environment.NewLine.ToCharArray());
        DisplayScores(scores);
    }


    public void DisplayScores(string[] scores)
    {
        // Delete all children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Add children
        float contentHeight = 0.0f;
        for (int i = 0; i < scores.Length; i++)
        {
            string[] parts = scores[i].Split(" ");
            if (parts.Length != 2)
            {
                Debug.LogWarning($"Found malformed highscore item: '{scores[i]}'. Skipping...", this);
                continue;
            }

            GameObject go = Instantiate(_listItemPrefab, transform);
            if (go.TryGetComponent(out ScoreDisplayItem item))
            {
                item.DisplayScore(i, parts[0], parts[1], i % 2 == 0 ? _aColor : _bColor);

                if (TryGetComponent(out RectTransform childRectTransform))
                {
                    contentHeight += childRectTransform.rect.height * item.transform.lossyScale.y;
                }
            }
            else
            {
                Debug.LogWarning("Did not find a HighscoreDisplayItem in instantiated prefab. Could not setup highscore item.", this);
            }
        }

        // Update content height
        if (TryGetComponent(out RectTransform rectTransform))
        {
            rectTransform.sizeDelta = new(rectTransform.sizeDelta.x, contentHeight);
        }
    }
}
