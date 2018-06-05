/// <summary>
/// Look at ball.
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class LookAtBall : Action
	{ 
		private Agent mAgent;

		private Vector3 ballLocation;

		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
		}

		public override TaskStatus OnUpdate()
		{
			ballLocation = mAgent.GetBallLocation ();
			mAgent.transform.LookAt (ballLocation); 
			return TaskStatus.Running;    
		}


	}
}  
