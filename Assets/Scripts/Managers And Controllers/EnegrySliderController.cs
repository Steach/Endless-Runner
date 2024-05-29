using System;
using UnityEngine;
using UnityEngine.UI;

public class EnegrySliderController : MonoBehaviour
{
    public Action EnergyIsNull;

    [System.Serializable]
    public struct SliderControllerData
    {
        public Slider _energySlider;
        public Color _startColor;
        public Color _endColor;
        public float _lossEnegryPerSec;
        public Image _sliderImage;
        public float _maxEnergyValue;
    }

    [Space]
    [SerializeField] private SliderControllerData _sliderEnergyData;
    [Space]
    [Header("Executor")]
    [SerializeField] private ExecutorBase _executor;
    private bool _gameOver;
    
    
    private void Awake()
    {
        _gameOver = false;
        _sliderEnergyData._energySlider.maxValue = _sliderEnergyData._maxEnergyValue;
        _sliderEnergyData._energySlider.value = _sliderEnergyData._maxEnergyValue;
    }

    private void Update()
    {
        if (!_gameOver)
        {
            _executor.Execute(_sliderEnergyData);
            if (_sliderEnergyData._energySlider.value <= 0)
            {
                _gameOver = true;
                EnergyIsNull?.Invoke();
            }   
        }
    }
}

