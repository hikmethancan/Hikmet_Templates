using StateMachineExample.Scripts.States;
using UnityEngine;

namespace StateMachineExample.Scripts
{
    public class StateMachineController : MonoBehaviour
    {
        IState _currentState;
        [Tooltip("Joystick Reference")] public DynamicJoystick dynamicJoystick;
        
        public PlayerState playerState = new PlayerState();
        public Drone1State drone1State = new Drone1State();
        public Drone2State drone2State = new Drone2State();
        public Drone3State drone3State = new Drone3State();

        private void Start()
        {
            ChangeState(playerState);
        }

        void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState(this);
            }
        }

        public void ChangeState(IState newState)
        {
            if (_currentState != null)
            {
                _currentState.OnExit(this);
            }

            _currentState = newState;
            _currentState.OnEnter(this);
        }
    }
}