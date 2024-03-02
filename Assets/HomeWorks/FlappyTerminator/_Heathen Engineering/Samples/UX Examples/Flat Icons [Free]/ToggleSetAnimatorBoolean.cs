using UnityEngine;

namespace HomeWorks.FlappyTerminator._Heathen_Engineering.Samples.UX_Examples.Flat_Icons__Free_
{
    public class ToggleSetAnimatorBoolean : MonoBehaviour
    {
        public Animator animator;
        public string booleanName;

        public void SetBoolean(bool value)
        {
            animator.SetBool(booleanName, value);
        }
    }
}
