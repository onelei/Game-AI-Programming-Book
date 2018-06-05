using UnityEngine;
using System.Collections.Generic;

namespace FootBallGame
{
	public class Condition
	{
		public static bool CanSeeBall(Vector3 agentLocation,Vector3 ballLocation)
		{
			if (Mathf.Abs(agentLocation.x- ballLocation.x)< Define.See_Circle&&Mathf.Abs(agentLocation.z- ballLocation.z)<Define.See_Circle) {
				if (ballLocation.y < 0.5f) {
					return true;
				}
			}
			return false;	
		} 

		public static bool CanKickBall(Vector3 agentLocation,Vector3 ballLocation)
		{
			if(ballLocation.y>=2)
			{
				return false;
			}
			if (Mathf.Abs (agentLocation.x - ballLocation.x) < Define.CanKickBallDistance && Mathf.Abs (agentLocation.z - ballLocation.z) < Define.CanKickBallDistance)
				return true;
			return false;
		}

        /// <summary>
        /// 是否进入了守门员的区域;
        /// </summary>
        /// <param name="ballLocation"></param>
        /// <returns></returns>
		public static bool CanGoalKeeper(Vector3 ballLocation)
		{
			if (Mathf.Abs(ballLocation.x) > Mathf.Abs((Define.Length/2)*(3/4f)))
			{
				return true;  
			} 
			return false;
		}
        /// <summary>
        /// 防守阵营的能否踢球策略;
        /// </summary>
        /// <param name="agentLocation"></param>
        /// <param name="ballLocation"></param>
        /// <returns></returns>
		public static bool CanKickDefence(Vector3 agentLocation,Vector3 ballLocation)
		{ 
			return CanSeeBall(agentLocation,ballLocation);	
		}
	}
}

