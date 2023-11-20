using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using static Unity.Collections.AllocatorManager;

public class Acts : MonoBehaviour
{
    [Header("Scripts")]//Scripts
    public Gameplay gameplay;

    [Header("UI")]//UI
    public GameObject character; 
    public GameObject shadow;
    public Image black;
    public TextMeshProUGUI CharaName, CharaChat;
    public string CharaName_Update, CharaChat_Update;
    public int SceneProgression;
    public int ChapterProgression;

    [Header("Animation")]//DOTween
    public Vector2 SlideIn;
    public Vector2 SlideOut;
    public Vector2 SlideUp;
    public Vector2 SlideDown;
    public float Timer;

    [Header("Amanda")]//Amanda
    public GameObject Amanda_Anxious;
    public GameObject Amanda_Fear;
    public GameObject Amanda_Mad;
    public GameObject Amanda_Neutral;
    public GameObject Amanda_Smile;

    [Header("Amelie")]//Amelie
    public GameObject Amelie_Anxious;
    public GameObject Amelie_Neutral;
    public GameObject Amelie_Smile;

    [Header("Cassie")]//Cassie
    public GameObject Cassie_Fear;
    public GameObject Cassie_Smile;

    [Header("Emile")]//Emile
    public GameObject Emile_Anxious;
    public GameObject Emile_Fear;
    public GameObject Emile_Neutral;
    public GameObject Emile_Smile;

    [Header("Ivy")]//Ivy
    public GameObject Ivy_Anxious;

    [Header("Dr. Les")]//Les
    public GameObject Les_Angry;
    public GameObject Les_Neutral;
    public GameObject Les_Smile;
    public GameObject Les_Stressed;
    public GameObject Les_Worry;

    [Header("Maria")]//Maria
    public GameObject Maria_Angel;
    public GameObject Maria_Blood;
    public GameObject Maria_Normal;

    [Header("Rosabelle")]//Rosabelle
    public GameObject Rosabelle_Neutral;
    public GameObject Rosabelle_Smile;

    [Header("Simon")]//Simon
    public GameObject Simon_Anxious;
    public GameObject Simon_Fear;
    public GameObject Simon_Neutral;

    [Header("Vincent")]//Vincent
    public GameObject Vincent_Anxious;
    public GameObject Vincent_Neutral;

    [Header("Younger Les")]//YLes
    public GameObject YLes_Crying;
    public GameObject YLes_Neutral;
    public GameObject YLes_Worry;

    [Header("Younger Maria")]//YMaria
    public GameObject YMaria_Neutral;

    [Header("SceneChange")]//Scenes
    public GameObject introRest;
    public GameObject act1Simon; 
    public GameObject act3Maria;
    public GameObject act3Rest;
    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Scene3;
    public GameObject Scene4;

    public void Update()
    {
        CharaName.text = CharaName_Update;
        CharaChat.text = CharaChat_Update;

        if (Input.GetKeyDown(KeyCode.L)) //Progressing the story.
        {
            if (gameplay.Battle == false && gameplay.GameStart == true)
            { SceneProgression++; }
        }
    }

