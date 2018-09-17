using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class VelocityClip : PlayableAsset, ITimelineClipAsset
{
    public VelocityBehaviour template = new VelocityBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.Blending; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<VelocityBehaviour>.Create (graph, template);
        return playable;
    }
}
