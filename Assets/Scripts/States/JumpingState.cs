using UnityEngine;

public class JumpingState : State
{
    public JumpingState(PlayerController player) : base(player) { }

    public override void EnterState()
    {
        player.animator.SetBool("isJumping", true);
        player.Jump();
    }

    public override void UpdateState()
    {
        player.HandleAirControl();

        if (player.controller.isGrounded)
        {
            ExitState();

            if (player.IsMoving())
            {
                player.SetState(new RunningState(player));
            }
            else
            {
                player.SetState(new IdleState(player));
            }
        }
    }

    public override void ExitState()
    {
        player.animator.SetBool("isJumping", false);
    }
}
