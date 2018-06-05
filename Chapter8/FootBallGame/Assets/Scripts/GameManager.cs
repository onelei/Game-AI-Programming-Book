using UnityEngine;
using BehaviorDesigner.Runtime;
using System.Collections.Generic;
using UnityEngine.UI;

namespace FootBallGame
{
	public enum GameState
	{
		Init,
		Game,
		GameOver
	}
	public class GameManager : MonoBehaviour
	{ 
		public static GameManager Instance;

		[SerializeField] Camera m_Camera;
		[SerializeField] GameObject Go_Init;
		[SerializeField] GameObject Go_Game;
		[SerializeField] GameObject Go_GameOver;
		[SerializeField] Text Text_GoalLeft;
		[SerializeField] Text Text_GoalRight;
		[SerializeField] GameObject Go_WinLeft;
		[SerializeField] GameObject Go_WinRight;
		[SerializeField] Ball mBall;
		[SerializeField] Button Button_ReStart;
		[SerializeField] Button Button_Start;

		[SerializeField] Transform Trans_Player;

		private List<Agent> mAgentTeamsLeft = new List<Agent>();
		private List<Agent> mAgentTeamsRight= new List<Agent>(); 
		private List<BehaviorTree> LeftTreeList = new List<BehaviorTree>();
		private List<BehaviorTree> RightTreeList = new List<BehaviorTree>();
		private List<BehaviorTree> BeforeKickOffTrees = new List<BehaviorTree> ();
		private int TreeCount;
		private GameState mGameState;

		private float goalBallPosX = Define.GoalBallX;

		private int leftGoalNumber;
		private int RightGoalNumber;
		private bool bGoalLeft;

		void Awake()
		{
			Instance = this;

			Button_ReStart.onClick.AddListener (delegate {
				GameReStart();
			});

			Button_Start.onClick.AddListener (delegate {
				GameReStart();
			});
		}

		[ContextMenu("Start")]
		void Start() 
		{ 
			for (int i = 0; i < Define.PLAYER_NUM; i++) {
				Agent agent =  ResourceManager.Load<Agent>(Define.PlayerLeftSource);
				if (agent != null) {
					agent.transform.parent = Trans_Player;
					agent.transform.position = Define.PlayerLocationLeft [i];//PlayerLocationLeft;;//PlayerPatrolLocationLeft;;
					int number = i + 1;
					//agent.SetData (true,number,mBall.transform); 
					mAgentTeamsLeft.Add (agent);
					BehaviorTree[] trees = agent.GetComponentsInChildren<BehaviorTree> ();
					for (int j = 0; j < trees.Length; j++) 				
					{
						if(trees[j].Group!=0)
						LeftTreeList.Add(trees[j]);
					}
				}
			}

			for (int i = 0; i < Define.PLAYER_NUM; i++) {
				Agent agent =  ResourceManager.Load<Agent>(Define.PlayerRightSource);
				if(agent!=null)
				{
					agent.transform.parent =  Trans_Player;
					agent.transform.position = Define.PlayerLocationRight [i];//PlayerLocationRight;;//PlayerPatrolLocationRight;;
					int number = i + 1; 
					//agent.SetData (false,number,mBall.transform); 
					mAgentTeamsRight.Add (agent);
					BehaviorTree[] trees = agent.GetComponentsInChildren<BehaviorTree> ();
					for (int j = 0; j < trees.Length; j++) {
						if(trees[j].Group!=0)
						RightTreeList.Add(trees[j]);
					}
 				} 
			}

			BehaviorTree[] btTrees = transform.GetComponentsInChildren<BehaviorTree> (true);
			for (int j = 0; j < btTrees.Length; j++) {
				if (btTrees [j].Group == 0) {
					BeforeKickOffTrees.Add (btTrees [j]); 
				}
			}

			TreeCount = LeftTreeList.Count; 

			GameInit();
		}

		// kick off function;
		float BeforeKickOffTime;
		float BEFORE_KICKOFF_TIME = 6f;
		float KICK_OFF_TIME = 2f;
		float kickOffTime;
		bool bKickOff = false;
		bool bBeforeKickOff = false;
		public bool BeforeKickOff
		{
			get{return bBeforeKickOff;}
		}
		void Update()
		{  
			// who kick ball first;
			if(mGameState == GameState.Game)
			{
				if (bBeforeKickOff) {
					BeforeKickOffTime += Time.deltaTime;
					if(BeforeKickOffTime>BEFORE_KICKOFF_TIME)
					{
						BeforeKickOffTime = 0;
						bKickOff = true;
						bBeforeKickOff = false;
						// start kick strategy;
						EnableBeforeKickOffTreeList(false);  
						mBall.ReStart();
						EnableTreeList (!bGoalLeft,bGoalLeft);
					}
				}

				if (bKickOff) {

					kickOffTime += Time.deltaTime;
					if(kickOffTime>KICK_OFF_TIME)
					{
						kickOffTime = 0;
						bKickOff = false;
						Debug.Log ("kick off time over;");
						EnableTreeList (true,true);  
					}
				}
			}
				
			// Record Ball Postion;
			if(mGameState!=GameState.GameOver&&mBall.transform.position.x>=goalBallPosX)
			{
				SetState (GameState.GameOver);
				GameOver (true);
			}
			else if(mGameState!=GameState.GameOver&&mBall.transform.position.x<=-goalBallPosX)
			{
				SetState (GameState.GameOver);
				GameOver(false); 
			}

 		}

