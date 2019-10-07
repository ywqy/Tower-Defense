using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : GameTileContent {
    const int enemyLayerMask = 1 << 9;

    [SerializeField, Range(1.5f, 10.5f)]
    float targetingRange = 1.5f;

    TargetPoint target;

    public override void GameUpdate() {
        if (TrackTarget() || AcquireTarget()) {
            Debug.Log("Locked on Target");
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Vector3 position = transform.localPosition;
        position.y += 0.01f;
        Gizmos.DrawWireSphere(position, targetingRange);
        if (target != null) {
            Gizmos.DrawLine(position, target.Position);
        }
    }

    bool AcquireTarget() {
        Collider[] targets = Physics.OverlapSphere(
            transform.localPosition, targetingRange, enemyLayerMask
        );
        if (targets.Length > 0) {
            target = targets[0].GetComponent<TargetPoint>();
            Debug.Assert(target != null, "Targeted non-enemy!", targets[0]);
            return true;
        }
        target = null;
        return false;
    }

    bool TrackTarget() {
        if (target == null) {
            return false;
        }
        Vector3 a = transform.localPosition;
        Vector3 b = target.Position;
        if (Vector3.Distance(a, b) > targetingRange + 0.125f * target.Enemy.Scale) {
            target = null;
            return false;
        }
        return true;
    }
}