    //Intro
    public void Intro_()
    { 
        switch (SceneProgression)
        {
            case 0: //Intro - Past
                shadow.transform.DOMove(SlideUp, Timer);

                CharaName_Update = "Intro";
                CharaChat_Update = "Press 'L' to progress through the story.";
                break;
            case 1:
                CharaName_Update = "Sister 1";
                CharaChat_Update = "Sister, what are we going to do with the mother?";
                break;
            case 2:
                YMaria_Neutral.SetActive(true);
                character.transform.DOMove(SlideIn, Timer);

                CharaName_Update = "Maria";
                CharaChat_Update = "Allow me...";
                break;
            case 3:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "";
                CharaChat_Update = "...";
                break;
            case 4:
                CharaName_Update = "Victoria";
                CharaChat_Update = "Ollie?! Ollie!!! Oh dear, her neck's cut open!!!";
                break;
            case 5:
                CharaName_Update = "Angelica";
                CharaChat_Update = "Dr. Lynn, we need your help!";
                break;
            case 6:
                CharaName_Update = "Louis";
                CharaChat_Update = "Where are her children?";
                break;
            case 7: 
                Sequence Fade = DOTween.Sequence(); //Going to the next scene
                Fade.Append(black.DOFade(1f, Timer));
                Fade.Append(gameplay.Les.transform.DOMove(new Vector2(-355.43f, -36.20071f), 0f));
                Fade.Append(black.DOFade(0f, Timer));

                CharaName_Update = "Leo";
                CharaChat_Update = "They're not here...";
                break;
            case 8: //Intro - Amanda
                CharaName_Update = "";
                CharaChat_Update = "...";
                break;
            case 9:
                character.transform.DOMove(SlideIn, Timer);

                YMaria_Neutral.SetActive(false);
                Cassie_Fear.SetActive(true);

                CharaName_Update = "Cassie";
                CharaChat_Update = "This is not happening, this is not happening, this is not happening!";
                break;
            case 10:
                Cassie_Fear.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "What do we do now?";
                break;
            case 11:
                Amanda_Anxious.SetActive(false);
                Les_Stressed.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "I'll distract Miss Maria's brothers and sisters. You bring the other orphans to safety. We also need to find help from outside. Simon, take my phone and call Louis.";
                break;
            case 12:
                Les_Stressed.SetActive(false);
                Amelie_Anxious.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "You actually got it all planned out... Are you an undercover?";
                break;
            case 13:
                Amelie_Anxious.SetActive(false);
                Simon_Anxious.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "She took your child, didn't she?";
                break;
            case 14:
                Simon_Anxious.SetActive(false);
                Les_Stressed.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "...";
                break;
            case 15:
                Les_Stressed.SetActive(false);
                Les_Neutral.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "2 of my children... We don't have time now.";
                break;
            case 16:
                Les_Neutral.SetActive(false);
                Emile_Anxious.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Wait, Dr. Les, how are you gonna handle them? They're everywhere and you can't just shoot them!";
                break;
            case 17:
                Emile_Anxious.SetActive(false);
                Vincent_Anxious.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "I can lead them.";
                break;
            case 18:
                Vincent_Anxious.SetActive(false);
                Amanda_Mad.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Vincent, you're one of them, how can we trust you?!";
                break;
            case 19:
                Amanda_Mad.SetActive(false);
                Vincent_Anxious.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "I know, I know! Just let me do the right thing...";
                break;
            case 20: //Going to next scene
                black.DOFade(1f, Timer);

                Vincent_Anxious.SetActive(false);
                Les_Neutral.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "You guys can start now. I'll catch up... Vincent, stay here with me for a sec.";
                break;
            case 21: //Intro - Present
                black.DOFade(0f, Timer);

                introRest.SetActive(false);
                
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "What's your plan then?";
                break;
            case 22:
                Les_Neutral.SetActive(false);
                Vincent_Neutral.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "I... I honestly don't know... I don't know what Mother Maria and her siblings can do...";
                break;
            case 23:
                CharaName_Update = "Vincent";
                CharaChat_Update = "I can put the blame on you only so they won't hunt down my friends. I'll try my best to lure them into the wrong direction.";
                break;
            case 24:
                Vincent_Neutral.SetActive(false);
                Les_Neutral.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Vincent, what will you do after this?";
                break;
            case 25:
                Les_Neutral.SetActive(false);
                Vincent_Anxious.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "...";
                break;
            case 26:
                Vincent_Anxious.SetActive(false);
                Les_Worry.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "Listen, you're not a bad kid. You didn't have any choice.";
                break;
            case 27:
                Les_Worry.SetActive(false);
                Vincent_Anxious.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "Amanda was strong enough to call out our mother.";
                break;
            case 28:
                Vincent_Anxious.SetActive(false);
                Les_Worry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "She wasn't afraid to do it again even after knowing what Miss Maria could do.";
                break;
            case 29:
                Les_Worry.SetActive(false);
                Vincent_Neutral.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "Lets stick with my plan then. I'll try catching up with you guys if things go in our favor.";
                break;
            case 30:
                Vincent_Neutral.SetActive(false);
                Les_Smile.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Thank you.";
                break;
            case 31: //Going next scene
                black.DOFade(1f, Timer);

                Les_Smile.SetActive(false);
                Vincent_Neutral.SetActive(true);

                CharaName_Update = "Vincent";
                CharaChat_Update = "Now go!";
                break;
            case 32: 
                character.transform.DOMove(SlideOut, Timer);

                gameplay.Act_Update = "Act I";
                CharaName_Update = "Act I";
                CharaChat_Update = "Press 'L' to proceed.";

                ChapterProgression++; //To Act 1
                break;
        }
    }
    
