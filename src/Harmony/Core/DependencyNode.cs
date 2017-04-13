using System;
using System.Collections.Generic;

namespace Harmony.Core
{
    internal class DependencyNode
    {
        private readonly Type _type;
        private readonly HashSet<DependencyNode> _dependencies;

        public DependencyNode(Type type)
        {
            _type = type;
            _dependencies = new HashSet<DependencyNode>();
        }

        public void AddDependency(DependencyNode dependency)
        {
            _dependencies.Add(dependency);
        }

        #region Comparison overrides

        public override bool Equals(object obj)
        {
            var otherNode = obj as DependencyNode;
            if (otherNode != null)
            {
                return _type == otherNode._type;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _type.GetHashCode();
        }

        #endregion
    }
}