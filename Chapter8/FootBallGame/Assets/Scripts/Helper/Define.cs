using UnityEngine;
using System.Collections.Generic;

namespace FootBallGame
{
	public class Define
	{
		public static int Length = 78;//80;
		public static int Width = 18;//20;
		public static int PLAYER_NUM = 11;//3
		public static int FORCE = 10;
		public static int BIG_FORCE = 2;
		public static Vector3 KickForceLeft = new Vector3 (10,0 , 0);
		public static Vector3 KickForceRight = new Vector3 (-KickForceLeft.x, KickForceLeft.y, KickForceLeft.z);
		public static Vector3 KickForceLeftBig = new Vector3 (15, 0, 0);
		public static Vector3 KickForceRightBig = new Vector3 (-KickForceLeftBig.x, KickForceLeftBig.y, KickForceLeftBig.z);
		public static float Patrol_Circle = Width/8f;
		public static float See_Circle = 6f;
		public static float GoalBallX = Length / 2f;
		public static float GoalBallZ = Width / 2f;
		public static Vector3 LeftDoorPosition = new Vector3(-Length/2f,0,0);
		public static Vector3 RightDoorPosition = new Vector3(Length/2f,0,0);

		public static float CanKickBallDistance = 1f;

		public static int GoalKeeperNumber = 1;
		public static int AttackNumber = 5;
		public static int DefenceNumber = 5;

		public static string PlayerLeftSource = "Model/Agent_L";
		public static string PlayerRightSource = "Model/Agent_R"; 

		public static List<Vector3> PlayerLocationRight = new List<Vector3> () {
			new Vector3((Length/2),0,0),
			new Vector3((Length/2)*(1/8f),0,0),
			new Vector3((Length/2)*(1/4f),0,0),
			new Vector3((Length/2)*(1/4f),0,(Width/2)*(1/2f)),
			new Vector3((Length/2)*(1/4f),0,-(Width/2)*(1/2f)),
			new Vector3((Length/2)*(1/2f),0,0),
			new Vector3((Length/2)*(1/2f),0,(Width/2)*(1/2f)),
			new Vector3((Length/2)*(1/2f),0,-(Width/2)*(1/2f)),
			new Vector3((Length/2)*(3/4f),0,0),
			new Vector3((Length/2)*(3/4f),0,(Width/2)*(3/4f)),
			new Vector3((Length/2)*(3/4f),0,-(Width/2)*(3/4f)),
		};

		public static List<Vector3> PlayerLocationLeft = new List<Vector3> (){
			new Vector3(-(Length/2),0,0),
			new Vector3(-(Length/2)*(1/8f),0,0),
			new Vector3(-(Length/2)*(1/4f),0,0),
			new Vector3(-(Length/2)*(1/4f),0,(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(1/4f),0,-(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(1/2f),0,0),
			new Vector3(-(Length/2)*(1/2f),0,(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(1/2f),0,-(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(3/4f),0,0),
			new Vector3(-(Length/2)*(3/4f),0,(Width/2)*(3/4f)),
			new Vector3(-(Length/2)*(3/4f),0,-(Width/2)*(3/4f)),
		};

		public static List<Vector3> PlayerPatrolLocationRight = new List<Vector3> () {
			new Vector3((Length/2),0,0),
			new Vector3(-(Length/2)*(3/4f),0,Width*(1/4f)),
			new Vector3(-(Length/2)*(3/4f),0,-Width*(1/4f)),
			new Vector3(-(Length/2)*(1/2f),0,0),
			new Vector3(-(Length/2)*(1/4f),0,(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(1/4f),0,-(Width/2)*(1/2f)),
			new Vector3((Length/2)*(1/4f),0,0),
			new Vector3((Length/2)*(1/2f),0,(Width/2)*(1/2f)),
			new Vector3((Length/2)*(1/2f),0,-(Width/2)*(1/2f)),
			new Vector3((Length/2)*(3/4f),0,(Width/2)*(3/4f)),
			new Vector3((Length/2)*(3/4f),0,-(Width/2)*(3/4f)),
		};

		public static List<Vector3> PlayerPatrolLocationLeft = new List<Vector3> (){
			new Vector3(-(Length/2),0,0),
			new Vector3((Length/2)*(3/4f),0,Width*(1/4f)),
			new Vector3((Length/2)*(3/4f),0,-Width*(1/4f)),
			new Vector3((Length/2)*(1/2f),0,0),
			new Vector3((Length/2)*(1/4f),0,(Width/2)*(1/2f)),
			new Vector3((Length/2)*(1/4f),0,-(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(1/4f),0,0),
			new Vector3(-(Length/2)*(1/2f),0,(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(1/2f),0,-(Width/2)*(1/2f)),
			new Vector3(-(Length/2)*(3/4f),0,(Width/2)*(3/4f)),
			new Vector3(-(Length/2)*(3/4f),0,-(Width/2)*(3/4f)),
		};
	}
}

