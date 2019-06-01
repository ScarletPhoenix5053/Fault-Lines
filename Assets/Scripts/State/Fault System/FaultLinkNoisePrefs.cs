using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName ="Fault Lines/Noise Prefs")]
public class FaultLinkNoisePrefs : ScriptableObject
{
    public int SampleCount = 16;
    public int Seed = 0;
    public int Octaves = 3;
    public float Scale = 1f;
    public float Persistence = 0.5f;
    public float Lacunarity = 2f;
}