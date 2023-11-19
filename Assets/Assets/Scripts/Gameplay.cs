using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;

public class Gameplay : MonoBehaviour
{
    [Header("Scripts")]//Scripts
    public Player player;
    public CultHeart cultheart; 
    public Acts acts;

    [Header("Player Persepctive")]//UI 
    public GameObject Les;
    public GameObject Camera;
    public GameObject mainmenuFolder, gameplayFolder, gameoverFolder;
    public TextMeshProUGUI HealthText, BulletText, HealthStatus, BulletStatus, LesThoughts, Act;
    public string HealthStatus_Update, BulletStatus_Update, LesThoughts_Update, Act_Update;
    public Image GameOverBlack, BlackShadow, Black, RedShadow;
    public GameObject GameOverBlackGO, BlackGO;
    public float FadeTimer;

    [Header("Story Progression")]
    public bool Battle;
    public bool GameStart;

    [Header("Tutorial")]//Tutorials
    public GameObject TooLong;
    public GameObject OneLastTutorial;
    public int TutorialNo;

    [Header("Map Teleportation")]//Detections for Maps
    public GameObject ToLibrary;
    public GameObject ToClassroom;
    public GameObject ToChapel;
    public GameObject ToBasement;
    public GameObject TheEnd;

    // Start is called before the first frame update
    void Start()
    {
        //Main Menu First
        Black.DOFade(0f, 0f);
        BlackGO.SetActive(false);

        Act_Update = "";
        Battle = false;
        GameStart = false;

        gameplayFolder.SetActive(false);
        gameoverFolder.SetActive(false);

        //Detections
        ToClassroom.SetActive(false);
        ToChapel.SetActive(false);
        ToBasement.SetActive(false);
        TheEnd.SetActive(false);

        //Animation
        RedShadow.DOFade(0f, 0f);
        BlackShadow.DOFade(0f, 0f);

        //GameOver
        GameOverBlack.DOFade(1f, 0f);
        GameOverBlackGO.SetActive(true);

        TutorialNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle == false)
        {
            Les.SetActive(false);
        } else { Les.SetActive(true); }

        HealthText.text = player.Health.ToString();
        BulletText.text = player.BulletCap.ToString();
        HealthStatus.text = HealthStatus_Update;
        BulletStatus.text = BulletStatus_Update;
        LesThoughts.text = LesThoughts_Update;
        Act.text = Act_Update;

        switch (acts.ChapterProgression)
        {
            case 1:
                GameStart = true; acts.Intro_(); break;
            case 2:
                acts.Act1(); break;
            case 3:
                acts.Act2(); break;
            case 4:
                acts.Act3(); break;
            case 5:
                acts.End(); break;
        }

        cultheart.CultEvent();
        Tutorial();
    }

    //MainMenu
    public void StartGame()
    {
        BlackGO.SetActive(true);
        Sequence StartGame = DOTween.Sequence();
        StartGame.Append(Black.DOFade(1f, 1f)).SetDelay(0.25f).onComplete = DisableMainMenu;
    }
    public void DisableMainMenu()
    {
        mainmenuFolder.SetActive(false);
        Sequence StartGame2 = DOTween.Sequence();
        StartGame2.Append(Black.DOFade(0f, 1f)).SetDelay(0.25f).onComplete = StoryProgression; 
    }
    public void StoryProgression() //Chapter Progression
    {
        BlackGO.SetActive(false);
        acts.ChapterProgression++;
    }

    //Tutorial
    void Tutorial() //Or thoughst
    {
        LesThoughts_Update = "Something is off, I need to look around... (Use WASD to move)";
        switch (TutorialNo)
        {
            case 1:
                LesThoughts_Update = "This hallway wasn't this long... (Hold shift to run)"; break;
            case 2:
                LesThoughts_Update = "Why are there scattered bullets? They're unused... (Go near the bullets to reload)"; break;
            case 3:
                LesThoughts_Update = "I can't carry the rest for now... (You only carry a maximum of 5 bullets)"; break;
            case 4:
                LesThoughts_Update = "They're they are! ('K' to shoot the cultists)";
                cultheart.Batch_1.SetActive(true); break;
            case 5:
                LesThoughts_Update = "They all died simutaneously?! (They're all connected. Killing one will kill everyone in the room)"; break;
            case 6:
                LesThoughts_Update = "Hell's about to begin... (One hit one heart down. You only have 10 hearts)";
                player.Health = 10; break;
            case 7:
                LesThoughts_Update = "I hope everyone is safe..."; break;
            case 8:
                LesThoughts_Update = "The cultists are here!"; break;
            case 9:
                LesThoughts_Update = "The door up there is unlocked. I should go there"; break;
            case 10:
                LesThoughts_Update = "This orphanage is falling apart..."; break;
            case 11:
                LesThoughts_Update = "Almost there..."; break;
            case 12:
                LesThoughts_Update = "Is this finally the end?"; break;
        }
    }

    //Transitioning to another map
    public void Library() //Hallway to Library
    {
        Sequence Fade = DOTween.Sequence();
        Fade.Append(BlackShadow.DOFade(1f, 0.25f));
        Fade.Append(Les.transform.DOMove(new Vector2(-253.98f, -13.2f), 0f)).SetDelay(0.25f);
        Fade.Append(BlackShadow.DOFade(0f, 0.25f));
    }

    public void Chapel() //Classroom to Chapel
    {
        Sequence Fade = DOTween.Sequence();
        Fade.Append(BlackShadow.DOFade(1f, 0.25f));
        Fade.Append(Les.transform.DOMove(new Vector2(-286.91f, -37.23f), 0f)).SetDelay(0.25f);
        Fade.Append(BlackShadow.DOFade(0f, 0.25f));
    }

    //Restarting an ACT
    //Well... there was SUPPOSED to be one...

    //Exit
    public void Exit()
    {
        BlackGO.SetActive(true);
        Sequence StartGame = DOTween.Sequence();
        StartGame.Append(Black.DOFade(1f, 2f)).SetDelay(0.25f).onComplete = ActuallyLeave;
    }
    public void ActuallyLeave() //Like, leave leave
    {
        Application.Quit();
    }
}
