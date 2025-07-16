using System;
using System.Collections;
using UnityEngine;

public class AffectedByCamera : CameraListener
{
    public CameraAction[] actions;
    int index;

    public bool justBlink;

    public override void Start()
    {
        base.Start();
        //DoAction(new CameraAction(){action = CameraAction.CameraFunction.MakeTallyHallReference});
    }

    void Update()
    {
        wantsToBeSeen = index < actions.Length;
        if (justBlink)
        {
            Vector3 dif = transform.position - PlayerMovement.instance.transform.position;
            Vector3 dif2D = new Vector3(dif.x, 0, dif.y);
            if (dif2D.magnitude <= distanceToRegisterPicture)
            {
                PlayerMovement.instance.blitz.dictatorThinksSame = true;
            }
        }
    }

    public void DoAction(CameraAction action)
    {
        switch (action.action)
        {
            case CameraAction.CameraFunction.Activate:
                action.affectedObject.SetActive(true);
                break;
            case CameraAction.CameraFunction.DeActivate:
                action.affectedObject.SetActive(false);
                break;
            case CameraAction.CameraFunction.Destroy:
                Destroy(action.affectedObject);
                break;
            case CameraAction.CameraFunction.MakeTallyHallReference:
                RenderSettings.fog = true;
                RenderSettings.ambientSkyColor = Color.black;
                SpawnPointManger.instance.count = true;
                MusicManager.instance.SoundtrackNumberToPlay = 3;
                MusicManager.instance.PlayDarknessMusic();
                break;
            case CameraAction.CameraFunction.CallBBGrl:
                SpawnPointManger.instance.SpawnAt(SpawnPointManger.instance.furthestPoint);
                PlayerMovement.instance.blitz.Break();
                break;
            case CameraAction.CameraFunction.JingleJangle:
                MonsterScript.instance.OnTakePicture();
                PlayerMovement.instance.ScreenStatic();
                break;
            case CameraAction.CameraFunction.JingleJangleTheJonglerReturns:
                print("hi");
                PlayerMovement.instance.StopScreenStatic();
                break;
            case CameraAction.CameraFunction.Key:
                PlayerMovement.instance.OpenLastDoorFromKeysWhichIsAFuctionThatShouldBeInPlayerMovement();
                break;
            case CameraAction.CameraFunction.ChaseScene:
                MonsterScript.instance.weakened = true;
                MonsterScript.instance.nearSpeed = 3f;
                MusicManager.instance.SwitchToIntenseDarknessMusic();
                PlayerMovement.instance.blitz.Break();
                break;
            case CameraAction.CameraFunction.Win:
                if (MonsterScript.instance.diedEver)
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Credits scene");
                else
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Credits scene 1");
                break;
        }
    }
    
    public override void OnTakePicture()
    {
        if (doingStuff) return;
            StartCoroutine(DoThing());
    }

    public IEnumerator DoThing()
    {
        doingStuff = true;
        bool keepGoing = false;
        do
        {
            if (index == actions.Length)
                break;
            DoAction(actions[index]);
            keepGoing = actions[index].continueToNextAction;
            if (actions[index].action == CameraAction.CameraFunction.Jump)
                index = actions[index].jumpTo - 1;
            if (actions[index].waitFor > 0)
                yield return new WaitForSeconds(actions[index].waitFor);
            if (actions[index].action != CameraAction.CameraFunction.EatPizza)
                index++;
            
            wantsToBeSeen = index < actions.Length;
        } while (keepGoing);

        doingStuff = false;
    }
}
