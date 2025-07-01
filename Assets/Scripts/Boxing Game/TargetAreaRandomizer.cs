using UnityEngine;

public class TargetAreaRandomizer : MonoBehaviour
{
    [SerializeField]
    private bool _randomizeOnAwake = true;

    [SerializeField]
    private BoxingTargetArea[] _targetAreas;

    [SerializeField]
    private float _minDelay = 1.0f;

    [SerializeField]
    private float _maxDelay = 3.0f;

    private void Start()
    {
        if (_randomizeOnAwake)
        {
            RandomizeActiveTarget();
        }
    }

    private void OnEnable()
    {
        foreach (BoxingTargetArea targetArea in _targetAreas)
        {
            targetArea.OnActionPerformed.AddListener(RandomizeActiveTargetDelayed);
            targetArea.OnFailed.AddListener(RandomizeActiveTargetDelayed);
        }
    }

    private void OnDisable()
    {
        foreach (BoxingTargetArea targetArea in _targetAreas)
        {
            targetArea.OnActionPerformed.RemoveListener(RandomizeActiveTargetDelayed);
            targetArea.OnFailed.RemoveListener(RandomizeActiveTargetDelayed);
        }
    }

    // Use this because somehow the triggering is buggy when retriggering the same target immediately
    private void RandomizeActiveTargetDelayed() => Invoke(nameof(RandomizeActiveTarget), Random.Range(_minDelay, _maxDelay));


    [ContextMenu("Randomize Active Target")]
    private void RandomizeActiveTarget()
    {
        int nextIdx = Random.Range(0, _targetAreas.Length);
        for (int i = 0; i < _targetAreas.Length; i++)
        {
            _targetAreas[i].enabled = i == nextIdx;
        }
    }
}