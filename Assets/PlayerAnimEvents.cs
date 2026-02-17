using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    [SerializeField] AdvancedMoveController AdvancedMoveController;

    float chargeMulti = 2f;

    /// <summary>
    /// Applies the charged jump force once you hold the input for the required duration, 1.2f.
    /// </summary>

    public void PerformChargedJump()
    {

        AdvancedMoveController.isChargingJump = false;
        AdvancedMoveController.chargeFullyTriggered = false;
        transform.localScale = Vector3.one;

        // checks to see if you have been on the ground long enough to perform charge jump.

        if (AdvancedMoveController.timeGrounded < AdvancedMoveController.groundedTimeBeforeJump)
            return;

        // Prevents jumping too close together from last jump.
        AdvancedMoveController.lastJumpedTime = Time.time;

        // Prevents using a different jump force if you have been chaining jumps and then decide to do a charge jump, it will always use the base jump force.
        AdvancedMoveController.jumpChainCount = 0;

        // Selects Daniels base Jump Force from the array. We don't want to charge jump on double jumps or anything else.
        Vector3 baseForce = AdvancedMoveController.consecutiveJumpForces[0];

        // Applies the charge multiplier to verticle force.
        Vector3 chargedForce = new Vector3(
            baseForce.x,
            baseForce.y * chargeMulti,
            baseForce.z
        );

        if (AdvancedMoveController.jumpAudio)
            AdvancedMoveController.jumpAudio.PlaySound(transform.position);

        AdvancedMoveController.ApplyJumpForce(chargedForce);
    }
}
