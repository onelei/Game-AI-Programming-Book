using UnityEngine;
using lemon_bt_CShape;

namespace Assets.Sample.SelectNode
{
    public class Idle : Bt_Action
    {
        private Animator animator;

        Bt_Result result = Bt_Result.SUCCESSFUL;


        public Idle(Animator animator)
        {
            this.animator = animator;
        }

        public override Bt_Result doAction()
        {
            doIdle();
            return result;
        }

        void doIdle()
        {
            animator.SetBool("Ground",true);
            animator.SetFloat("Speed", 0f);
            LogHelper.Instance.Log("宅在家:" + result); 
        }
    }
}
