/********************************************************************************
** auth： Onelei
** date： 2017/12/18 22:27:34
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/
using lemon_bt_CShape;
using UnityEngine;

namespace Assets.Sample.SelectNode
{
    public class Run : Bt_Action
    {
        private Animator animator;

        Bt_Result result = Bt_Result.SUCCESSFUL;

        public Run(Animator animator)
        {
            this.animator = animator;
        }

        public override Bt_Result doAction()
        {
            doRun();
            return result;
        }

        void doRun()
        {
            animator.SetBool("Ground",true);
            animator.SetFloat("Speed", 5f);
            LogHelper.Instance.Log("逛街:" + result);
        }
    }
}
