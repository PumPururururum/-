using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class DialogBehavior : PlayableBehaviour
{
    public string dialogText;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = dialogText;
        text.color = new   Color(0, 0, 0, info.weight);
    }
}
