using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public enum AnimationsList { run, jump, fall }

    [SerializeField] private Animator _animator;
    private AnimationsList _currentAnimation;
    private string _animatorParametrName;

    [SerializeField] private Controller _controller;

    private void Awake()
    {
        _animatorParametrName = _animator.GetParameter(0).name;
    }

    private void Update()
    {
        PlayAnimation(AnimationsList.jump, _controller.IsJump);
        PlayAnimation(AnimationsList.fall, _controller.IsGameOver);
    }

    private void PlayAnimation(AnimationsList animationState, bool active)
    {
        if (animationState < _currentAnimation)
            return;

        if (!active)
        {
            if (animationState == _currentAnimation)
            {
                _animator.SetInteger(_animatorParametrName, (int)AnimationsList.run);
                _currentAnimation = AnimationsList.run;
            }

            return;
        }

        _animator.SetInteger(_animatorParametrName, (int)animationState);
        _currentAnimation = animationState;
    }
}
