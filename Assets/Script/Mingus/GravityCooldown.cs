using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GravityCooldown : MonoBehaviour
{
    public PlayerController playerControls;

    public Animator radiationAnimator;
    public Animator triangleAnimator;
    public Animator hourglassAnimator;
    public Animator onSymbolAnimator;

    public Image cooldownImage;
    public Image radiationImage;
    public Image radiationGlow;
    public Image onSymbol;
    public Image triangleImage;
    public Image hourglassImage;

    public float maxReactorDistance;
    public float reactorDistance;

    public float maxDuration;
    public float durationRemaining;

    public float maxCooldown;
    public float currentCooldown;

    private float colourScaler;
    private bool colourShift;

    private void Start()
    {
        maxDuration = playerControls.MaxLowGravityDuration;
        durationRemaining = maxDuration;

        maxCooldown = playerControls.MaxCooldownLowGravity;
        currentCooldown = 0;

        maxReactorDistance = playerControls.maxReactorDistance;

        cooldownImage.GetComponent<Image>().color = new Color(0, 1, 1, 0.8f);
    }

    private void Update()
    {
        
        //check distance between player and reactor
        reactorDistance = playerControls.distance;

        //change image colour and alpha
        changeImageColour(reactorDistance, maxReactorDistance);

        //if close to reactor
        if (reactorDistance < maxReactorDistance * 0.95f)
        {
            radiationAnimator.SetBool("closeToReactor", true);

            //select animations in blend tree based on distance
            radiationAnimator.SetFloat("distance", Mathf.InverseLerp(maxReactorDistance * 0.1f, maxReactorDistance, maxReactorDistance - reactorDistance));


            if (reactorDistance < maxReactorDistance * 0.7f)
            {
                triangleAnimator.SetBool("yellowTriangle", true);
                onSymbol.gameObject.SetActive(false);
                hourglassImage.gameObject.SetActive(false);
                triangleImage.gameObject.SetActive(true);
            }
            else
            {
                triangleAnimator.SetBool("yellowTriangle", false);
                triangleImage.gameObject.SetActive(false);
            }
        }
        else
        {
            radiationAnimator.SetBool("closeToReactor", false);
        }

        //check if low gravity can be used
        if (playerControls.CooldownLowGravity == 0 && playerControls.LowGravityDuration < playerControls.MaxLowGravityDuration)
        {
            if (reactorDistance >= maxReactorDistance * 0.7f)
            {
                onSymbol.gameObject.SetActive(true);
            }
            //invert duration count direction
            durationRemaining = 10 - playerControls.LowGravityDuration;
            //set colour to blue when cooldown is finished
            cooldownImage.GetComponent<Image>().color = new Color(0, 1, 1, 0.8f);
            //determine fill amount of image based on the current duration relative to the max duration
            cooldownImage.fillAmount = Mathf.InverseLerp(0, maxDuration, durationRemaining);

            //disable cooldown symbol
            hourglassImage.gameObject.SetActive(false);
            hourglassAnimator.SetBool("onCooldown", false);
        }
        else
        {
            //check current cooldown time
            currentCooldown = playerControls.CooldownLowGravity;
            //set colour to red when cooldown is active
            cooldownImage.GetComponent<Image>().color = new Color(1, 0.5f, 0.5f, 0.8f);
            //determine fill amount of image based on the current duration relative to the max duration
            cooldownImage.fillAmount = 0 - (-1 * Mathf.InverseLerp(0, maxCooldown, currentCooldown));

            //disable on symbol
            onSymbol.gameObject.SetActive(false);

            //enable cooldown symbol
            if (reactorDistance >= maxReactorDistance * 0.7f)
            {
                hourglassImage.gameObject.SetActive(true);
                hourglassAnimator.SetBool("onCooldown", true);
            }

            if (currentCooldown >= 9.99)
            {
                onSymbol.gameObject.SetActive(true);
                onSymbolAnimator.SetBool("recharged", true);
                colourShift = true;
            }
        }

        if (colourShift)
        {
            colourScaler += 1.25f * Time.deltaTime;
            cooldownImage.GetComponent<Image>().color = new Color(Mathf.Lerp(1, 0, colourScaler), Mathf.Lerp(0.5f, 1, colourScaler), Mathf.Lerp(0.5f, 1, colourScaler), 0.8f);
            if (colourScaler >= 1)
            {
                onSymbolAnimator.SetBool("recharged", false);
                colourShift = false;
                colourScaler = 0;
            }
        }
    }

    private void changeImageColour(float reactorDistance, float maxReactorDistance)
    {
        //calculate new colour and alpha values based on reactor distance
        float redColour = Mathf.InverseLerp(maxReactorDistance * 0.1f, maxReactorDistance * 0.75f, maxReactorDistance - reactorDistance);
        float greenColour = Mathf.InverseLerp(maxReactorDistance * 0.5f, maxReactorDistance, reactorDistance);
        float blueColour = Mathf.InverseLerp(maxReactorDistance * 0.5f, maxReactorDistance, reactorDistance);
        float imageAlphaChange = Mathf.InverseLerp(0, maxReactorDistance, (maxReactorDistance * 1.2f) - reactorDistance);

        //set minimum alpha of 0.2
        if (imageAlphaChange < 0.2)
        {
            imageAlphaChange = 0.2f;
        }

        float glowAlphaChange = Mathf.InverseLerp(0, maxReactorDistance, maxReactorDistance - reactorDistance);

        //change colour of image based on these values
        radiationImage.GetComponent<Image>().color = new Color(redColour, greenColour, blueColour, imageAlphaChange);
        radiationGlow.GetComponent<Image>().color = new Color(redColour, greenColour, blueColour, glowAlphaChange);
    }
}
