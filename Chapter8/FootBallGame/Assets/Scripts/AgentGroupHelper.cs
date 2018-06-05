using UnityEngine;
using BehaviorDesigner.Runtime;
using System.Collections.Generic;
using UnityEngine.UI;

namespace FootBallGame
{ 
	public class AgentGroupHelper : MonoBehaviour
	{ 
		public static AgentGroupHelper Instance;

       	[SerializeField] Ball mBall; 
		[SerializeField] List<Agent> mAgentTeamsLeft = new List<Agent>();
		[SerializeField] List<Agent> mAgentTeamsRight = new List<Agent>();

		void Awake()
		{
			Instance = this;
		}

		public bool IsNearstAgent(Agent agent,Vector3 targetPosition)
		{
 			Agent nearstAgent = agent;
			float nearstDistance = float.MaxValue;
			for (int i = 0; i < mAgentTeamsLeft.Count; i++) {
				float distanceAgentToTargetPosition = Vector3.Distance (mAgentTeamsLeft [i].transform.position, targetPosition);
				if (distanceAgentToTargetPosition < nearstDistance) {
					{
						nearstDistance = distanceAgentToTargetPosition;
						nearstAgent = mAgentTeamsLeft [i];
					}
				}
			}
			return nearstAgent.GetNumber () == agent.GetNumber ();
		} 

		public List<Agent> GetAgentTeam(bool bLeft)
		{
			if(bLeft)
			{
				return mAgentTeamsLeft;
			}
			return mAgentTeamsRight;
		}
        /// <summary>
        /// 获取自己在攻击阵营里面的位置;
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="targetPosition"></param>
        /// <param name="bLeft"></param>
        /// <returns></returns>
		public Vector3 GetAttackGroupLocation(Agent agent,Vector3 targetPosition,bool bLeft)
		{
            //根据自己的阵营获取球员列表;
			List<Agent> team = GetAgentTeam (bLeft);
			Agent nearstAgent = agent;
			//将球员和目标点的距离进行排序,离目标点最近的排在最前面; 
			team.Sort ((a,b)=>{
				return Vector3.Distance (a.transform.position, targetPosition).CompareTo(Vector3.Distance (b.transform.position,targetPosition));
			}); 
            //获取自己在排序后的索引值;
			var index = team.FindIndex (a=>a.GetNumber()==agent.GetNumber());
			// 索引值为0,就是离目标点最近的球员;
			if (index == 0) {
 				return targetPosition; 
			} 
			else 
			{ 
                // 获取离目标点最近的球员的位置;
				var nearstBallAgentLocation = team [0].transform.position;
                //如果自己是偶数就让自己在离目标点最近的球员的后面,球场的下面;
				if((index%2)==0)
				{
					return new Vector3(nearstBallAgentLocation.x-3*index,0,nearstBallAgentLocation.z-index*3); 
				}
                //如果自己是奇数就让自己在离目标点最近的球员的后面,球场的上面;
				return new Vector3(nearstBallAgentLocation.x-3*index,0,nearstBallAgentLocation.z+index*3);
			}
		} 
	}
}

