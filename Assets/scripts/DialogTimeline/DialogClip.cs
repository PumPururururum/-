using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogClip : PlayableAsset
{
    public string dialogText;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogBehavior>.Create(graph);

        DialogBehavior dialogBehavior = playable.GetBehaviour();
        dialogBehavior.dialogText = dialogText;
        return playable;
    }
}
