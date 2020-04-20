using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimpleAnimationExtensions
{
    public static void StartAnimations(this GameObject gameObject)
    {
        foreach (var animation in gameObject.GetComponents<SimpleAnimation>())
        {
            animation.StartAnimation();
        }
    }
}
