using UnityEngine;

public class TutorialTriggerAnimations : MonoBehaviour
{
    [SerializeField]
    private string[] _triggers;
    
    [Space]

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
        if (step >= 0 && step < _triggers.Length && _triggers[step] != "")
        {
            _animator.SetTrigger(_triggers[step]);
        }
    }
}