using UnityEngine;
using UnityEngine.Events;

namespace ExPresSXR.Misc
{
    public class ConditionalEventSwitcher : MonoBehaviour
    {
        [Tooltip("A description of the condition. No further use.")]
        [SerializeField]
        private string _description = "";
        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        [SerializeField]
        private bool _condition;
        public bool Condition
        {
            get => _condition;
            set
            {
                bool changed = _condition != value;
                _condition = value;

                if (_autoEmitWhenSet && (!_onlyEmitWhenChanged || _onlyEmitWhenChanged && changed))
                {
                    InvokeConditionalEvent();
                }

                OnConditionChanged.Invoke(_condition);
                OnConditionChangedNegated.Invoke(!_condition);
            }
        }

        [SerializeField]
        private bool _autoEmitWhenSet = true;
        public bool AutoEmitWhenSet
        {
            get => _autoEmitWhenSet;
            set
            {
                _autoEmitWhenSet = value;
            }
        }

        [SerializeField]
        private bool _onlyEmitWhenChanged = true;
        public bool OnlyEmitWhenChanged
        {
            get => _onlyEmitWhenChanged;
            set
            {
                _onlyEmitWhenChanged = value;
            }
        }

        public UnityEvent OnTrueEvent;
        public UnityEvent OnFalseEvent;

        public UnityEvent<bool> OnConditionChanged;
        public UnityEvent<bool> OnConditionChangedNegated;


        public void InvokeConditionalEvent() => (_condition ? OnTrueEvent : OnFalseEvent).Invoke();

        public void ToggleConditional() => Condition = !_condition;

    }
}