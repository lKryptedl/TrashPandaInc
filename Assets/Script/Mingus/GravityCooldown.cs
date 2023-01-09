using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class GravityCooldown : MonoBehaviour
{
    public PlayerController playerControls;

    public Volume globalVolume;
    private Vignette vignette;
    private FilmGrain filmGrain;
    private ChromaticAberration chromaticAberration;
    private MotionBlur motionBlur;

    public Animator radiationAnimator;
    public Animator triangleAnimator;
    public Animator hourglassAnimator;
    public Animator onSymbolAnimator;
    public Animator activeAnimator;

    public AudioSource audioSourceRecharge;
    public AudioSource audioSourceDeplete;


    public Image cooldownImage;
    public Image radiationImage;
    public Image radiationGlow;
    public Image onSymbol;
    public Image triangleImage;
    public Image hourglassImage;
    public Image activeImage;

    private float maxReactorDistance;
    private float reactorDistance;

    private float maxDuration;
    private float durationRemaining;

    private float maxCooldown;
    private float currentCooldown;

    private float colourScaler;
    private bool colourShift;

    private void Start()
    {
        globalVolume.profile.TryGet<Vignette>(out vignette);
        globalVolume.profile.TryGet<FilmGrain>(out filmGrain);
        globalVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        globalVolume.profile.TryGet<MotionBlur>(out motionBlur);

        maxDuration = playerControls.MaxLowGravityDuration;
        durationRemaining = maxDuration;

        maxCooldown = playerControls.MaxCooldownLowGravity;
        currentCooldown = 0;

        maxReactorDistance = playerControls.maxReactorDistance;

        cooldownImage.GetComponent<Image>().color = new Color(0, 1, 1, 0.8f);
        onSymbol.GetComponent<Image>().color = new Color(0, 1, 1, 0.8f);
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

            vignette.intensity.value = 0.6f * Mathf.InverseLerp(0, 0.5f * maxReactorDistance, maxReactorDistance - reactorDistance);
            filmGrain.intensity.value = Mathf.InverseLerp(0, 0.5f * maxReactorDistance, maxReactorDistance - reactorDistance);
            chromaticAberration.intensity.value = 0.75f * Mathf.InverseLerp(0, 0.5f * maxReactorDistance, maxReactorDistance - reactorDistance);
            motionBlur.intensity.value = 0.5f * Mathf.InverseLerp(0, 0.5f * maxReactorDistance, maxReactorDistance - reactorDistance);

            if (reactorDistance < maxReactorDistance * 0.7f)
            {
                triangleAnimator.SetBool("yellowTriangle", true);

                onSymbol.gameObject.SetActive(false);
                activeImage.gameObject.SetActive(false);
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

                if (playerControls.LowGravityDuration > 0)
                {
                    onSymbol.gameObject.SetActive(false);
                    
                    audioSourceDeplete.Play();

                    activeImage.gameObject.SetActive(true);
                    activeAnimator.SetBool("isActive", true);
                }
            }
            //invert duration count direction
            durationRemaining = maxDuration - playerControls.LowGravityDuration;
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
            //OutofCooldown
            //audioSourceDeplete.Play();

            //enable cooldown symbol
            if (reactorDistance >= maxReactorDistance * 0.7f)
            {
                hourglassImage.gameObject.SetActive(true);
                hourglassAnimator.SetBool("onCooldown", true);

                activeImage.gameObject.SetActive(false);
                activeAnimator.SetBool("isActive", false);
            }

            if (currentCooldown >= 0.99 * maxCooldown)
            {
                onSymbol.gameObject.SetActive(true);
                onSymbolAnimator.SetBool("recharged", true);

                hourglassImage.gameObject.SetActive(false);
                hourglassAnimator.SetBool("onCooldown", false);

                colourShift = true;
            }
        }

        if (colourShift)
        {
            colourScaler += Time.deltaTime;
            cooldownImage.GetComponent<Image>().color = new Color(Mathf.Lerp(1, 0, colourScaler), Mathf.Lerp(0.5f, 1, colourScaler), Mathf.Lerp(0.5f, 1, colourScaler), 0.8f);
            onSymbol.GetComponent<Image>().color = new Color(Mathf.Lerp(1, 0, colourScaler), Mathf.Lerp(0.5f, 1, colourScaler), Mathf.Lerp(0.5f, 1, colourScaler), 0.8f);
            if (colourScaler >= 1)
            {
                onSymbolAnimator.SetBool("recharged", false);
                colourShift = false;
                colourScaler = 0;
                audioSourceRecharge.Play();
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
