public abstract class State
{
    protected PlayerController player;

    public State(PlayerController player)
    {
        this.player = player;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();




}
