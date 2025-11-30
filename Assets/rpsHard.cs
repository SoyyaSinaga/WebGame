using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class rpsHard : MonoBehaviour
{
    public TextMeshProUGUI Result, Timer, ActionRes, Nyawa, NyawaLawan;
    public Image OppChoice, OwnChoice, OwnAction, OppAction;
    public string[] Choices;
    public Sprite Rock, Paper, Scissors, attack, guard;
    public GameObject hands, Actions, next, losescreen, winscreen;

    public static int jmlnyawas = 1;
    public static int jmlnyawao = 5;

    private bool canDefend = true;
    private bool canAttack = true;

    public int Life;

    void Start()
    {
        Timer.gameObject.SetActive(false);
        Actions.gameObject.SetActive(false);
        hands.gameObject.SetActive(true);
        ActionRes.gameObject.SetActive(false);
        next.SetActive(false);
        OppChoice.sprite = null;
        OwnChoice.sprite = null;
        losescreen.gameObject.SetActive(false);
        winscreen.gameObject.SetActive(false);
        
    }

    void Update()
    {
        Nyawa.text = "Life: " + jmlnyawas;
        NyawaLawan.text = "Life: " + jmlnyawao;
        if (jmlnyawas <= 0)
        {
            losescreen.gameObject.SetActive(true);
        }
        if (jmlnyawao <= 0)
        {
            winscreen.gameObject.SetActive(true);
        }
    }

    public void RPS(string myChoice)
    {
        
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        switch (randomChoice)
        {
            case "Rock":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "Tie!";
                        OwnChoice.sprite = Rock;
                        break;

                    case "Paper":
                        Result.text = "W";
                        OwnChoice.sprite = Paper;
                        break;

                    case "Scissors":
                        Result.text = "L";
                        OwnChoice.sprite = Scissors;
                        break;
                }
                OppChoice.sprite = Rock;
                break;

            case "Paper":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "L";
                        OwnChoice.sprite = Rock;
                        break;

                    case "Paper":
                        Result.text = "Tie!";
                        OwnChoice.sprite = Paper;
                        break;

                    case "Scissors":
                        Result.text = "W";
                        OwnChoice.sprite = Scissors;
                        break;
                }
                OppChoice.sprite = Paper;
                break;

            case "Scissors":
                switch (myChoice)
                {
                    case "Rock":
                        Result.text = "W";
                        break;

                    case "Paper":
                        Result.text = "L";
                        break;

                    case "Scissors":
                        Result.text = "Tie!";
                        break;
                }
                OppChoice.sprite = Scissors;
                break;
        }

        if (Result.text != "Tie!")
        {
            Result.gameObject.SetActive(false);
            AttackPrep();
        }
        else
        {
            next.gameObject.SetActive(false);
        }
    }

    public void AttackPrep()
    {
        hands.gameObject.SetActive(false);
        Actions.gameObject.SetActive(true);
        Timer.gameObject.SetActive(true);

        OwnAction.sprite = null;
        OppAction.sprite = null;

        Timer.GetComponent<timerHard>().TimerResetHard();
    }

    public void AtkPressed()
    {
        if (!canAttack)
            return;

        Timer.gameObject.SetActive(false);
        ActionRes.gameObject.SetActive(true);
        OwnAction.sprite = attack;
        Timer.GetComponent<timerHard>().StopTimer();
        next.gameObject.SetActive(true);

        canDefend = false;

        if (Result.text == "L")
        {
            OppAction.sprite = attack;
            ActionRes.text = "Get Bonked";
            jmlnyawas--;
        }
        else if (Result.text == "W")
        {
            ActionRes.text = "Hit Landed";
            jmlnyawao--;
        }
    }

    public void DefPressed()
    {
        if (!canDefend)
        {
            return;
        }

        Timer.gameObject.SetActive(false);
        ActionRes.gameObject.SetActive(true);
        OwnAction.sprite = guard;
        Timer.GetComponent<timerHard>().StopTimer();
        next.gameObject.SetActive(true);

        canAttack = false;

        if (Result.text == "L")
        {
            OwnAction.sprite = guard;
            OppAction.sprite = attack;
            ActionRes.text = "Blocked";
            jmlnyawas++;
        }
        else if (Result.text == "W")
        {
            OwnAction.sprite = guard;
            OppAction.sprite = guard;
            ActionRes.text = "Miss";
        }
    }

    public void NextRound()
    {
        Result.gameObject.SetActive(true);
        Result.text = "";
        ActionRes.gameObject.SetActive(false);
        OwnAction.sprite = null;
        OppAction.sprite = null;
        hands.gameObject.SetActive(true);
        Actions.gameObject.SetActive(false);
        Timer.gameObject.SetActive(false);
        OppChoice.sprite = null;
        OwnChoice.sprite = null;
        next.SetActive(false);

        canDefend = true;
        canAttack = true;
    }

    public void NoAction()
    {
        ActionRes.gameObject.SetActive(true);
        next.gameObject.SetActive(true);
        if (Result.text == "L")
        {
            OppAction.sprite = attack;
            ActionRes.text = "Get Bonked";
            jmlnyawas--;
        }

        else if (Result.text == "W")
        {
            OppAction.sprite = guard;
            ActionRes.text = "Miss";
        }
    }

    public void balik()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
