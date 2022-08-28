using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Const;

public class InputModule : MonoBehaviour
{
    public Transform rightHand;
    public Transform leftHand;
    public Transform originCamera;

    public SteamVR_Action_Boolean Bumper;
    public SteamVR_Action_Boolean Grab;
    public SteamVR_Action_Boolean Trigger;
    public SteamVR_Action_Boolean TrackTele;
    public SteamVR_Action_Boolean TrackLeftPad;
    public SteamVR_Action_Boolean TrackRightPad;
    public SteamVR_Action_Boolean FrontBtn;
    public SteamVR_Action_Boolean BackBtn;

    private void Awake()
    {
        controller.rightHand = rightHand;
        controller.leftHand = leftHand;
        controller.originCamera = originCamera;
    }

    public void InputCheck()
    {
        clickBumper();
        clickTrigger();
        ClickGrab();
        ClickTele();
        ClickPad();
        ClickFrontBtn();
        ClickBackBtn();
    }

    private void btnAction(actionName actionName)
    {
        Debug.Log($"btnAction : {actionName}");
        if (delegateManager.instance.getInputDelegate().
            TryGetValue(actionName.ToString(), out List<System.Action> actions))
            foreach (System.Action action in actions)
                action?.Invoke();
    }

    protected void clickBumper()
    {
        if (Bumper.GetState(SteamVR_Input_Sources.Any))
            btnAction(actionName.bumper);
    }

    protected void clickTrigger()
    {
        if (Trigger.GetState(SteamVR_Input_Sources.Any) ||
            Input.GetKey(KeyCode.Space))
            btnAction(actionName.trigger);
    }

    protected void ClickGrab()
    {
        if (Grab.GetStateDown(SteamVR_Input_Sources.Any))
            btnAction(actionName.grab);
    }
    protected void ClickTele()
    {
        if (TrackTele.GetState(SteamVR_Input_Sources.LeftHand))
            btnAction(actionName.left_padfront);
        if (TrackTele.GetState(SteamVR_Input_Sources.RightHand))
            btnAction(actionName.right_padfront);
    }

    protected void ClickPad()
    {
        if (TrackLeftPad.GetState(SteamVR_Input_Sources.LeftHand))
            btnAction(actionName.left_padleft);
        if (TrackLeftPad.GetState(SteamVR_Input_Sources.RightHand))
            btnAction(actionName.left_padright);

        if (TrackRightPad.GetState(SteamVR_Input_Sources.LeftHand))
            btnAction(actionName.right_padleft);
        if (TrackRightPad.GetState(SteamVR_Input_Sources.RightHand))
            btnAction(actionName.right_padright);
    }

    protected void ClickFrontBtn()
    {
        if (FrontBtn.GetState(SteamVR_Input_Sources.LeftHand)
            || Input.GetKey(KeyCode.Q))
            btnAction(actionName.left_frontbtn);
        if (FrontBtn.GetState(SteamVR_Input_Sources.RightHand)
            || Input.GetKey(KeyCode.W))
            btnAction(actionName.right_frontbtn);
    }
    protected void ClickBackBtn()
    {
        if (BackBtn.GetState(SteamVR_Input_Sources.LeftHand)
            || Input.GetKey(KeyCode.E))
            btnAction(actionName.left_backbtn);
        if (BackBtn.GetState(SteamVR_Input_Sources.RightHand)
            || Input.GetKey(KeyCode.R))
            btnAction(actionName.right_backbtn);
    }

}
