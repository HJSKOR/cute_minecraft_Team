using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util
{
    public class ANDComponent : Condition
    {
        [SerializeField] List<Condition> mConditions;

        public override bool IsTrue()
        {
            if (mConditions.Count != 0)
            {
                return mConditions.All(x => x.IsTrue());
            }

            Debug.Log("Condition count : 0");
            return true;
        }

        public override void SetFalse()
        {
            foreach (var condition in mConditions)
            {
                condition.SetFalse();
            }
        }
    }
}