using System;
using System.Numerics;
using Gameplay.GoldMine.Config;
using UniRx;
using UnityEngine;

namespace Gameplay.GoldMine
{
    public interface IExtractable : IWorkable
    {
        ExtractableSO Info { get; }
        
        float Extract(float amount);
    }
}