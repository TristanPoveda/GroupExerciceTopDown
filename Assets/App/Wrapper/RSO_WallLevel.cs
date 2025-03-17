using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RSO_WallLevel", menuName = "RSO/Game/RSO_WallLevel")]
public class RSO_WallLevel : BT.ScriptablesObject.RuntimeScriptableObject<List<Collider>>{}