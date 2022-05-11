﻿using Knife.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knife.DeferredDecals.Spawn
{
    public interface IDecalReceiver
    {
        void HittedByGPURaycast(GPURaycastDecalsTargetInfo hitInfo);
        void HittedByPhysicsRaycast(RaycastHit hitInfo);
        void HittedByPhysicsCollision(Collision collision);
        void HittedByParticle(ParticleCollisionEvent collisionEvent);
    }
}