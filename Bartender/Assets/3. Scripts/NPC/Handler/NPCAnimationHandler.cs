using System.Collections;
using UnityEngine;

public class NPCAnimationHandler : MonoBehaviour
{
    [Header("Animator")]
    [Tooltip("NPC의 Animator 컴포넌트")]
    public Animator animator;

    private string currentBoolAnimation; // 현재 활성화된 Bool 파라미터 이름


    // Bool 타입 애니메이션을 켜고, 이전 애니메이션은 자동으로 꺼준다.
    public void SetAnimation(string animationName, bool state)
    {
        if (currentBoolAnimation == animationName && animator.GetBool(animationName) == state)
            return;

        // 이전 애니메이션 비활성화
        if (!string.IsNullOrEmpty(currentBoolAnimation) && currentBoolAnimation != animationName)
        {
            animator.SetBool(currentBoolAnimation, false);
        }

        animator.SetBool(animationName, state);
        currentBoolAnimation = state ? animationName : "";
    }

    // Trigger 애니메이션 실행

    public void SetTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }


    // 현재 실행 중인 애니메이션이 이름과 일치하고, 완료되었는지 체크
    public bool CheckFinishAnimation(string animationStateName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationStateName) && stateInfo.normalizedTime >= 1.0f;
    }


}
