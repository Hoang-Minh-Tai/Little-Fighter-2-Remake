using UnityEngine;

public enum StateEnum
{
    Walking,
    Running,
    Jumping,
    SprintJumping,
} 

public class StateMachine : MonoBehaviour
{
    private Animator _animator;
    private ActionHandler _actionHandler;
    private IController _controller;

    private State _currentState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<IController>();
        _actionHandler = GetComponent<ActionHandler>();

        _currentState = new WalkingState(this);
    }

    #region Properties
    public Animator Animator => _animator;
    public IController Controller => _controller;
    public ActionHandler ActionHanlder=> _actionHandler;
    #endregion

    private void Update()
    {
        _currentState.Execute();
    }

    public void ChangeState(StateEnum state)
    {
        _currentState.Exit();
        switch (state)
        {
            case StateEnum.Walking:
                _currentState = new WalkingState(this);
                break;
            default:
                _currentState = new WalkingState(this);
                break;
        }
    }
}