using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{


    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout = Resources.Load("GUI_Skin") as GUISkin;

    GameObject ball;


    // Use this for initialization
    void Start () {     
    }
	
	// Update is called once per frame
	void Update () {

        ball = GameObject.FindGameObjectWithTag("Ball");   
    }

    public static void Score(string wallID)
    {
        if (wallID == "RightGoal")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
        }
    }


    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 50, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 50, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }





}
