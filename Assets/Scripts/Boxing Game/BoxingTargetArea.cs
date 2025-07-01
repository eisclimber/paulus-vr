using ExPresSXR.Minigames.TargetArea;
using ExPresSXR.Misc.Timing;
using UnityEngine;
using UnityEngine.Events;

public class BoxingTargetArea : TargetArea
{
    [SerializeField]
    private GameObject _damageDisplayPrefab;

    [SerializeField]
    private float _damageMultiplier = 100.0f;

    [SerializeField]
    private AnimationCurve _pointsDistribution = new();

    [SerializeField]
    private float _pointsDisplayScale = 0.35f;

    [SerializeField]
    private Vector3 _pointsDisplayOffset;

    [SerializeField]
    private Timer _timer;

    [SerializeField]
    private Animator _animator;


    public UnityEvent OnFailed;
    public UnityEvent OnEnabled;
    public UnityEvent OnDisabled;

    private void OnEnable()
    {
        OnEnabled.Invoke();
        OnActionPerformed.AddListener(HitTarget);

        if (_timer)
        {
            _timer.StartTimerDefault();
            _timer.OnTimeout.AddListener(FailTarget);
        }

        if (_animator)
        {
            _animator.SetTrigger("TrPlay");
        }
    }

    private void OnDisable()
    {
        OnDisabled.Invoke();
        OnActionPerformed.RemoveListener(HitTarget);

        if (_timer != null)
        {
            _timer.OnTimeout.RemoveListener(FailTarget);
            _timer.StopTimer();
        }
    }

    private void FailTarget()
    {
        OnFailed.Invoke();
        enabled = false;
    }

    private void HitTarget()
    {
        ShowDamageDisplay();
        enabled = false;
    }

    private void ShowDamageDisplay()
    {
        GameObject scoreNumbersGo = Instantiate(_damageDisplayPrefab); // Instantiate without parent to avoid canvas rotation problems
        scoreNumbersGo.transform.SetPositionAndRotation(transform.position + _pointsDisplayOffset, Quaternion.identity);
        scoreNumbersGo.transform.localScale = Vector3.one * _pointsDisplayScale;

        if (scoreNumbersGo.TryGetComponent(out ScoreNumbers scoreNumbers))
        {
            float pct = _timer != null && _timer.waitTime >= 0 ? _timer.remainingTime / _timer.waitTime : 1.0f;
            scoreNumbers.Score = (int)Mathf.Ceil(_pointsDistribution.Evaluate(1.0f - pct) * _damageMultiplier);
        }
    }
}