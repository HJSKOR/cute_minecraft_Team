using Character;
using System.Linq;
using UnityEngine;

namespace Util
{
    public class RigidBodyHandler : MonoBehaviour
    {
        [SerializeField] Rigidbody mRigid;

        Rigidbody Rigid
        {
            get
            {
                Debug.Assert(mRigid != null);
                return mRigid;
            }
        }

        public void Explosion(float force)
        {
            CharacterComponent.Instances.Where(x =>
                    Vector3.Distance(x.transform.position, mRigid.transform.position) < force * 0.1f)
                .ToList()
                .ForEach(x => x.Rigid.AddExplosionForce(force, transform.position, force * 0.1f, force * 0.5f));
        }

        public void AddForce(float power)
        {
            Rigid.AddForce(transform.forward * power);
        }

        public void ResetVelocity()
        {
            Rigid.velocity = Vector3.zero;
        }

        public void SetKinematic(bool kinematic)
        {
            Rigid.isKinematic = kinematic;
        }
    }
}