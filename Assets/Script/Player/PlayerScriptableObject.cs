using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Custom/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public GameObject stencilSphere;
    public float stencilIndex;

}
