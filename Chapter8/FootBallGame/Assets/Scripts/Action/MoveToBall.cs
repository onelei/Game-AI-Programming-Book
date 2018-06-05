using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class MoveToBall : Action
	{
		/// <summary>
		/// The m agent.
		/// </summary>
		private Agent mAgent;

		private Vector3 ballLocation;
		private Transform Ball;

		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
		}

		public override TaskStatus OnUpdate()
		{
			ballLocation = mAgent.GetBallLocation ();
			mAgent.SetDestination (ballLocation);
			return TaskStatus.Success;  
		}

		 
	}
}
 

