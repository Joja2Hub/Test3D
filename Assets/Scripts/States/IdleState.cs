using UnityEngine;
using UnityEngine.Playables;

public class IdleState : State
{
    public IdleState(PlayerController player) : base(player) { }

    public override void EnterState()
    {
        player.animator.SetBool("isRunning", false);
        player.animator.SetBool("isJumping", false);
    }

    public override void UpdateState()
    {
        if (player.IsMoving()) player.SetState(new RunningState(player));
        if (player.IsJumping()) player.SetState(new JumpingState(player));
    }

    public override void ExitState() { }
}
