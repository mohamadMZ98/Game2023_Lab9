using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable 
{
   public abstract void OnSave();
   public abstract void OnLoad();
}
