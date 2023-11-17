using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.InputSystem;

public class Gameplay : MonoBehaviour
{
    public Player player;
    public Cultist cultist;
    public Acts acts;

    //UI
    public GameObject gameplayFolder;
    public TextMeshProUGUI HealthText, BulletText, LesThoughts;

    //Tutorial
    public int TutorialNo;
    public GameObject Detection, tutorialText;
    public string LesThoughts_Update;

    //Cult Events
    public GameObject Batch_1, Batch_2, Batch_3, Batch_4, Batch_5, Batch_6, Batch_7, Batch_8, Batch_9, Batch_10, Batch_11, Batch_12, Batch_13, Batch_14;
    public int Kill;
    

    // Start is called before the first frame update
    void Start()
    {
        Kill = 0;
        TutorialNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = player.Health.ToString();
        BulletText.text = player.BulletCap.ToString();
        LesThoughts.text = LesThoughts_Update;

        Tutorial();
        CultEvent();
    }

    void Tutorial()
    {
        LesThoughts_Update = "Something is off, I need to look around... (Use WASD to move)";
        switch (TutorialNo)
        {
            case 1:
                LesThoughts_Update = "This hallway wasn't this long... (Hold shift to run)";
                break;
            case 2:
                LesThoughts_Update = "Why are there scattered bullets? They're unused... (Go near the bullets to reload)";
                break;
            case 3:
                LesThoughts_Update = "I can't carry the rest for now... (You only carry a maximum of 5 bullets)";
                break;
            case 4:
                LesThoughts_Update = "They're they are! ('K' to shoot the cultists)";
                Batch_1.SetActive(true);
                break;
            case 5:
                LesThoughts_Update = "They all died simutaneously?! (They're all connected. Killing one will kill everyone in the room)";
                break;
            case 6:
                LesThoughts_Update = "Hell's about to begin... (One hit one heart down. You only have 10 hearts)";
                player.Health = 10;
                break;
            case 7:
                LesThoughts_Update = "I hope we can all get out of here alive...";
                break;
        }
    }

    public void CultEvent()
    {
        switch (Kill)
        {
            case 1:
                if (TutorialNo == 4) { TutorialNo = 5; }
                Batch_1.SetActive(false);
                break;
        }
    }

    public void SavePoints()
    {

    }
}
