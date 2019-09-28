﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {
    [SerializeField]
    Transform arrow = default;

    GameTile north, east, south, west;

    public static void MakeEastWestNeighbors(GameTile east, GameTile west) {
        Debug.Assert(west.east == null && east.west == null, "Redefined Neighbors!");
        west.east = east;
        east.west = west;
    }

    public static void MakeNorthSouthNeighbors(GameTile north, GameTile south) {
        Debug.Assert(north.south == null && south.north == null, "Redefined Neighbors!");
        north.south = south;
        south.north = north;
    }
}