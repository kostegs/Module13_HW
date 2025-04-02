using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private string _currentScoreText;
    [SerializeField] private TextMeshProUGUI _winTMP;
    [SerializeField] private int _maxCoinToWin;

    private void Update()
    {
        int currentScore = _player.Score;
        _scoreTMP.text = $"{_currentScoreText} {currentScore}";

        if (currentScore >= _maxCoinToWin)
            WinGame();
    }

    private void WinGame()
    {
        _player.gameObject.SetActive(false);
        _winTMP.gameObject.SetActive(true);
    }
}
