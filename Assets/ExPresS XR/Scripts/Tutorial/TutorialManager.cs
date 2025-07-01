using System;
using System.Collections;
using System.Collections.Generic;
using ExPresSXR.Misc;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private int _numSteps = 1;
    public int NumSteps
    {
        get => _numSteps;
        private set
        {
            _numSteps = Mathf.Min(value, 1);

            Array.Resize(ref OnTutorialStepCompleted, _numSteps);
        }
    }

    [SerializeField]
    [ReadonlyInInspector]
    private int _currentStep;
    public int CurrentStep
    {
        get => _currentStep;
        set
        {
            int previousStep = _currentStep;
            _currentStep = Mathf.Clamp(value, 0, _numSteps + 1);

            if (_currentStep == 0)
            {
                OnTutorialStarted.Invoke();
            }
            (_currentStep < _numSteps ? OnTutorialStepCompleted[previousStep] : OnTutorialCompleted).Invoke();
            OnTutorialStepStarted.Invoke(value);
        }
    }

    [SerializeField]
    private bool _autoStart;

    [Space]

    [SerializeField]
    private TutorialAnimator[] _tutorialAnimators;

    [SerializeField]
    private TutorialTriggerAnimations[] _tutorialTriggerAnimations;

    [SerializeField]
    private TutorialTriggerAnimations[] _tutorialStepAnimations;

    [SerializeField]
    private TutorialTexts[] _tutorialTexts;

    [SerializeField]
    private TutorialTransforms[] _tutorialTransforms;


    [Space]

    public UnityEvent OnTutorialStarted;

    public UnityEvent[] OnTutorialStepCompleted;

    public UnityEvent<int> OnTutorialStepStarted;

    public UnityEvent OnTutorialCompleted;

    private void OnEnable()
    {
        if (OnTutorialStepCompleted.Length != _numSteps)
        {
            Debug.LogWarning($"OnTutorialStepCompleted length(={OnTutorialStepCompleted.Length}) and number of steps (={_numSteps}) were not equal. Resizing TutorialSteps to {_numSteps}.");
            Array.Resize(ref OnTutorialStepCompleted, _numSteps);
        }
        ConnectSignals();

        if (_autoStart)
        {
            CurrentStep = 0;
        }
    }

    private void OnDisable()
    {
        DisconnectSignals();
    }


    private void ConnectSignals()
    {
        foreach (TutorialAnimator tutAnim in _tutorialAnimators)
        {
            OnTutorialStepStarted.AddListener(tutAnim.TriggerStepAnimation);
        }

        foreach (TutorialTriggerAnimations tutTriggerAnim in _tutorialTriggerAnimations)
        {
            OnTutorialStepStarted.AddListener(tutTriggerAnim.TriggerStepAnimation);
        }

        foreach (TutorialTriggerAnimations tutStepAnim in _tutorialStepAnimations)
        {
            OnTutorialStepStarted.AddListener(tutStepAnim.TriggerStepAnimation);
        }

        foreach (TutorialTexts tutText in _tutorialTexts)
        {
            OnTutorialStepStarted.AddListener(tutText.TriggerTexts);
        }

        foreach (TutorialTexts tutText in _tutorialTexts)
        {
            OnTutorialStepStarted.AddListener(tutText.TriggerTexts);
        }
    }

    private void DisconnectSignals()
    {
        foreach (TutorialAnimator tutAnim in _tutorialAnimators)
        {
            OnTutorialStepStarted.RemoveListener(tutAnim.TriggerStepAnimation);
        }

        foreach (TutorialTriggerAnimations tutTriggerAnim in _tutorialTriggerAnimations)
        {
            OnTutorialStepStarted.RemoveListener(tutTriggerAnim.TriggerStepAnimation);
        }

        foreach (TutorialTriggerAnimations tutStepAnim in _tutorialStepAnimations)
        {
            OnTutorialStepStarted.RemoveListener(tutStepAnim.TriggerStepAnimation);
        }

        foreach (TutorialTexts tutText in _tutorialTexts)
        {
            OnTutorialStepStarted.RemoveListener(tutText.TriggerTexts);
        }

        foreach (TutorialTexts tutText in _tutorialTexts)
        {
            OnTutorialStepStarted.RemoveListener(tutText.TriggerTexts);
        }
    }

    [ContextMenu("Start Tutorial")]
    public void StartTutorial() => CurrentStep = 0;

    [ContextMenu("Increase Tutorial Step")]
    public void IncreaseStep() => CurrentStep++;

    [ContextMenu("Complete Tutorial")]
    public void CompleteTutorial() => CurrentStep = _numSteps + 1;
}
