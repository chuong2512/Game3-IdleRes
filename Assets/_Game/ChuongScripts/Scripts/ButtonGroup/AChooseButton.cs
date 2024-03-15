using System;
using UnityEngine;
using UnityEngine.Events;

namespace ChuongCustom
{
    public abstract class AChooseButton : AButton
    {
      
        public abstract void OnChoose();

        public abstract void OnUnChoose();
    }
}