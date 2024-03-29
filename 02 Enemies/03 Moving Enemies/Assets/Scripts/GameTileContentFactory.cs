﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameTileContentFactory : GameObjectFactory {
    [SerializeField]
    GameTileContent emptyPrefab = default;
    [SerializeField]
    GameTileContent destinationPrefab = default;
    [SerializeField]
    GameTileContent wallPrefab = default;
    [SerializeField]
    GameTileContent spawnPointPrefab = default;

    public GameTileContent Get(GameTileContentType type) {
        switch (type) {
            case GameTileContentType.Empty: return Get(emptyPrefab);
            case GameTileContentType.Destination: return Get(destinationPrefab);
            case GameTileContentType.Wall: return Get(wallPrefab);
            case GameTileContentType.SpawnPoint: return Get(spawnPointPrefab);
        }
        Debug.Assert(false, "Unspported type: " + type);
        return null;
    }


    public void Reclaim(GameTileContent content) {
        Debug.Assert(content.OriginFactory == this, "Wrong factory reclaimed!");
        Destroy(content.gameObject);
    }

    GameTileContent Get(GameTileContent prefab) {
        GameTileContent instance = CreateGameObjectInstance(prefab);
        instance.OriginFactory = this;
        return instance;
    }
}
