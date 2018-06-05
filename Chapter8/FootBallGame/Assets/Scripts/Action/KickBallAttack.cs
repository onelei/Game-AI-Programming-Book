/// <summary>
/// 踢球AI.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class KickBallAttack : Action
	{ 
        /// <summary>
        /// 球员;
        /// </summary>
		private Agent agent;
        /// <summary>
        /// 足球;
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
        /// <summary>
        /// 目标点的位置;
        /// </summary>
		private Vector3 targetLocation;
        /// <summary>
        /// 球员的阵营;
        /// </summary>
		private bool bLeft;
		public override void OnStart ()
		{
            //获取身上的Agent脚本;
			agent = GetComponent<Agent> ();
            //获取足球脚本;
			Ball = agent.GetBall().GetComponent<Ball> ();
            //获取自己的阵营;
			bLeft = agent.GetTeamDirection ();
		}

		public override TaskStatus OnUpdate()
		{
            //获取球的位置;
			ballLocation = agent.GetBallLocation ();
            //获取自身的位置;
			agentLocation = agent.transform.position;
            //如果足球在自己的可踢范围内;
			if (Condition.CanKickBall(agentLocation, ballLocation)) {
                //朝向球的方向;
				agent.transform.LookAt (ballLocation);
                //根据自己的阵营,给球一个力;
				if (bLeft) {
					Ball.AddForce (ballLocation,Define.RightDoorPosition);
				} else {
					Ball.AddForce (ballLocation,Define.LeftDoorPosition); 
				}
                //返回成功;
				return TaskStatus.Success;  
			} else 
			{
                //获取自己在攻击阵型里面的位置;
				targetLocation = AgentGroupHelper.Instance.GetAttackGroupLocation (agent,ballLocation,bLeft);
                //设置自己的目标点;
				agent.SetDestination (targetLocation); 
                //返回进行中;
				return TaskStatus.Running;   
			}  
		}


	}
}   

