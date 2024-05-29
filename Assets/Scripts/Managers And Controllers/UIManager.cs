using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum Tags { Player, Obstacle, CollectableItem, Hole }

    [Header("Events")]
    [SerializeField] private ExecutorOnPhysics _triggerEvent;
    [SerializeField] private ExecutorOnPhysics _colliderEvent;
    [SerializeField] private EnegrySliderController _endEnergyEvent;
    [SerializeField] private Controller _controller;

    [Header("Slider Configuration")]
    [SerializeField] private Slider _slider;
    [SerializeField] private float _pickedEnergy;
    [SerializeField] private float _lossEnergy;
    [SerializeField] private GameObject _gameOverPanel;
    
    

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
        if (gameObjectTag == (Tags.CollectableItem).ToString())
        {
            _slider.value += _pickedEnergy;
        }

        if (gameObjectTag == (Tags.Obstacle).ToString())
        {
            _slider.value -= _lossEnergy;
        }

        if (gameObjectTag == (Tags.Hole).ToString())
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
