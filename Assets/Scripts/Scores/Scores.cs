using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[Serializable]
public class Scores
{
    private List<Score> _entries = new();
    public List<Score> Entries
    {
        get => _entries;
        private set => _entries = value;
    }

    public Scores(string scores, bool sort = true)
    {
        string[] lines = scores.Split(Environment.NewLine.ToCharArray());
        Entries = new();
        foreach (string line in lines)
        {
            Entries.Add(new(line));
        }

        if (sort)
        {
            SortScores();
        }
    }

    public void SortScores() => _entries.Sort();

    public int AddScore(string scoreRepresentation) => AddScore(new Score(scoreRepresentation));
    public int AddScore(Score score)
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            // Insert before element that this one precedes
            if (score.CompareTo(_entries[i]) < 0)
            {
                _entries.Insert(i, score);
                return i;
            }
        }

        // To bad, last place!
        _entries.Add(score);
        return _entries.Count;
    }

    public string GetSaveRepresenation() => string.Join("\n", _entries.Select(e => e.GetSaveRepresenation()));
}


[Serializable]
public class Score : IComparable<Score>
{
    public readonly string PlayerName = "HEROBRINE";
    public readonly int PlayerScore;

    public Score(string stringRepresentation)
    {
        string[] parts = stringRepresentation.Split(" ");
        if (parts.Length == 2)
        {
            Debug.LogWarning($"Found malformed score representation: '{stringRepresentation}'. Using placeholder name.");
        }

        PlayerName = parts[0];

        try
        {
            int score = int.Parse(parts[1]);
            PlayerScore = score;
        }
        catch (FormatException)
        {
            Debug.LogWarning($"Failed to parse score. Assuming zero.");
        }
    }

    public Score(string name, int score)
    {
        PlayerName = name;
        PlayerScore = score;
    }

    public int CompareTo(Score other) => other.PlayerScore - PlayerScore; // Negative values mean this object comes "before" the other

    public string GetSaveRepresenation() => $"{PlayerName} ${PlayerScore}";
}