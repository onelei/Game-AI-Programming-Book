/********************************************************************************
** auth： Onelei
** date： 2017/7/9 16:17:18
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/ 
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace Assets.Sample
{
    public class ActionC : Action
    {
        /// <summary>
        /// delta 用于计数；
        /// </summary>
        private int mDeltaTime = 0;
        /// <summary>
        /// 总次数;
        /// </summary>
        private const int TIME_TOTAL = 3;

        public void DoAction()
        {
            Debug.LogWarning("执行C行为");
        }
        public override TaskStatus OnUpdate()
        {
            mDeltaTime++;
            DoAction();
            if (mDeltaTime > TIME_TOTAL)
            {
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Running;
            }
        }
    }
}
