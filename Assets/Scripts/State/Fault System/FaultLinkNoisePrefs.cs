using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName ="Fault Lines/Noise Prefs")]
public class FaultLinkNoisePrefs : ScriptableObject
{
    public int SampleCount = 16;
    [SerializeField] private int seed = 0;
    public int Seed => RandomSeed ? random.Next() : seed;
    public bool RandomSeed;
    public float NoiseScale = 2f;
    public float Magnitude = 1f;
    public int Octaves = 3;
    public float Persistence = 0.5f;
    public float Lacunarity = 2f;
    public AnimationCurve DeviationCurve;

    private System.Random random = new System.Random();
}