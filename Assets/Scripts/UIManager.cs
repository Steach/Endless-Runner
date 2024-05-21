using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ExecutorOnPhysics _triggerEvent;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private int _score = 0;

    private void Awake()
    {
        _triggerEvent.TriggerEvent += CheckScore;
    }

    private void CheckScore()
    {
        _score += 1;
        _textMeshPro.text = _score.ToString();
    }
}
