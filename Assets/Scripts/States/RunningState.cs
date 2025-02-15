using UnityEngine;
using UnityEngine.Playables;

public class RunningState : State
{
    public RunningState(PlayerController player) : base(player) { }

    public override void EnterState()
    {
        player.animator.SetBool("isRunning", true);
    }

    public override void UpdateState()
    {
        player.MoveCharacter();
        if (!player.IsMoving()) player.SetState(new IdleState(player));
        if (player.IsJumping()) player.SetState(new JumpingState(player));
    }

    public override void ExitState()
    {
        player.animator.SetBool("isRunning", false);
    }
}
