using System;
using System.Numerics;
using Gameplay.GoldMine.Config;
using UniRx;
using UnityEngine;

namespace Gameplay.GoldMine
{
    public interface IExtractable
    {
        Transform Transform { get; }
        ExtractableSO Info { get; }
        bool IsEnded { get;  }
        IObservable<Unit> OnEnded { get; }
        IObservable<float> Extract(float amount, float extractionSpeed);
       
    }
}