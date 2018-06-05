/********************************************************************************
** auth： Onelei
** date： 2017/7/9 16:04:28
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace Assets.Sample
{
    public class ActionB : Action
    {
        public void DoAction()
        {
            Debug.LogWarning("执行B行为");
        }
        public override TaskStatus OnUpdate()
        {
            DoAction();
            return TaskStatus.Success;
        }
    }
}
