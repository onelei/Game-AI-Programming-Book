/*
 * 判断是否进入了守门员的防守区域;
 */ 
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class IsEnterGoalKeeperField : Conditional
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

		public override void OnStart ()
		{
            //获取球员脚本;
			mAgent = GetComponent<Agent> ();
            //获取足球脚本;
			Ball = mAgent.GetBall().GetComponent<Ball> ();
		}

		public override TaskStatus OnUpdate()
		{
            //获取足球位置;
			ballLocation = mAgent.GetBallLocation ();
            //获取球员的位置;
			agentLocation = mAgent.transform.position;
            //判断是否进入了守门员的区域,是的话返回成功.否则返回失败;
			if (Condition.CanGoalKeeper(ballLocation))
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

