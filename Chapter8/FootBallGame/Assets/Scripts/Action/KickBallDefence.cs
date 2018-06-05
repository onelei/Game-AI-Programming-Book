/// <summary>
/// 防守阵营的踢球策略;
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
    public class KickBallDefence : Action
    {
        /// <summary>
        /// 球员脚本;
        /// </summary>
        private Agent mAgent;
        /// <summary>
        /// 足球脚本;
        /// </summary>
        private Ball Ball;
        /// <summary>
        /// 球的位置;
        /// </summary>
        private Vector3 ballLocation;
        /// <summary>
        /// 球员的位置;
        /// </summary>
        private Vector3 agentLocation;

        public override void OnStart()
        {
            //获取球员脚本;
            mAgent = GetComponent<Agent>();
            //获取足球脚本;
            Ball = mAgent.GetBall().GetComponent<Ball>();
        }

        public override TaskStatus OnUpdate()
        {
            //获取足球位置;
            ballLocation = mAgent.GetBallLocation();
            //获取球员位置;
            agentLocation = mAgent.transform.position;
            //判断能否踢球;
            if (Condition.CanKickDefence(agentLocation, ballLocation))
            {
                //离球很近,可以踢球,就给球一个力;
                if (Condition.CanKickBall(agentLocation, ballLocation))
                {
                    //朝向球;
                    mAgent.transform.LookAt(ballLocation);
                    //根据自己的阵营,给球一个力;
                    bool bLeft = mAgent.GetTeamDirection();
                    if (bLeft)
                    {
                        Ball.AddForce(ballLocation, Define.RightDoorPosition);
                    }
                    else
                    {
                        Ball.AddForce(ballLocation, Define.LeftDoorPosition);
                    }
                    //返回成功;
                    return TaskStatus.Success;
                }
                else
                {
                    //可以踢球,但是离球较远,就向球移动,返回进行中;
                    mAgent.SetDestination(ballLocation);
                    return TaskStatus.Running;
                }
            }
            //不能踢球返回失败;
            return TaskStatus.Failure;

        }


    }
}     

