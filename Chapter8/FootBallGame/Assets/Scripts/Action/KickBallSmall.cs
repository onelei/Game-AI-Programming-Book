/// <summary>
/// Kick ball.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class KickBallSmall : Action
	{ 
		private Agent mAgent;
		private Ball Ball;

		private Vector3 ballLocation;
		private Vector3 agentLocation;

		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
			Ball = mAgent.GetBall().GetComponent<Ball> ();
		}

		public override TaskStatus OnUpdate()
		{
			ballLocation = mAgent.GetBallLocation ();
			agentLocation = mAgent.transform.position;
			if (Condition.CanKickBall(agentLocation, ballLocation)) {
				mAgent.transform.LookAt (ballLocation);
				bool bLeft = mAgent.GetTeamDirection ();
				if (bLeft) {
					Ball.AddForce (ballLocation,Define.RightDoorPosition);
				} else {
					Ball.AddForce (ballLocation,Define.LeftDoorPosition); 
				}
				return TaskStatus.Success;  
			} else 
			{
				/*
				if (!Condition.CanSeeBall (agentLocation,ballLocation)) {
					return TaskStatus.Failure;
				} else {
					mAgent.MoveToTarget (ballLocation); 
					return TaskStatus.Running;   
				}*/
				mAgent.SetDestination (ballLocation); 
				return TaskStatus.Running;   
			
			}  
		}


	}
}  