    //Act 1
    public void Act1()
    {
        switch (SceneProgression)
        {
            case 33: //Act 1 - Past
                CharaName_Update = "Dr. Lynn";
                CharaChat_Update = "That's not good...";
                break;
            case 34:
                CharaName_Update = "Victoria";
                CharaChat_Update = "How are we gonna tell her?";
                break;
            case 35:
                CharaName_Update = "Leo";
                CharaChat_Update = "We've looked everywhere...";
                break;
            case 36:
                CharaName_Update = "Louis";
                CharaChat_Update = "We have to tell her the truth...";
                break;
            case 37:
                character.transform.DOMove(SlideIn, Timer);

                Vincent_Neutral.SetActive(false);
                YLes_Worry.SetActive(true);

                CharaName_Update = "Ollie";
                CharaChat_Update = "What truth?";
                break;
            case 38:
                Sequence Fade = DOTween.Sequence(); //Going next scene
                Fade.Append(black.DOFade(1f, Timer));
                Fade.Append(gameplay.Les.transform.DOMove(new Vector2(-333.98f, -20.64f), 0f)).SetDelay(0.25f);
                Fade.Append(black.DOFade(0f, Timer));
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Angelica";
                CharaChat_Update = "Ollie- uh..."; 
                break;               
            case 39: //Act 1 - Amanda
                CharaName_Update = "";
                CharaChat_Update = "...";
                break;
            case 40:
                character.transform.DOMove(SlideIn, Timer);

                YLes_Worry.SetActive(false);
                Amanda_Anxious.SetActive(true);
                
                CharaName_Update = "Amanda";
                CharaChat_Update = "This way everyone, this way. Go to the main hall quickly and calmly everyone!";
                break;
            case 41:
                CharaName_Update = "Amanda";
                CharaChat_Update = "How does Mother Maria handle all of us...";
                break;
            case 42:
                Amanda_Anxious.SetActive(false);
                Rosabelle_Neutral.SetActive(true);

                CharaName_Update = "Rosabelle";
                CharaChat_Update = "You're honestly doing well. Let's just hope the noise doesn't come back.";
                break;
            case 43:
                Rosabelle_Neutral.SetActive(false);
                Amanda_Smile.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Rosabelle, Ivy, thank you for helping me with the evacuation by the way.";
                break;
            case 44:
                Amanda_Smile.SetActive(false);
                Rosabelle_Smile.SetActive(true);

                CharaName_Update = "Rosabelle";
                CharaChat_Update = "No problem, we're glad to have you back... What exactly happened?";
                break;
            case 45:
                Rosabelle_Smile.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Mother Maria was the one who pushed me down the stairs.";
                break;
            case 46:
                black.DOFade(1f, Timer); //To next scene

                Amanda_Anxious.SetActive(false);
                Ivy_Anxious.SetActive(true);

                CharaName_Update = "Ivy";
                CharaChat_Update = "M-mother Maria?!";
                break;
            case 47:
                black.DOFade(0f, Timer);

                act1Simon.SetActive(true);

                Ivy_Anxious.SetActive(false);
                Simon_Anxious.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "Amanda!";
                break;
            case 48:
                Simon_Anxious.SetActive(false);
                Amanda_Neutral.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Simon! Did you and Cassie finish the right wing and call Louis?";
                break;
            case 49:
                Amanda_Neutral.SetActive(false);
                Simon_Anxious.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "We called Louis and about the evacuation... The door at the main hall isn't there anymore...";
                break;
            case 50:
                Simon_Anxious.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Simon, it's a pretty big door... What do you mean by that?";
                break;
            case 51:
                Amanda_Anxious.SetActive(false);
                Simon_Anxious.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "The entire door is gone. It's just a wall- I- just follow me!";
                break;
            case 52:
                black.DOFade(1f, Timer);

                Simon_Anxious.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Alright...";
                break;
            case 53: //To Game //Hallway to Library
                Sequence Fade3 = DOTween.Sequence();
                Fade3.Append(character.transform.DOMove(SlideOut, Timer));
                Fade3.Append(gameplay.Les.transform.DOMove(new Vector2(-377.4f, -2.5f), 0f)).SetDelay(0.25f);

                CharaName_Update = "";
                CharaChat_Update = "If you want to proceed. Press 'L' to continue";
                break;
            case 54: //Setting up game
                gameplay.Battle = true;

                shadow.transform.DOMove(SlideDown, Timer);
                black.DOFade(0f, Timer);

                gameplay.gameplayFolder.SetActive(true);
                break;
            case 55: //After Library + Act 1 - Present
                gameplay.Battle = false;

                shadow.transform.DOMove(SlideUp, Timer);
                character.transform.DOMove(SlideIn, Timer);
                
                Sequence Fade2 = DOTween.Sequence(); //To Classroom
                Fade2.Append(black.DOFade(1f, Timer));
                Fade2.Append(gameplay.Les.transform.DOMove(new Vector2(-198.99f, -14.05f), 0f)).SetDelay(0.5f);

                gameplay.gameplayFolder.SetActive(false);
                Amanda_Anxious.SetActive(false);
                Les_Worry.SetActive(true);
                
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "What is this place...";
                break;
            case 56:
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "This orphanage changes... This whole house is after me...";
                break;
            case 57:
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "I need to find a way out... This is not what I expected when I stepped into this orphanage...";
                break;
            case 58:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Act II";
                CharaChat_Update = "Press 'L' to proceed.";
                gameplay.Act_Update = "Act II";

                ChapterProgression++; //To Act2
                break;
        }
    }

