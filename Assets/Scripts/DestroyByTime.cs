using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public DestroyByTime(float _lifetime)
    {
        this.lifeTime = _lifetime;
    }
}
