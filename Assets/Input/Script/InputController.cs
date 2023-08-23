using System;
using UnityEngine;

public enum DragType
{
    Up, Down, Left, Right
}

public class InputController : MonoBehaviour
{
    public static Action<DragType> OnDrag;
}