		/// <summary>
		/// Sets the state.
		/// </summary>
		/// <param name="gameState">Game state.</param>
		public void SetState(GameState gameState)
		{
			this.mGameState = gameState;

			Go_Init.SetActive (gameState == GameState.Init);
			Go_Game.SetActive (gameState == GameState.Game);
			Go_GameOver.SetActive(gameState == GameState.GameOver);  
		}

		void GameInit()
		{
			Time.timeScale = 0;

			EnableTreeList (false,false); 
			SetState (GameState.Init);

			bGoalLeft = false;
		}

		void GameOver(bool bGoalLeft)
		{
			SetState (GameState.GameOver);
			Go_WinLeft.SetActive (bGoalLeft);
			Go_WinRight.SetActive (!bGoalLeft); 

			Time.timeScale = 0;
 
			EnableTreeList (false,false);
		
			this.bGoalLeft = bGoalLeft;

			if(bGoalLeft)
			{
				leftGoalNumber++;
			}else
			{
				RightGoalNumber++;
			}
				
			Text_GoalLeft.text = leftGoalNumber.ToString ();
			Text_GoalRight.text = RightGoalNumber.ToString ();
		}

		void GameReStart()
		{
			SetState(GameState.Game); 

			for (int i = 0; i < mAgentTeamsLeft.Count; i++) {
				//mAgentTeamsLeft [i].ReStart ();
			}

			for (int i = 0; i < mAgentTeamsRight.Count; i++) {
				//mAgentTeamsRight [i].ReStart ();
			}
				
			Time.timeScale = 1; 
			// goal left, then right kick;
			//EnableTreeList (!bGoalLeft,bGoalLeft);
			//BeforeKickOffTrees
			EnableBeforeKickOffTreeList(true); 
			mBall.BeforeKickOff ();
			bBeforeKickOff = true;
			Debug.Log ("kick off start! bGoalLeft "+ bGoalLeft);

		}

		void EnableTreeList(bool leftEnable,bool rightEnable)
		{
			for (int i = 0; i < TreeCount; i++) {
				if (leftEnable) {
					if (!BehaviorManager.instance.IsBehaviorEnabled (LeftTreeList [i])) {
						LeftTreeList [i].EnableBehavior (); 
					}
				} else {
					if (BehaviorManager.instance.IsBehaviorEnabled (LeftTreeList [i])) {
						LeftTreeList [i].DisableBehavior (); 
					}
				}

				if (rightEnable) {
					if (!BehaviorManager.instance.IsBehaviorEnabled (RightTreeList [i])) {
						RightTreeList [i].EnableBehavior (); 
					}
				} else {
					if (BehaviorManager.instance.IsBehaviorEnabled (RightTreeList [i])) {
						RightTreeList [i].DisableBehavior (); 
					}
				} 
			}
		}
		void EnableBeforeKickOffTreeList(bool _enable)
		{
			for (int i = 0; i < BeforeKickOffTrees.Count; i++)
			{
				BeforeKickOffTrees [i].enabled = _enable; 
			}
		}

		public List<Agent> GetAgentList(bool bLeft)
		{
 			if (bLeft) { 
				return mAgentTeamsLeft; 
			} else { 
				return mAgentTeamsRight; 
			}
		}

		public Agent GetLeader(bool bLeft)
		{
			List<Agent> agentTeam = GetAgentList (bLeft);
			Agent leader = agentTeam[0]; 
			float nearstDistance = float.MaxValue;
			for (int i = 0; i < agentTeam.Count; i++) {
				float distanceAgentToTargetPosition = Vector3.Distance (agentTeam [i].transform.position, mBall.transform.position);
				if (distanceAgentToTargetPosition < nearstDistance) {
					{
						nearstDistance = distanceAgentToTargetPosition;
						leader = agentTeam [i];
					}
				}
			}
			return leader;
		}

		#region 通用函数
		private Vector3 LeftDoorPosition = new Vector3(-Define.Length/2,0,0);
		private Vector3 RightDoorPosition = new Vector3(Define.Length/2,0,0);

		public Agent GetNearstGoalAgent(bool left)
		{
			if (left) {
				return GetNearstTargetAgent (mAgentTeamsLeft, LeftDoorPosition);
			} else {
				return GetNearstTargetAgent (mAgentTeamsRight, RightDoorPosition); 
			}
		}
 
		public Agent GetNearstTargetAgent(List<Agent> agentTeam,Vector3 targetPosition)
		{
			Agent result = agentTeam[0]; 
			float nearstDistance = float.MaxValue;
			for (int i = 0; i < agentTeam.Count; i++) {
				float distanceAgentToTargetPosition = Vector3.Distance (agentTeam [i].transform.position, targetPosition);
				if (distanceAgentToTargetPosition < nearstDistance) {
					{
						nearstDistance = distanceAgentToTargetPosition;
						result = agentTeam [i];
					}
				}
			}
			return result;
		}
		#endregion
	}
}

