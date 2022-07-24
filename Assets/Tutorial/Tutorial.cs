using UnityEngine;

[CreateAssetMenu(fileName ="New Tutorial", menuName ="Tutorial")]
public class Tutorial : ScriptableObject
{
    [SerializeField] internal string content;
    internal bool played = false;
}
