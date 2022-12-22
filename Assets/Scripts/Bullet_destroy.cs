using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_destroy : MonoBehaviour
{
    public GameObject gameObj;
    public float BulletDestroyTime;
    void Start()
    {
        Destroy(gameObj, BulletDestroyTime);
    }
}
