using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {
    [SerializeField]
    Transform arrow = default;

    GameTile north, east, south, west, nextOnPath;
    int distance;

    public bool HasPath => distance != int.MaxValue;
    public GameTile GrowPathNorth() => GrowPathTo(north);
    public GameTile GrowPathEast() => GrowPathTo(east);
    public GameTile GrowPathSouth() => GrowPathTo(south);
    public GameTile GrowPathWest() => GrowPathTo(west);

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

    public void ClearPath() {
        distance = int.MaxValue;
        nextOnPath = null;
    }

    public void BecomeDestination() {
        distance = 0;
        nextOnPath = null;
    }

    GameTile GrowPathTo(GameTile neighbor) {
        Debug.Assert(HasPath, "No path!");
        if (neighbor == null || neighbor.HasPath) return null;
        neighbor.distance = distance + 1;
        neighbor.nextOnPath = this;
        return neighbor;
    }


}
