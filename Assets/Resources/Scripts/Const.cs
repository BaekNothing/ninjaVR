using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Const
{
    public enum actionName
    {
        bumper = 0,
        grab,
        trigger,

        left_padfront,
        left_padleft,
        left_padright,
        left_frontbtn,
        left_backbtn,

        right_padfront,
        right_padleft,
        right_padright,
        right_frontbtn,
        right_backbtn,
    }

    static public class controller
    {
        static public Transform rightHand;
        static public Transform leftHand;
        static public Transform originCamera;
    }
}