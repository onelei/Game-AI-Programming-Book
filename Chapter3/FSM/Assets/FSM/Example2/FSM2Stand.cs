/********************************************************************************
** auth： Onelei
** date： 2017/7/4 15:12:07
** desc： 状态A;
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;

namespace FSM2
{
    public class FSM2Stand : FSM2Base
    {
        public FSM2Stand(Animator animator)
            : base(animator)
        {

        }
        /// <summary>
        /// 进入状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnEnterState(NPCState _state)
        {
            //进入站立动作；
            doIdle();
            Debug.Log("进入站立动作");
        }

        /// <summary>
        /// 退出状态；
        /// </summary>
        /// <param name="_state"></param>
        protected override void OnExitState(NPCState _state)
        {
            //退出站立动作；
            doIdle();
            Debug.Log("退出站立动作");
        }

        /// <summary>
        /// 更新状态;
        /// </summary>
        public override void OnUpdateState()
        { 

        }
         
    }
}
