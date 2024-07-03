public enum Action
{
    Attack,
    Jump,
    Defend
}

public interface IController
{
    float GetVerticalAxis();
    float GetHorizontalAxis();
    bool GetAction(Action action);
    bool GetActionDown(Action action);
    bool GetActionUp(Action action);
    float GetMoveDoublePress();    
}