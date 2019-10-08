﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTower : Tower
{
    [SerializeField, Range(0.5f, 2f)]
    float shotsPreSecond = 1f;

    [SerializeField]
    Transform mortar = default;

    public override TowerType TowerType => TowerType.Mortar;
}
