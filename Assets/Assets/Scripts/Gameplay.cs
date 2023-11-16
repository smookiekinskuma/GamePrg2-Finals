using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public Player player;
    public Acts acts;

    //UI
    public GameObject gameplayFolder;
    public TextMeshProUGUI HealthText, BulletText, LesThoughts;

    //Tutorial
    public int TutorialNo;
    public GameObject Detection, tutorialText;
    public string LesThoughts_Update;
    public float timer;
    public Vector3 SlideUp, SlideDown;

    //Cultists
    public GameObject CBatch1, CBatch2, CBatch3, CBatch4, CBatch5, CBatch6, CBatch7,
        CBatch8, CBatch9, CBatch10, CBatch11, CBatch12, CBatch13, CBatch14;


    // Start is called before the first frame update
    void Start()
    {
        TutorialNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = player.Health.ToString();
        BulletText.text = player.BulletCap.ToString();
        LesThoughts.text = LesThoughts_Update;

        Tutorial();
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
                Detection.SetActive(false);
                CBatch1.SetActive(true);
                break;
            case 5:
                LesThoughts_Update = "They all died simutaneously?! (They're all connected. Killing one will kill everyone in the room)";
                break;
            case 6:
                LesThoughts_Update = "Hell's about to begin... (One hit one heart down. You only have 10 hearts)";
                break;
            case 7:

                break;
        }
    }
}
