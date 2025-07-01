using UnityEngine;

public class TutorialTransforms : MonoBehaviour
{
    [SerializeField]
    private OptionalVector3[] _positions;

    [SerializeField]
    private OptionalQuaternion[] _rotations;

    [SerializeField]
    private OptionalVector3[] _scales;

    [Space]

    [SerializeField]
    private Transform _transform;

    private void OnEnable()
    {
        if (_transform == null)
        {
            _transform = transform;
        }
    }


    public void ApplyStepTransform(int step)
    {
        if (step >= 0 && step < _positions.Length && _positions[step].Use)
        {
            _transform.position = _positions[step].Vector;
        }

        if (step >= 0 && step < _rotations.Length && _rotations[step].Use)
        {
            _transform.rotation = _rotations[step].Rotation;
        }

        if (step >= 0 && step < _scales.Length && _scales[step].Use)
        {
            _transform.localScale = _scales[step].Vector;
        }
    }
}

[System.Serializable]
public class OptionalVector3
{
    public readonly bool Use;
    public Vector3 Vector;
}

[System.Serializable]
public class OptionalQuaternion
{
    public readonly bool Use;
    public Quaternion Rotation;
}