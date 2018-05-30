using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuffable {

    void Apply(StatManager target);
    bool IsPersistant { get; set; }
}
