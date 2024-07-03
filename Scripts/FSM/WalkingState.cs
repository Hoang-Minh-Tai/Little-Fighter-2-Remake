public class WalkingState : State
{
    public WalkingState(StateMachine stateMachine) : base(stateMachine)
    {
        
    }
    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    protected override void Update()
    {
        MoveHorizontal();
        MoveVertical();

        if (_controller.GetActionDown(Action.Attack))
        {
            _animator.SetTrigger("attack1");
        }
    }
}