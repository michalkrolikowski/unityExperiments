using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatingWindow : MonoBehaviour {
    Animation cachedAnimation;

    [SerializeField] float currentAnimTime = 0;

    void Awake() =>
        cachedAnimation = GetComponent<Animation>();

    void Update() {
        if (Input.anyKeyDown)
            ToggleAnimation();
    }

    void ToggleAnimation() {
        if (cachedAnimation.isPlaying) {
            cachedAnimation[cachedAnimation.clip.name].speed *= -1;
        } else {
            cachedAnimation[cachedAnimation.clip.name].time = currentAnimTime;
            cachedAnimation[cachedAnimation.clip.name].speed = currentAnimTime >= 1 ? -1 : 1;
            cachedAnimation.Play();
        }
    }
}
