using UnityEngine;

public class TutorialStepAnimations : MonoBehaviour
{
    [SerializeField]
    private string _paramName = "State";

    [SerializeField]
    private Animator _animator;

    private void OnEnable()
    {
        if (_animator == null && !TryGetComponent(out _animator))
        {
            Debug.LogError("Did not find an Animator component to trigger animations.", this);
        }
    }

    public void TriggerStepAnimation(int step)
    {
        _animator.SetInteger(_paramName, step);
    }
}