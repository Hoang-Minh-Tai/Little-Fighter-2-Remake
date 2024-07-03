using UnityEngine;

public abstract class State
{
    protected Animator _animator;
    protected ActionHandler _actionHandler;
    protected IController _controller;
    private StateMachine _stateMachine;

    public State(StateMachine stateMachine)
    {
        _actionHandler = stateMachine.ActionHanlder;
        _animator = stateMachine.Animator;
        _controller = stateMachine.Controller;
        _stateMachine = stateMachine;
    }

    public abstract void Enter();
    protected abstract void Update();
    public abstract void Exit();

    public void Execute()
    {
        Update();

        _animator.SetBool("onGround", _actionHandler.z == 0);
        _animator.SetBool("moving", _actionHandler.forceX != 0 || _actionHandler.forceY != 0);

    }

    protected void MoveHorizontal()
    {
        float direction = _controller.GetHorizontalAxis();

        _actionHandler.ChangeDirection(direction);
        _actionHandler.MoveHorizontal(direction);
    }

    protected void MoveVertical()
    {
        _actionHandler.MoveVertical(_controller.GetVerticalAxis());
    }

    protected void ChangeState(StateEnum state)
    {
        _stateMachine.ChangeState(state);
    }
}