    //Act 2
    public void Act2()
    {
        switch (SceneProgression)
        {
            case 59: //Act 2 - Past
                CharaName_Update = "Angelica";
                CharaChat_Update = "Ollie, calm down...";
                break;
            case 60:
                character.transform.DOMove(SlideIn, Timer);

                Les_Worry.SetActive(false);
                YLes_Crying.SetActive(true);
                
                CharaName_Update = "Ollie";
                CharaChat_Update = "They're lying, my children are not dead, I can feel it!";
                break;
            case 61:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Victoria";
                CharaChat_Update = "Take it easy, Ollie...";
                break;
            case 62:
                character.transform.DOMove(SlideIn, Timer);

                CharaName_Update = "Ollie";
                CharaChat_Update = "I can't... I can't just calm down... Who knows what's happening to them!";
                break;
            case 63:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Dr. Lynn";
                CharaChat_Update = "Your children are still alive. They got lazy into looking. Like what they did with the other children...";
                break;
            case 64: 
                CharaName_Update = "Leo";
                CharaChat_Update = "Not now, Lynn...";
                break;
            case 65:
                character.transform.DOMove(SlideIn, Timer);

                YLes_Crying.SetActive(false);
                YLes_Worry.SetActive(true);
                
                CharaName_Update = "Ollie";
                CharaChat_Update = "Other... Children...";
                break;
            case 66:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "";
                CharaChat_Update = "If you want to proceed. Press 'L' to continue";
                break;
            case 67: //To Game
                gameplay.Battle = true;

                shadow.transform.DOMove(SlideDown, Timer);
                black.DOFade(0f, Timer);

                gameplay.gameplayFolder.SetActive(true);
                break;
            case 68: // After Game + Act 2 - Amanda //The Classroom
                gameplay.Battle = false;

                shadow.transform.DOMove(SlideUp, Timer);
                character.transform.DOMove(SlideIn, Timer);
                Sequence Fade = DOTween.Sequence();
                Fade.Append(black.DOFade(1f, Timer));
                Fade.Append(gameplay.Les.transform.DOMove(new Vector2(-357.05f, -21.34f), 0f)).SetDelay(0.25f);

                gameplay.gameplayFolder.SetActive(false);
                YLes_Worry.SetActive(false);
                Emile_Anxious.SetActive(true);
                
                CharaName_Update = "Emile";
                CharaChat_Update = "Are you sure this is a good idea?";
                break;
            case 69:
                black.DOFade(0f, Timer);

                Emile_Anxious.SetActive(false);
                Amelie_Neutral.SetActive(true);
                
                CharaName_Update = "Amelie";
                CharaChat_Update = "I mean, we need to know who we really are right? We still have plenty of time either way.";
                break;
            case 70:
                Amelie_Neutral.SetActive(false);
                Emile_Neutral.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Sis, I found this big book Mother Maria won't let us read...";
                break;
            case 71:
                Emile_Neutral.SetActive(false);
                Amelie_Neutral.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "What's in it?";
                break;
            case 72:
                Amelie_Neutral.SetActive(false);
                Emile_Neutral.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "...";
                break;
            case 73:
                Emile_Neutral.SetActive(false);
                Amelie_Smile.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "That's the year the orphanage was founded, check the later years!";
                break;
            case 74:
                Amelie_Smile.SetActive(false);
                Emile_Smile.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Here, hey it's us!";
                break;
            case 75:
                Emile_Smile.SetActive(false);
                Amelie_Smile.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "Amanda, previously Agnes Ruth... Cassie, previously Christy Hyde... Simon, previously Noah Hyde...";
                break;
            case 76:
                CharaName_Update = "Amelie";
                CharaChat_Update = "Vincent, previously Ian D'Angello... Red...";
                break;
            case 77:
                Amelie_Smile.SetActive(false);
                Amelie_Anxious.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "Red wasn't adopted... She found out, didn't she?";
                break;
            case 78:
                Amelie_Anxious.SetActive(false);
                Amelie_Neutral.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "Wait, is that our names?";
                break;
            case 79:
                Amelie_Neutral.SetActive(false);
                Emile_Neutral.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Amelie, previously Rose Les... Emile, previously Amy Les...";
                break;
            case 80:
                black.DOFade(1f, Timer);

                Emile_Neutral.SetActive(false);
                Amelie_Neutral.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "Les...";
                break;
            case 81://Act 2 - Present
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "";
                CharaChat_Update = "...";
                break;
            case 82:
                character.transform.DOMove(SlideIn, Timer);

                Amelie_Neutral.SetActive(false);
                Les_Worry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Just how many are her siblings"; 
                break;
            case 83:
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "I hope none of the kids encountered them...";
                break;
            case 84:
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Rose... Amy...";
                break;
            case 85: // To Act 3
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Act III";
                CharaChat_Update = "Press 'L' to proceed.";
                gameplay.Act_Update = "Act III";

                ChapterProgression++;
                break;
        }
    }

