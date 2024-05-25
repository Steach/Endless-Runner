using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private RestartButton _restartButtonAction;

    [SerializeField] private Button _exitButton;
    [SerializeField] private ExitButton ExitButtonAction;

    private void Awake()
    {
        _restartButton.onClick.AddListener(_restartButtonAction.RestartGame);
        _exitButton.onClick.AddListener(ExitButtonAction.ExitGame);
    }
}