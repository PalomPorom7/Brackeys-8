using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    public Vector2  horizontalIndicatorPosition = new Vector2(0, 1.5f),
                    verticalIndicatorPosition   = new Vector2(0, 2.5f),
                    horizontalBodySize          = new Vector2(2, 1),
                    verticalBodySize            = new Vector2(1, 2),
                    horizontalFacePosition      = new Vector2(0, 0.5f),
                    verticalFacePosition        = new Vector2(0, 1.5f),
                    horizontalColliderOffset    = new Vector2(0, 0.5f),
                    verticalColliderOffset      = new Vector2(0, 1.0f);
}
