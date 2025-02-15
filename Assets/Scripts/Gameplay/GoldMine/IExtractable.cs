using System;
using System.Numerics;
using UniRx;
using UnityEngine;

namespace Gameplay.GoldMine
{
    public interface IExtractable
    {
        Transform Transform { get; }
        bool IsEnded { get;  }
        IObservable<Unit> OnEnded { get; }
        IObservable<float> Extract(float amount, float extractionSpeed);
       
    }
}