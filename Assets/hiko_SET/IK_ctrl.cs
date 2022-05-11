using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_ctrl : MonoBehaviour
{
    public Animator Animator { get { return GetComponent<Animator>(); } }


    [SerializeField]
    private Transform _rightHandIkTarget;
    [SerializeField]
    private Transform _leftHandIkTarget;
    [SerializeField]
    private Transform _lookTarget;

    [SerializeField, Range(0, 1)]
    public float _ikWeight;

    private void OnAnimatorIK(int layerIndex)
    {
        if (_rightHandIkTarget != null)
        {
            Animator.SetLookAtWeight(_ikWeight);
            Animator.SetLookAtPosition(_lookTarget.position);
        }

        if (_rightHandIkTarget != null)
        {
            Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _ikWeight);
            Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _ikWeight);
            Animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandIkTarget.position);
            Animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandIkTarget.rotation);
        }


        if (_leftHandIkTarget != null)
        {
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _ikWeight);
            Animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _ikWeight);
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandIkTarget.position);
            Animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandIkTarget.rotation);
        }
    }
}