/********************************************************************************
** auth： Onelei
** date： 2017/7/9 16:02:46
** desc： 描述
** Ver.:  V1.0.0
*********************************************************************************/
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

namespace Assets.Sample
{
    public class ActionA : Action
    {
        public void DoAction()
        {
            Debug.LogWarning("执行A行为");
        }

        public override TaskStatus OnUpdate()
        {
            DoAction();
            return TaskStatus.Failure;
        }
    }
}
