using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class IsLeader : Conditional
	{ 
		private Agent agent;
		private bool bLeft;
		private Agent leader;

		public override void OnStart ()
		{
			agent = GetComponent<Agent> ();
			bLeft = agent.GetTeamDirection ();
		}

		public override TaskStatus OnUpdate()
		{
			leader = GameManager.Instance.GetLeader (bLeft);
			if(leader.GetNumber()==agent.GetNumber())
			{ 
				return TaskStatus.Success;  
			} else {
				return TaskStatus.Failure;  

			}
		}


	}
}    
