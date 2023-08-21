namespace StateMachineExample.Scripts
{
    public interface IState
    {
        public void OnEnter(StateMachineController stateMachineController);
        public void UpdateState(StateMachineController stateMachineController);
        public void OnHurt(StateMachineController stateMachineController);
        public void OnExit(StateMachineController stateMachineController);
    }
}