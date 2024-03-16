using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    public ImageAnimation anim;

    private sealed class _Working_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal TransporterController _this;

        internal object _current;

        internal bool _disposing;

        internal int _PC;

        object IEnumerator<object>.Current
        {
            get { return this._current; }
        }

        object IEnumerator.Current
        {
            get { return this._current; }
        }

        public _Working_c__Iterator0()
        {
        }

        public bool MoveNext()
        {
            uint num = (uint) this._PC;
            this._PC = -1;
            switch (num)
            {
                case 0u:
                    this._this.isIdle = false;
                    this._this.ApplyAnimationSpeed(2,
                        this._this.kitchenController.boostController.walkingSpeedBoost);
                    break;
                case 1u:
                    break;
                case 2u:
                    //todo:Chuong
                    this._this.ApplyAnimationSpeed(3,
                        this._this.kitchenController.boostController.walkingSpeedBoost);
                    goto IL_1E3;
                case 3u:
                    goto IL_1E3;
                case 4u:
                    goto IL_2DD;
                default:
                    return false;
            }

            if (!(this._this.myselfTransform.localPosition != this._this.exploitedPoint))
            {
                this._this.ApplyAnimationSpeed(1,
                    this._this.kitchenController.boostController.cookingSpeedBoost);
                this._current = new WaitForSeconds(this._this.cookingTime);
                if (!this._disposing)
                {
                    this._PC = 2;
                }

                return true;
            }

            this._this.myselfTransform.localPosition = Vector3.MoveTowards(this._this.myselfTransform.localPosition,
                this._this.exploitedPoint, Time.deltaTime * this._this.walkingSpeed);
            this._current = null;
            if (!this._disposing)
            {
                this._PC = 1;
            }

            return true;
            IL_1E3:
            if (this._this.myselfTransform.localPosition != this._this.gatheringPoint)
            {
                this._this.myselfTransform.localPosition = Vector3.MoveTowards(this._this.myselfTransform.localPosition,
                    this._this.gatheringPoint, Time.deltaTime * this._this.walkingSpeed);
                this._current = null;
                if (!this._disposing)
                {
                    this._PC = 3;
                }

                return true;
            }

            //todo:Chuong

            this._this.kitchenController.SetCash(this._this.kitchenController.kitchenProperties.transporterCapacity);
            this._this.ApplyAnimationSpeed(2, this._this.kitchenController.boostController.walkingSpeedBoost);
            IL_2DD:
            if (this._this.myselfTransform.localPosition != this._this.restingPosition)
            {
                this._this.myselfTransform.localPosition = Vector3.MoveTowards(this._this.myselfTransform.localPosition,
                    this._this.restingPosition, Time.deltaTime * this._this.walkingSpeed);
                this._current = null;
                if (!this._disposing)
                {
                    this._PC = 4;
                }

                return true;
            }

            if (!this._this.kitchenController.managerController.hasManager)
            {
                this._this.ApplyAnimationSpeed(0, 1f);
                this._this.isIdle = true;
            }
            else
            {
                this._this.StartCoroutine(this._this.Working());
            }

            this._PC = -1;
            return false;
        }

        public void Dispose()
        {
            this._disposing = true;
            this._PC = -1;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }


    private Vector3 gatheringPoint;

    private Vector3 exploitedPoint;

    private Vector3 restingPosition;

    private Transform myselfTransform;

    private KitchenController kitchenController;

    private float cookingTime;

    private float walkingSpeed;

    public float movement;

    public bool isIdle = true;

    private void Awake()
    {
        this.myselfTransform = base.transform;
    }

    public void Initialize(KitchenController kitchenController)
    {
        this.kitchenController = kitchenController;
        this.restingPosition = base.transform.localPosition;
        this.exploitedPoint = kitchenController.exploitedPoint.localPosition;
        this.gatheringPoint = kitchenController.gatheringPoint.localPosition;
    }

    public void StartWorking()
    {
        if (!this.isIdle)
        {
            return;
        }

        base.StartCoroutine(this.Working());
    }

    private IEnumerator Working()
    {
        TransporterController._Working_c__Iterator0 _Working_c__Iterator =
            new TransporterController._Working_c__Iterator0();
        _Working_c__Iterator._this = this;
        return _Working_c__Iterator;
    }

    private void ApplyAnimationSpeed(int clip, float speed = 1f)
    {
        if (clip != 2 && clip != 3)
        {
            if (clip == 1)
            {
                this.cookingTime = (float) (this.kitchenController.kitchenProperties.transporterCapacity /
                                            (this.kitchenController.kitchenProperties.workingSpeed * (double) speed));
            }
        }
        else
        {
            this.walkingSpeed = this.kitchenController.kitchenProperties.walkingSpeed * speed * this.movement;
        }

        switch (clip)
        {
            case 0:
                anim.ChangeAnim(0);
                Rotate();
                break;
            case 1:
                Rotate();
                anim.ChangeAnim(0);
                break;
            case 2:
                Rotate();
                anim.ChangeAnim(1);
                break;
            case 3:
                Rotate();
                anim.ChangeAnim(2);
                break;
        }
    }

    private void Rotate(bool b = false)
    {
        anim.transform.rotation = b ? Quaternion.identity : Quaternion.Euler(Vector3.up * 180);
    }
}