﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower
{
    [SerializeField, Range(1f, 100f)]
    float damagePerSecond = 10f;

    [SerializeField]
    Transform turrent = default, laserBeam = default;

    TargetPoint target;

    Vector3 laserBeamScale;

    void Awake() {
        laserBeamScale = laserBeam.localScale;
    }

    public override void GameUpdate() {
        if (TrackTarget(ref target) || AcquireTarget(out target)) {
            Shoot();
        } else {
            laserBeam.localScale = Vector3.zero;
        }
    }

    void Shoot() {
        Vector3 point = target.Position;
        turrent.LookAt(point);
        laserBeam.localRotation = turrent.localRotation;

        float d = Vector3.Distance(turrent.position, point);
        laserBeamScale.z = d;
        laserBeam.localScale = laserBeamScale;
        laserBeam.localPosition = turrent.localPosition + 0.5f * d * laserBeam.forward;

        target.Enemy.ApplyDamage(damagePerSecond * Time.deltaTime);
    }
}
