using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GravityCooldown : MonoBehaviour
{
    public PlayerController playerControls;

    public Image cooldownImage;
    public Image radiationImage;

    public float maxReactorDistance;
    public float reactorDistance;

    public float maxDuration;
    public float durationRemaining;

    public float maxCooldown;
    public float currentCooldown;

    private void Start()
    {
        maxDuration = playerControls.MaxLowGravityDuration;
        durationRemaining = maxDuration;

        maxCooldown = playerControls.MaxCooldownLowGravity;
        currentCooldown = 0;

        maxReactorDistance = playerControls.maxReactorDistance;
        radiationImage.GetComponent<Image>().color = new Color(0, 1, 1, 0.2f);
    }

    private void Update()
    {
        //check distance between player and reactor
        reactorDistance = playerControls.distance;

        //check if distance is less than set units
        if (reactorDistance < maxReactorDistance)
        {
            //call method to change colour from blue to green
            changeImageColour(reactorDistance, maxReactorDistance);
        }

        //check if cooldown is active
        if (playerControls.CooldownLowGravity == 0)
        {
            //invert duration count direction
            durationRemaining = 10 - playerControls.LowGravityDuration;
            //set colour to blue when cooldown is finished
            cooldownImage.GetComponent<Image>().color = new Color(0, 1, 1, 0.8f);
            //determine fill amount of image based on the current duration relative to the max duration
            cooldownImage.fillAmount = Mathf.InverseLerp(0, maxDuration, durationRemaining);
        }
        else
        {
            //check current cooldown time
            currentCooldown = playerControls.CooldownLowGravity;
            //set colour to red when cooldown is active
            cooldownImage.GetComponent<Image>().color = new Color(1, 0.5f, 0.5f, 0.8f);
            //determine fill amount of image based on the current duration relative to the max duration
            cooldownImage.fillAmount = 0 - (-1 * Mathf.InverseLerp(0, maxCooldown, currentCooldown));
        }
    }

    private void changeImageColour(float reactorDistance, float maxReactorDistance)
    {
        //calculate new blue and alpha values based on reactor distance
        float blueColour = Mathf.InverseLerp(maxReactorDistance * 0.95f, maxReactorDistance, reactorDistance);
        float alphaChange = Mathf.InverseLerp(0, maxReactorDistance, (maxReactorDistance * 1.2f) - reactorDistance);

        //change colour of image based on these values
        radiationImage.GetComponent<Image>().color = new Color(0, 1, blueColour, alphaChange);
    }
}
