using System;
using System.Collections.Generic;
using Move;
using UnityEngine;

namespace StateMachines
{
    public class StateMachine
    {
        private IState _currentState;

        private Dictionary<Type, List<Transition>> _states = new Dictionary<Type, List<Transition>>();

        private List<Transition> _currentStates = new List<Transition>();
        private List<Transition> _anyStates = new List<Transition>();

        private List<Transition> _emptyStates = new List<Transition>(0);

        public void Tick()
        {
            var transition = GetTransition();

            if (transition != null)
            {
                SetState(transition.To);
            }
            
            _currentState?.Execute();
        }

        public void SetState(IState state)
        {
            if (state == _currentState)
            {
                return;
            }
            
            _currentState?.Exit();

            _currentState = state;
            
            _states.TryGetValue(_currentState.GetType(), out _currentStates);

            if (_currentStates == null)
            {
                _currentStates = _emptyStates;
            }

            _currentState?.Enter();
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (predicate == null)
            {
                return;
            }

            if (_states.TryGetValue(from.GetType(), out var states) == false)
            {
                states = new List<Transition>();
                _states[from.GetType()] = states;
            }
            
            states.Add(new Transition(to, predicate));
        }

        public void AddAnyTransition(IState state, Func<bool> predicate)
        {
            if (predicate == null)
            {
                return;
            }

            _anyStates.Add(new Transition(state, predicate));
        }

        private Transition GetTransition()
        {
            foreach (var state in _anyStates)
            {
                if (state.Condition())
                {
                    return state;
                }
            }
            
            foreach (var state in _currentStates)
            {
                if (state.Condition())
                {
                    return state;
                }
            }

            return null;
        }
    }
}