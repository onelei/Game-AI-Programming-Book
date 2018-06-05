using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class PassBallToNearstGoal : Action
	{ 
		private Agent mAgent;
		private Ball Ball;

		private bool bLeft;
		private Agent nearstGoalAgent;
		private Vector3 agentPosition;
		private Vector3 ballLocation;

		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
			Ball = mAgent.GetBall().GetComponent<Ball> ();
			bLeft = mAgent.GetTeamDirection ();
		}

		public override TaskStatus OnUpdate()
		{
			nearstGoalAgent = GameManager.Instance.GetNearstGoalAgent (bLeft);
			if (nearstGoalAgent.GetNumber () == mAgent.GetNumber ()) {
				return TaskStatus.Failure;
			} else {
				agentPosition = mAgent.transform.position;
				if (Condition.CanKickBall(agentPosition, ballLocation)) {
					mAgent.transform.LookAt (ballLocation);
					Ball.AddForce (ballLocation,nearstGoalAgent.transform.position); 
					return TaskStatus.Success;  
				} 				
				return TaskStatus.Failure;

			}

		}


	}
}   