    //Act 3
    public void Act3()
    {
        switch (SceneProgression)
        {
            case 86: //Act 3 - Past
                CharaName_Update = "Victoria";
                CharaChat_Update = "Leo, how's the case going?";
                break;
            case 87:
                CharaName_Update = "Leo";
                CharaChat_Update = "Not good... Another child was taken away a month ago...";
                break;
            case 88:
                CharaName_Update = "Angelica";
                CharaChat_Update = "They're... Pretty good at this...";
                break;
            case 89:
                CharaName_Update = "Dr. Les";
                CharaChat_Update = "That woman's face was never identified too... Do you think she was also one of those children back then?";
                break;
            case 90:
                character.transform.DOMove(SlideIn, Timer);

                Les_Worry.SetActive(false);
                YLes_Neutral.SetActive(true);
                
                CharaName_Update = "Ollie";
                CharaChat_Update = "So it's a family tradition now?";
                break;
            case 91:
                CharaName_Update = "Ollie";
                CharaChat_Update = "Wait, I got a call, it's from Louis.";
                break;
            case 92:
                CharaName_Update = "Ollie";
                CharaChat_Update = "Hello there... Got it...";
                break;
            case 93:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Leo";
                CharaChat_Update = "What is it?";
                break;
            case 94:
                character.transform.DOMove(SlideIn, Timer);

                CharaName_Update = "Ollie";
                CharaChat_Update = "They found a child... She also needs medical assistance.";
                break;
            case 95:
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "Dr. Lynn";
                CharaChat_Update = "Got it!";
                break;
            case 96: //Act 3 - Amanda
                Sequence Fade = DOTween.Sequence();
                Fade.Append(black.DOFade(1f, Timer));
                Fade.Append(gameplay.Les.transform.DOMove(new Vector2(-338.56f, -37.85f), 0f)).SetDelay(0.25f);
                
                CharaName_Update = "";
                CharaChat_Update = "...";
                break;
            case 97:
                character.transform.DOMove(SlideIn, Timer);
                black.DOFade(0f, Timer);

                act3Rest.SetActive(true); 
                YLes_Neutral.SetActive(false);
                Emile_Neutral.SetActive(true);
                
                CharaName_Update = "Emile";
                CharaChat_Update = "Guys, guys!";
                break;
            case 98:
                Emile_Neutral.SetActive(false);
                Amelie_Neutral.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "You guys will not believe what we found- Wait, where's the door?";
                break;
            case 99:
                Amelie_Neutral.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "None of us saw what happened to the door. It was gone before Simon and Cassie arrived here...";
                break;
            case 100:
                Amanda_Anxious.SetActive(false);
                Emile_Anxious.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Wait, what about the other exits?";
                break;
            case 101:
                Emile_Anxious.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "We also looked. Gone. We can't break the windows too...";
                break;
            case 102:
                Amanda_Anxious.SetActive(false);
                Simon_Neutral.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "What do you guys have there?";
                break;
            case 103:
                Simon_Neutral.SetActive(false);
                Emile_Smile.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Oh this, it's all of our actual names and previous orphans. Everything we need to know is all here!";
                break;
            case 104:
                Emile_Smile.SetActive(false);
                Cassie_Smile.SetActive(true);

                CharaName_Update = "Cassie";
                CharaChat_Update = "That's amazing!";
                break;
            case 105: //To next scene
                Sequence Fade2 = DOTween.Sequence();
                Fade2.Append(black.DOFade(1f, Timer));
                Fade2.Append(gameplay.Les.transform.DOMove(new Vector2(-229.02f, -66.24f), 0f)).SetDelay(0.25f);
                
                Cassie_Smile.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "What do we do now... We haven't heard from Dr. Les or Vincent...";
                break;
            case 106: //Act 3 - Present
                Sequence Fade3 = DOTween.Sequence(); 
                Fade3.Append(gameplay.Les.transform.DOMove(new Vector2(-229.02f, -66.24f), 0f)).SetDelay(0.25f);
                Fade3.Append(black.DOFade(0f, Timer).SetDelay(0.25f));

                act3Rest.SetActive(false);
                Scene1.SetActive(true);
                act3Maria.SetActive(true);
                Amanda_Anxious.SetActive(false);
                Les_Angry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "You're... Alive?!";
                break;
            case 107:
                Les_Angry.SetActive(false);
                Maria_Normal.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "What's wrong? Do you miss me already?";
                break;
            case 108:
                Maria_Normal.SetActive(false);
                Les_Angry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "I miss you being dead already.";
                break;
            case 109:
                Les_Angry.SetActive(false);
                Maria_Normal.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "Oh, I see. You have to try harder than that, Ollie...";
                black.DOFade(1f, Timer);
                break;
            case 110: //To Game
                character.transform.DOMove(SlideOut, Timer);

                act3Maria.SetActive(false);
                
                CharaName_Update = "";
                CharaChat_Update = "If you want to proceed. Press 'L' to continue";
                break;
            case 111: //Game
                gameplay.Battle = true;

                shadow.transform.DOMove(SlideDown, Timer);
                black.DOFade(0f, Timer);

                gameplay.gameplayFolder.SetActive(true);
                break;
        }
    }

