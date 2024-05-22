using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ExecutorOnPhysics _triggerEvent;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _pickedEnergy;

    private void Awake()
    {
        _triggerEvent.TriggerEvent += CheckScore;
    }

    private void CheckScore()
    {
        _slider.value += _pickedEnergy;
    }
}
