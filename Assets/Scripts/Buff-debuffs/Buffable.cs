using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buffable : IBuffable {
    protected float _finishTime;
    protected int _amountOfProcs;
    public bool IsPersistant { get; set; }

    public StatManager Target {
        get {
            return target;
        }

        set {
            target = value;
        }
    }

    protected int _currentProc = 1;
    protected float _procInterval;
    protected float _duration = 0;
    private StatManager target;

    public Buffable(StatManager target, bool isPersistant, float finishTime, int procs) {
        IsPersistant = isPersistant;
        _finishTime = finishTime;
        _amountOfProcs = procs;
        Target = target;
        Init();
    }

    public virtual void Init() {
        _procInterval = _finishTime / _amountOfProcs;
    }

    public virtual void Apply(StatManager target) {
        target.AddBuffable(this);
    }

    protected abstract void Proc();

    public void UpdateBuff() {
        _duration += Time.deltaTime;
        if (_duration > _procInterval * _currentProc) {
            Proc();
            _currentProc++;
            if (!IsPersistant) {
                if (_duration >= _finishTime - _procInterval) {
                    target.RemoveBuffable(this);
                }
            }
        }
    }
}
