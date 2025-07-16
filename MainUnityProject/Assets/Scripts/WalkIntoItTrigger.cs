using System.Collections;
using UnityEngine;

public class WalkIntoItTrigger : MonoBehaviour
{
    public CameraAction[] actions;
    int index;
    bool doingStuff;

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
                PlayerMovement.instance.StopScreenStatic();
                break;
            case CameraAction.CameraFunction.Key:
                PlayerMovement.instance.OpenLastDoorFromKeysWhichIsAFuctionThatShouldBeInPlayerMovement();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (doingStuff) return;
        {
            if (other.name == "Player")
                StartCoroutine(DoThing());
        }
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
        } while (keepGoing);

        doingStuff = false;
    }
}
