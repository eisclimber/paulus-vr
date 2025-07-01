using ExPresSXR.Misc;
using UnityEngine;
using UnityEngine.Events;

public class MaxCounter : MonoBehaviour
{
    [SerializeField]
    private int _maxCount;
    public int MaxCount
    {
        get => _maxCount;
        set => _maxCount = value;
    }

    [SerializeField]
    private bool _emitOnlyIfEqual = true;
    public bool EmitOnlyIfEqual
    {
        get => _emitOnlyIfEqual;
        set => _emitOnlyIfEqual = value;
    }

    [SerializeField]
    [ReadonlyInInspector]
    private int _currentCount;
    public int CurrentCount
    {
        get => _currentCount;
        private set
        {
            if (!isActiveAndEnabled) // Ignore if not active
            {
                return;
            }

            _currentCount = value;

            if ((_emitOnlyIfEqual && _currentCount == _maxCount) || (!_emitOnlyIfEqual && _currentCount >= _maxCount))
            {
                OnMaxCount.Invoke();
            }
        }
    }

    public UnityEvent OnMaxCount;

    private void OnEnable()
    {
        CurrentCount = 0;
    }

    [ContextMenu("Increase Count")]
    public void IncreaseCount() => CurrentCount++;

    [ContextMenu("Decrease Count")]
    public void DecreaseCount() => CurrentCount--;

    [ContextMenu("Reset Count")]
    public void ResetCount() => CurrentCount = 0;
}