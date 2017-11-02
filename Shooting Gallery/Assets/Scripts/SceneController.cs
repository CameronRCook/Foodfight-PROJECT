using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
		
	//Lodas the menu scene upon call 
	//Where the player chooses the stage and difficulty
	public void loadMenuScene() {
		SceneManager.LoadScene(1);
	}

	//Loads the game 1 scene upon call (Cafertia
	public void loadGame1Scene() {
		SceneManager.LoadScene (2);
	}

	//Loads the game 2 scene upon call (Classroom)
	public void loadGame2Scene() {
		SceneManager.LoadScene (3);
	}

	//Loads the game 3 scene upon call (Halway)
	public void loadGame3Scene() {
		SceneManager.LoadScene (4);
	}

	//Loads the exit scene upon call
	public void loadExitScene() {
		SceneManager.LoadScene (5);
	}

	public void loadMainMenuScene() { 
		SceneManager.LoadScene (0);
	}

	public void loadCredits() {
		SceneManager.LoadScene (6);
	}
}
