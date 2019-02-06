using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatingWindow : MonoBehaviour {
    Animation cachedAnimation;

    [SerializeField] private float currentAnimTime = 0;

    void Awake() =>
        cachedAnimation = GetComponent<Animation>();

    void Update() {
        if (Input.anyKeyDown)
            ToggleAnimation();
    }

    void ToggleAnimation() {
        cachedAnimation[cachedAnimation.clip.name].speed =
            currentAnimTime == 0 ? 1 : currentAnimTime == 1 ? -1 :
            cachedAnimation[cachedAnimation.clip.name].speed *= -1;

        if (!cachedAnimation.isPlaying)
            if (currentAnimTime == 1)
                cachedAnimation[cachedAnimation.clip.name].time = 1;

            cachedAnimation.Play();
    }
}
