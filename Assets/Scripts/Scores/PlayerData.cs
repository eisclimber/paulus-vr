using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static string _currentPlayer = "HEROBRINE";
    public static string CurrentPlayer
    {
        get => _currentPlayer;
        set
        {
            _currentPlayer = value;
            CurrentTotalScore = 0; // Reset Score
        }
    }
    private static int _currentTotalScore = 0; // TODO one score per game?
    public static int CurrentTotalScore
    {
        get => _currentTotalScore;
        set => _currentTotalScore = value;
    }

    public static void AddScore(int score)
    {
        if (_currentPlayer.Length <= 0)
        {
            Debug.Log("Altering score of an unknown player. Did you forget to set it?");
        }
        _currentTotalScore += score;
    }

    public static void ResetScore() => CurrentTotalScore = 0;

    public void ChangeCurrentPlayer(string newPlayer)
    {
        CurrentPlayer = newPlayer;
        CurrentTotalScore = 0;
    }
}