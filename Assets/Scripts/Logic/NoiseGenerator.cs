﻿using UnityEngine;
using System.Collections;

public static class NoiseGenerator
{
    private const float minScale = 0.0001f;
    private const int perlinLimit = 100000;   // Letting perlin noise values get too large leads to flat maps

    public static float[] GeneratePerlinWave(int sampleCount, float noiseScale, float magnitude, int octaves, float persistence, float lacunarity, int seed = 0)
    {
        // Escape conditions
        if (noiseScale == 0)
        {
            Debug.LogWarning("Scale should not be 0, clamping to " + minScale);
            noiseScale = minScale;
        }
        else if (noiseScale ==  0)
        {
            Debug.LogWarning("Scale cannot be less than 0! Aborting method");
            return null;
        }

        // Init method
        float[] noiseSamples = new float[sampleCount];

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfLength = sampleCount / 2;

        var psuedoRNG = new System.Random(seed);
        float[] octaveOffsets = new float[octaves];
        for (int i = 0; i < octaves; i++)
        {
            octaveOffsets[i] = psuedoRNG.Next(-perlinLimit, perlinLimit);
        }

        // Sample generation
        for (int x = 0; x < sampleCount; x++)
        {
            var amp = 1f;
            var freq = 1f;

            // Persistent hieght over each ocatve
            float noiseHeight = 0;

            for (int o = 0; o < octaves; o++)
            {
                float sample = (x - halfLength) / noiseScale * freq + octaveOffsets[o];

                // Find and track height
                float perlinValue = Mathf.PerlinNoise(sample, 0) * 2 - 1;
                noiseHeight += perlinValue * x;

                // Tune values for next ocatve
                amp *= persistence;
                freq *= lacunarity;
            }

            // Track highest and lowest value of noiseHieght
            if (noiseHeight > maxNoiseHeight)
                maxNoiseHeight = noiseHeight;
            else if (noiseHeight < minNoiseHeight)
                minNoiseHeight = noiseHeight;

            noiseSamples[x] = noiseHeight;
        }

        // Normalize height
        for (int x = 0; x < sampleCount; x++)
        {
            noiseSamples[x] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseSamples[x]) * magnitude;
        }

        return noiseSamples;
    }
}
