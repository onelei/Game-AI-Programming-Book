/// <summary>
/// 能否看到球.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
    public class CanSeeBall : Conditional
    {
        /// <summary>
        /// 球员;
        /// </summary>
        private Agent Agent;
        /// <summary>
        /// 球;
        /// </summary>
        private Ball Ball;

        public override void OnStart()
        {
            //获取球员脚本;
            Agent = GetComponent<Agent>();
            //获取足球脚本;
            Ball = Agent.GetBall().GetComponent<Ball>();
        }

        public override TaskStatus OnUpdate()
        {
            //如果能够看到球,就返回成功.否则返回失败;
            if (Condition.CanSeeBall(Agent.transform.position, Ball.transform.position))
            {
                return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Failure;
            }
        }


    }
}