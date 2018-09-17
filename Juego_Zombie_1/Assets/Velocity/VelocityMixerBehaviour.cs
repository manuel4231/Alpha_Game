using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class VelocityMixerBehaviour : PlayableBehaviour
{
    Vector3 m_DefaultVelocity;

    Vector3 m_AssignedVelocity;

    Rigidbody m_TrackBinding;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        m_TrackBinding = playerData as Rigidbody;

        if (m_TrackBinding == null)
            return;

        if (m_TrackBinding.velocity != m_AssignedVelocity)
            m_DefaultVelocity = m_TrackBinding.velocity;

        int inputCount = playable.GetInputCount ();

        Vector3 blendedVelocity = Vector3.zero;
        float totalWeight = 0f;
        float greatestWeight = 0f;

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<VelocityBehaviour> inputPlayable = (ScriptPlayable<VelocityBehaviour>)playable.GetInput(i);
            VelocityBehaviour input = inputPlayable.GetBehaviour ();
            
            blendedVelocity += input.velocity * inputWeight;
            totalWeight += inputWeight;

            if (inputWeight > greatestWeight)
            {
                greatestWeight = inputWeight;
            }
        }

        m_AssignedVelocity = blendedVelocity + m_DefaultVelocity * (1f - totalWeight);
        m_TrackBinding.velocity = m_AssignedVelocity;
    }
}
