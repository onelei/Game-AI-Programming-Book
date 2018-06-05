using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

namespace FootBallGame
{
	public class MoveToPatrolPosition : Action
	{
		/// <summary>
		/// The m agent.
		/// </summary>
		private Agent mAgent;
		private NavMeshAgent navMeshAgent;
		/// <summary>
		/// The init position.
		/// </summary>
		private Vector3 InitPos;
		/// <summary>
		/// The patrol position.
		/// </summary>
		private Vector3 PatrolPos; 
		public override void OnStart ()
		{
			mAgent = GetComponent<Agent> ();
			InitPos = mAgent.transform.position; 

			bool bleft = mAgent.GetTeamDirection ();
			if (bleft) {
				PatrolPos = Define.PlayerPatrolLocationLeft [mAgent.GetNumber () - 1]; 
			} else {
				PatrolPos = Define.PlayerPatrolLocationRight [mAgent.GetNumber () - 1];  
			}
			navMeshAgent = mAgent.GetNavAgent ();

 
			navMeshAgent.enabled = true;
			mAgent.SetDestination(PatrolPos);

		} 

		// Patrol around the different waypoints specified in the waypoint array. Always return a task status of running. 
		public override TaskStatus OnUpdate()
		{
			if (!navMeshAgent.pathPending) {
				var thisPosition = transform.position;
				thisPosition.y = navMeshAgent.destination.y; // ignore y
				if (Vector3.SqrMagnitude (thisPosition - navMeshAgent.destination) < 1f) {
					return TaskStatus.Success;
				}
			} else {
				mAgent.SetDestination (PatrolPos);
			}
			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			// Disable the nav mesh
			navMeshAgent.enabled = false;
		}
 
	}
} 