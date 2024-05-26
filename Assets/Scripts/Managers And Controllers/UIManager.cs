using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Tags { Player, Obstacle, CollectableItem, Hole }

    [SerializeField] private ExecutorOnPhysics _triggerEvent;
    [SerializeField] private ExecutorOnPhysics _colliderEvent;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _pickedEnergy;
    [SerializeField] private float _lossEnergy;
    [SerializeField] private Tags[] _tag;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private EnegrySliderController _endEnergyEvent;
    [SerializeField] private Controller _controller;

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
        _endEnergyEvent.EnergyIsNull += GameOver; 
        _triggerEvent.TriggerEvent += CheckScore;
        _colliderEvent.TriggerEvent += CheckScore;
        _controller.FallDownEvent += FallEvent;
    }

    private void CheckScore(string gameObjectTag)
    {
        if (gameObjectTag == _tag[0].ToString())
        {
            _slider.value += _pickedEnergy;
        }

        if (gameObjectTag == _tag[1].ToString())
        {
            _slider.value -= _lossEnergy;
        }

        if (gameObjectTag == _tag[2].ToString())
        {
            _slider.value = 0;
        }
    }

    private void FallEvent() => _slider.value = 0;

    private void GameOver()
    { 
        _gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
