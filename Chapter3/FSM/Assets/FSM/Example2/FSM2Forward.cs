/********************************************************************************
** auth： Onelei
** date： 2017/7/4 15:12:07
** desc： 状态A;
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;

namespace FSM2
{
    public class FSM2Forward : FSM2Base
    {
        public FSM2Forward(Animator animator)
            :base(animator)
        {

        }

        private int forwardCount = 0;
        private int FROWARD_COUNT_SPEED = 1; 

        /// <summary>
        /// 进入状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(NPCState _state)
        {
            //进入前进动作；
            doForward();
            Debug.Log("进入前进动作");
        }

        /// <summary>
        /// 退出状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(NPCState _state)
        { 
            //清除计数器;
            forwardCount = 0;
            Debug.Log("退出前进动作");
        }

        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ++forwardCount;
                if (forwardCount > FROWARD_COUNT_SPEED)
                {
                    // 加速；
                    doForwardSpeed();
                    Debug.Log("前进加速动作");
                }
            }
        }

    }
}
