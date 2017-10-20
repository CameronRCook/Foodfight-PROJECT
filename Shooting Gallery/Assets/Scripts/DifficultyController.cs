using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour {

	public void setEasy()
	{
		TargetBehavior.moveSpeed = 1.0f;
		GameController.minTargets = 1;
		GameController.maxTargets = 4;
		GameController.waitSeconds = 1.5f;
	}

	public void setNormal()
	{
		TargetBehavior.moveSpeed = 1.5f;
		GameController.minTargets = 2;
		GameController.maxTargets = 5;
		GameController.waitSeconds = 1.0f;
	}

	public void setHard()
	{
		TargetBehavior.moveSpeed = 2.0f;
		GameController.minTargets = 3;
		GameController.maxTargets = 5;
		GameController.waitSeconds = 0.75f;
	}
}
