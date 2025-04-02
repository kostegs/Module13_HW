using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] GameObject _characterGameObject;
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _timerTMP;
    [SerializeField] private string _scoreRemainsText;
    [SerializeField] private TextMeshProUGUI _winTMP;
    [SerializeField] private TextMeshProUGUI _looseTMP;
    [SerializeField] private int _maxScoreToWin;
    [SerializeField] private float _timeToWin;

    private void Update()
    {
        int currentScore = _wallet.CountOfCoins;
        _scoreTMP.text = $"{_scoreRemainsText} {_maxScoreToWin - currentScore}";

        if (currentScore >= _maxScoreToWin)
            WinGame();

        _timeToWin -= Time.deltaTime;
        _timerTMP.text = $"Осталось: {_timeToWin.ToString("0.0")} секунд";

        if(_timeToWin <=0)
            LooseGame();
    }

    private void WinGame()
        => EndGame(_winTMP.gameObject);

    private void LooseGame()
        => EndGame(_looseTMP.gameObject);
    
    private void EndGame(GameObject resultMessageGameObject)
    {
        _characterGameObject.SetActive(false);
        resultMessageGameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}