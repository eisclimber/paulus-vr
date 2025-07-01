using UnityEngine;

public class TutorialAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator[] _animators;

    public void TriggerStepAnimation(int step)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            if (_animators[i] != null)
            {
                _animators[i].gameObject.SetActive(i == step);
            }
        }
    }
}