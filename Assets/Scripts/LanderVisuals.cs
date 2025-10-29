using System;
using UnityEngine;

public class LanderVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftThrusterParticleSystem;
    [SerializeField] private ParticleSystem centerThrusterParticleSystem;
    [SerializeField] private ParticleSystem rightThrusterParticleSystem;


    private void Awake()
    {
        Lander.Instance.OnUpForce += Lander_OnUpForce;
        Lander.Instance.OnLeftForce += Lander_OnLeftForce;
        Lander.Instance.OnRightForce += Lander_OnRightForce;
        Lander.Instance.OnNoForce += Lander_OnNoForce;

        SetEnabledThrustParticleSystem(leftThrusterParticleSystem, false);
        SetEnabledThrustParticleSystem(centerThrusterParticleSystem, false);
        SetEnabledThrustParticleSystem(rightThrusterParticleSystem, false);
    }

    private void Lander_OnRightForce1(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Lander_OnLeftForce1(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Lander_OnUpForce(object sender, System.EventArgs e) 
    {
        SetEnabledThrustParticleSystem(leftThrusterParticleSystem, true);
        SetEnabledThrustParticleSystem(centerThrusterParticleSystem, true);
        SetEnabledThrustParticleSystem(rightThrusterParticleSystem, true);
    }

    private void Lander_OnLeftForce(object sender, System.EventArgs e)
    {
        SetEnabledThrustParticleSystem(rightThrusterParticleSystem, true);
    }

    private void Lander_OnRightForce(object sender, System.EventArgs e)
    {
        SetEnabledThrustParticleSystem(leftThrusterParticleSystem, true);
    }

    private void Lander_OnNoForce(object sender, System.EventArgs e)
    {
        SetEnabledThrustParticleSystem(leftThrusterParticleSystem, false);
        SetEnabledThrustParticleSystem(centerThrusterParticleSystem, false);
        SetEnabledThrustParticleSystem(rightThrusterParticleSystem, false);
    }



    private void SetEnabledThrustParticleSystem(ParticleSystem particleSystem, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = enabled;
    }
}
