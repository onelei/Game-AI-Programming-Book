using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGame : MonoBehaviour {
	[SerializeField] Transform BallTramsform;
	[SerializeField] GameObject GoalLeft;
	[SerializeField] GameObject GoalRight;
	// Use this for initialization
	void Start () {
		GoalLeft.SetActive (false);
		GoalRight.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		// Record Ball Postion;
		if(BallTramsform.position.x>=38)
		{
			GoalBall (true);
		}
		else if(BallTramsform.position.x<=-38)
		{
			GoalBall(false); 
		}
	}

	void GoalBall(bool bGoalLeft)
	{
		GoalLeft.SetActive (bGoalLeft);
		GoalRight.SetActive (!bGoalLeft);
		Time.timeScale = 0f; 
	}
}
