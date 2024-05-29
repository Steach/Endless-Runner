using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ChangeSliderValueAction _changeEnegryEvent;
    [SerializeField] private EnegrySliderController _nullEnergeEvent;
    [SerializeField] private TextMeshProUGUI _score;

    private bool gameOver = false;
    private float _scoreValue;

    private void Awake()
    {
        _scoreValue = 0f;
        _changeEnegryEvent._lossEnergyValue += ChangeScore;
        _nullEnergeEvent.EnergyIsNull += GameOver;
    }

    private void ChangeScore(float _lossEnergy)
    {
        if (!gameOver)
        {
            _scoreValue += _lossEnergy;
            _score.text = Mathf.RoundToInt(_scoreValue).ToString();
        }
    }

    private void GameOver() => gameOver = true;
}
