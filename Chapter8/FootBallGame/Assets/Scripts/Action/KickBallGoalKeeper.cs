/// <summary>
/// 守门员的踢球策略;
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
    public class KickBallGoalKeeper : Action
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
        /// 足球位置;
        /// </summary>
        private Vector3 ballLocation;
        /// <summary>
        /// 球员位置;
        /// </summary>
        private Vector3 agentLocation;

        public override void OnStart()
        {
            //球员脚本;
            mAgent = GetComponent<Agent>();
            //足球脚本;
            Ball = mAgent.GetBall().GetComponent<Ball>();
        }

        public override TaskStatus OnUpdate()
        {
            //获取足球位置;
            ballLocation = mAgent.GetBallLocation();
            //获取球员位置;
            agentLocation = mAgent.transform.position;
            //判断足球是否进入了守门员的防守区域;
            if (Condition.CanGoalKeeper(ballLocation))
            {
                //判断能否踢球;
                if (Condition.CanKickBall(agentLocation, ballLocation))
                {
                    //朝向足球;
                    mAgent.transform.LookAt(ballLocation);
                    //根据自己的阵营来给球一个方向上的力;
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
                    //离球较远,向球移动;
                    mAgent.SetDestination(ballLocation);
                    return TaskStatus.Running;
                }
            }
            //没有进入守门员区域,返回失败;
            return TaskStatus.Failure;

        }


    }
}    
