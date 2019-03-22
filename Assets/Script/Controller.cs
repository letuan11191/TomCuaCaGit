using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static string DiceName { get; set; }
    public static string ChooseDice { get; set; }
    public static int Score { get; set; }
    public GameObject cv;
    public Text ScoreTxt;
    public Text UserName;


    // Use this for initialization
    void Start()
    {
        Score = 100;
        cv.SetActive(false);
        Time.timeScale = 0;
        UserName.text = "User Name: " + Connection.username;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(DiceName);
        if (ChooseDice == null)
        {
            Time.timeScale = 0;
        }
        else
        {
            if (DiceName != null)
            {
                //cv.SetActive(true);
                cv.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(DiceName);
                Time.timeScale = 0;
                if (DiceName == ChooseDice)
                {
                    Score += 10;
                }
                else
                {
                    Score -= 10;
                }
            }
            
        }
        ScoreTxt.text = Score.ToString();

    }
}
