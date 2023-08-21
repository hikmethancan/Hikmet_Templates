namespace StateMachineExample.Scripts.States
{
    public class PlayerState : IState
    {
        public void OnEnter(StateMachineController stateMachineController)
        {
            CameraManager.onCameraChanged?.Invoke(0);
        }

        public void UpdateState(StateMachineController stateMachineController)
        {
            throw new System.NotImplementedException();
        }

        public void OnHurt(StateMachineController stateMachineController)
        {
            throw new System.NotImplementedException();
        }

        public void OnExit(StateMachineController stateMachineController)
        {
            throw new System.NotImplementedException();
        }
    }
}