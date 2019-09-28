using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTileContent : MonoBehaviour
{
    [SerializeField]
    GameTileContentType type = default;

    public GameTileContentType Type => type;
}