    //End
    public void End()
    {
        switch (SceneProgression)
        {
            case 112: //End - Past
                gameplay.Battle = false;
                
                shadow.transform.DOMove(SlideUp, Timer); 
                Sequence Fade = DOTween.Sequence();
                Fade.Append(black.DOFade(1f, Timer));
                Fade.Append(gameplay.Les.transform.DOMove(new Vector2(-335.94f, -37.85f), 0f)).SetDelay(0.25f);

                gameplay.gameplayFolder.SetActive(false);

                gameplay.Act_Update = "";
                CharaName_Update = "End";
                CharaChat_Update = "Press 'L' to continue.";
                break;
            case 113:
                CharaName_Update = "Victoria";
                CharaChat_Update = "Ollie is gone!";
                break;
            case 114:
                CharaName_Update = "Dr. Lynn";
                CharaChat_Update = "Yeah, we know...";
                break;
            case 115:
                CharaName_Update = "Angelica";
                CharaChat_Update = "She refuses to answer any of our calls.";
                break;
            case 116:
                CharaName_Update = "Victoria";
                CharaChat_Update = "She also sent you guys the same message...";
                break;
            case 117:
                CharaName_Update = "Dr. Lynn";
                CharaChat_Update = "I hope we find Ollie ASAP. What she's doing is insane.";
                break;
            case 118:
                CharaName_Update = "Leo";
                CharaChat_Update = "We can only hope at this point...";
                break;
            case 119:
                CharaName_Update = "Victoria";
                CharaChat_Update = "Uh who's there? Ah, Louis";
                break;
            case 120:
                CharaName_Update = "Louis";
                CharaChat_Update = "Uh, hello, someone finally wants to talk to us.";
                break;
            case 121:
                CharaName_Update = "Leo";
                CharaChat_Update = "Ah, you're finally here, Louis... Wait, are you-";
                break;
            case 122:
                CharaName_Update = "Victoria";
                CharaChat_Update = "Oh hey, you must be Red, right?";
                break;
            case 123: //End - Amanda
                black.DOFade(0f, Timer);
                character.transform.DOMove(SlideIn, Timer);

                Maria_Normal.SetActive(false);
                Cassie_Fear.SetActive(true);

                CharaName_Update = "Cassie";
                CharaChat_Update = "The crying is back!";
                break;
            case 124:
                Cassie_Fear.SetActive(false);
                Simon_Anxious.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "This shattered vase doesn't look convenient as a weapon...";
                break;
            case 125:
                Simon_Anxious.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "What do we do now...";
                break;
            case 126:
                black.DOFade(1f, Timer);

                Amanda_Anxious.SetActive(false);
                Les_Neutral.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Amanda?";
                break;
            case 127: //End - Present
                black.DOFade(0f, Timer);

                Scene1.SetActive(false);
                Scene2.SetActive(true);
                Les_Neutral.SetActive(false);
                Amanda_Neutral.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Dr. Les!";
                break;
            case 128:
                Amanda_Neutral.SetActive(false);
                Amelie_Neutral.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "Emile, it's her.";
                break;
            case 129:
                Amelie_Neutral.SetActive(false);
                Emile_Neutral.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "That's our mom... Right?";
                break;
            case 130:
                Emile_Neutral.SetActive(false);
                Amanda_Anxious.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Do you know anything about the crying?";
                break;
            case 131:
                Amanda_Anxious.SetActive(false);
                Emile_Anxious.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "Did you see Vincent?";
                break;
            case 132:
                Emile_Anxious.SetActive(false);
                Les_Neutral.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Wait, why are you all not out yet?";
                break;
            case 133:
                Les_Neutral.SetActive(false);
                Amelie_Anxious.SetActive(true);

                CharaName_Update = "Amelie";
                CharaChat_Update = "The door's gone.";
                break;
            case 134:
                Amelie_Anxious.SetActive(false);
                Les_Worry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "What do you mea-... No... No, no, no, no.";
                break;
            case 135:
                Les_Worry.SetActive(false);
                Les_Stressed.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "I... Already killed her twice...";
                break;
            case 136: //Mother Maria jumpscare incoming
                black.DOFade(1f, Timer);

                Les_Stressed.SetActive(false);
                Simon_Fear.SetActive(true);

                CharaName_Update = "Simon";
                CharaChat_Update = "Twice?!";
                break;
            case 137: //MOTHER MARIA JUMPSCARE
                black.DOFade(0f, Timer);

                Scene2.SetActive(false);
                Scene3.SetActive(true);
                Simon_Fear.SetActive(false);
                Maria_Blood.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "That gun is never going to work on me, Ollie.";
                break;
            case 138:
                Maria_Blood.SetActive(false);
                Les_Angry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Back off!";
                break;
            case 139:
                black.DOFade(1f, Timer);
                Les_Angry.SetActive(false);
                Maria_Blood.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "Do you really think that pistol will help? What do you think, Vincent?";
                break;
            case 140:
                black.DOFade(0f, Timer);

                Scene3.SetActive(false);
                Scene4.SetActive(true);
                Maria_Blood.SetActive(false);
                Amanda_Fear.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Vincent!";
                break;
            case 141:
                Amanda_Fear.SetActive(false);
                Emile_Fear.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "N-no... Is he-";
                break;
            case 142:
                Emile_Fear.SetActive(false);
                Maria_Blood.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "He gave himself up for us. For the better good of this orphanage.";
                break;
            case 143:
                Maria_Blood.SetActive(false);
                Amanda_Fear.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "Why are you doing this?!";
                break;
            case 144:
                Amanda_Fear.SetActive(false);
                Maria_Blood.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "Do you remember what I said? Life outside is cruel. This orphanage is a safe place for you all far away from evil.";
                break;
            case 145:
                Maria_Blood.SetActive(false);
                Amanda_Mad.SetActive(true);

                CharaName_Update = "Amanda";
                CharaChat_Update = "No, enough of that!";
                break;
            case 146:
                Amanda_Mad.SetActive(false);
                Les_Angry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "You're right. Life outside is cruel but that doesn't justify you taking children away from their families!";
                break;
            case 147:
                Les_Angry.SetActive(false);
                Maria_Blood.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "Oh we don't just take any children. They're all special. They chose them. They want to give children a better life for the greater good.";
                break;
            case 148:
                Maria_Blood.SetActive(false);
                Emile_Fear.SetActive(true);

                CharaName_Update = "Emile";
                CharaChat_Update = "They...";
                break;
            case 149:
                Emile_Fear.SetActive(false);
                Cassie_Fear.SetActive(true);

                CharaName_Update = "Cassie";
                CharaChat_Update = "THEY?!";
                break;
            case 150:
                Cassie_Fear.SetActive(false);
                Les_Angry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Who the HELL is they?!";
                break;
            case 151:
                Les_Angry.SetActive(false);
                Maria_Blood.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "Do you want to meet them?";
                break;
            case 152:
                black.DOFade(1f, Timer);

                Maria_Blood.SetActive(false);
                Les_Angry.SetActive(true);

                CharaName_Update = "Dr. Les";
                CharaChat_Update = "Kids, stay back!";
                break;
            case 153: //Uh oh
                character.transform.DOMove(SlideOut, Timer);

                CharaName_Update = "";
                CharaChat_Update = "...!";
                break;
            case 154: //UH OH
                character.transform.DOMove(SlideIn, Timer);

                Les_Angry.SetActive(false);
                Maria_Angel.SetActive(true);

                CharaName_Update = "Mother Maria";
                CharaChat_Update = "Oh they will be delighted to see you all.";
                break;
            case 155: //This will end the game and bring it back to the main menu!
                shadow.transform.DOMove(SlideDown, Timer);
                character.transform.DOMove(SlideOut, Timer);
                gameplay.Exit();
                break;
        }
    }

    
    
}
