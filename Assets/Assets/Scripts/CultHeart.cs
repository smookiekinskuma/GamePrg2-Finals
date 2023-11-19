using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultHeart : MonoBehaviour
{
    [Header("Scripts")]
    public Gameplay gameplay;

    [Header("Cult Detection")]//Detection Triggering Cultists
    public GameObject CultistTutorial;
    public GameObject CultistLibrary;
    public GameObject CultistClassroom;
    public GameObject CultistChapel;
    public GameObject CultistBasement;

    [Header("Cult Batch")]//Cult Events
    public GameObject Batch_1;
    public GameObject Batch_2;
    public GameObject Batch_3;
    public GameObject Batch_4;
    public GameObject Batch_5;
    public GameObject Batch_6;
    public GameObject Batch_7;
    public GameObject Batch_8;
    public GameObject Batch_9;
    public GameObject Batch_10;
    public GameObject Batch_11;
    public GameObject Batch_12;
    public GameObject Batch_13;
    public GameObject Batch_14;
    public int Kill;

    [Header("Cultists")]//Cultists
    public List<GameObject> Batch1 = new();
    public List<GameObject> Batch2 = new();
    public List<GameObject> Batch3 = new();
    public List<GameObject> Batch4 = new();
    public List<GameObject> Batch5 = new();
    public List<GameObject> Batch6 = new();
    public List<GameObject> Batch7 = new();
    public List<GameObject> Batch8 = new();
    public List<GameObject> Batch9 = new();
    public List<GameObject> Batch10 = new();
    public List<GameObject> Batch11 = new();
    public List<GameObject> Batch12 = new();
    public List<GameObject> Batch13 = new();
    public List<GameObject> Batch14 = new();

    public void Start()
    {
        Kill = 0;
    }

    public void CultEvent()
    { 
        switch (Kill)
        {
            case 3:
                if (gameplay.TutorialNo == 4) { gameplay.TutorialNo = 5; }
                Batch_1.SetActive(false);
                break;
            case 7:
                Batch_2.SetActive(false);
                Batch_3.SetActive(true);
                break;
            case 13:
                Batch_3.SetActive(false);
                Batch_4.SetActive(true);
                break;
            case 21:
                Batch_4.SetActive(false);
                gameplay.ToClassroom.SetActive(true);
                gameplay.TutorialNo = 9;
                break;
            case 25:
                Batch_5.SetActive(false);
                Batch_6.SetActive(true);
                break;
            case 31:
                Batch_6.SetActive(false);
                Batch_7.SetActive(true);
                break;
            case 41:
                Batch_7.SetActive(false);
                gameplay.ToChapel.SetActive(true);
                gameplay.TutorialNo = 10;
                break;
            case 45:
                Batch_8.SetActive(false);
                Batch_9.SetActive(true);
                break;
            case 51:
                Batch_9.SetActive(false);
                Batch_10.SetActive(true);
                break;
            case 61:
                Batch_10.SetActive(false);
                gameplay.ToBasement.SetActive(true);
                gameplay.TutorialNo = 11;
                break;
            case 64:
                Batch_11.SetActive(false);
                Batch_12.SetActive(true);
                break;
            case 69:
                Batch_12.SetActive(false);
                Batch_13.SetActive(true);
                break;
            case 79:
                Batch_13.SetActive(false);
                Batch_14.SetActive(true);
                break;
            case 94:
                Batch_14.SetActive(false);
                gameplay.TheEnd.SetActive(true);
                gameplay.TutorialNo = 12;
                break;
        }
    }
}
