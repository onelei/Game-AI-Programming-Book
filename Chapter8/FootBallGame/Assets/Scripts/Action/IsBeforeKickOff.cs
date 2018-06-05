using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallGame
{
	public class IsBeforeKickOff : Conditional
	{ 
 		private bool bBeforeKickOff;

		public override void OnStart ()
		{
			bBeforeKickOff = false;
		}

		public override TaskStatus OnUpdate()
		{
			bBeforeKickOff = GameManager.Instance.BeforeKickOff;
			if (bBeforeKickOff) {
				return TaskStatus.Success;  
			} else {
				return TaskStatus.Failure;  
			}
		}


	}
}    