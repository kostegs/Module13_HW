using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _timerTMP;
    [SerializeField] private string _scoreRemainsText;
    [SerializeField] private TextMeshProUGUI _winTMP;
    [SerializeField] private TextMeshProUGUI _looseTMP;
    [SerializeField] private int _maxScoreToWin;
    [SerializeField] private float _timeToWin;

    private void Update()
    {
        int currentScore = _player.Score;
        _scoreTMP.text = $"{_scoreRemainsText} {_maxScoreToWin - currentScore}";

        if (currentScore >= _maxScoreToWin)
            WinGame();

        _timeToWin -= Time.deltaTime;
        _timerTMP.text = $"Осталось: {_timeToWin.ToString("0.0")} секунд";

        if(_timeToWin <=0)
            LooseGame();
    }

    private void WinGame()
        => EndGame(_winTMP);

    private void LooseGame()
        => EndGame(_looseTMP);
    
    private void EndGame(TextMeshProUGUI tmp)
    {
        _player.gameObject.SetActive(false);
        tmp.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
