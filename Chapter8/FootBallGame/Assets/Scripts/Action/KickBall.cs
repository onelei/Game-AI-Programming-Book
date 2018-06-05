/// <summary>
/// Kick ball.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class KickBall : Action
	{ 
        /// <summary>
        /// Agent;
        /// </summary>
		private Agent mAgent;
        /// <summary>
        /// 足球;
        /// </summary>
		private Ball Ball;
        /// <summary>
        /// 球的位置;
        /// </summary>
		private Vector3 ballLocation;
        /// <summary>
        /// Agent的位置;
        /// </summary>
		private Vector3 agentLocation;
        /// <summary>
        /// 初始化;
        /// </summary>
		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
			Ball = mAgent.GetBall().GetComponent<Ball> ();
		}
        /// <summary>
        /// 更新函数;
        /// </summary>
        /// <returns></returns>
		public override TaskStatus OnUpdate()
		{
            // 获取球的位置和Agent的位置;
			ballLocation = mAgent.GetBallLocation ();
			agentLocation = mAgent.transform.position;
            
            //当Agent和球的位置在一定范围内,就可以踢球; 
			if (Mathf.Abs (agentLocation.x - ballLocation.x) < Define.CanKickBallDistance && Mathf.Abs (agentLocation.z - ballLocation.z) < Define.CanKickBallDistance)
			{
                // 默认是向右边球门踢过去,设置球员的朝向;
				mAgent.transform.LookAt (Define.RightDoorPosition);
                // 设置足球的运动方向和力度;
				Ball.AddForce (ballLocation,Define.RightDoorPosition);  
                // 返回成功;
				return TaskStatus.Success;  
			} 
			else 
			{ 
                // 不在可踢范围内就移动过去;
				mAgent.SetDestination (ballLocation); 
                // 返回正在进行中;
				return TaskStatus.Running;    
			}  
		}


	}
}   
