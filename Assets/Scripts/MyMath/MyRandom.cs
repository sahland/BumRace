using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRandom : MonoBehaviour
{
    public static Vector3 GetRandomUnitSphere()
    {
        Single x = GetRange(-1.0f, 1.0f);
        Single y = GetRange(-1.0f, 1.0f);
        Single z = GetRange(-1.0f, 1.0f);

        Vector3 randomVector = new Vector3(x, y, z);
        randomVector.Normalize();

        return randomVector;
    }

    public static float GetRange(float min, float max)
    {
        float range = max - min;

        float randomValue = UnityEngine.Random.value * range;

        return min + randomValue;
    }
}
