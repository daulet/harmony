using System;
using System.Collections.Generic;

namespace Harmony.Core
{
    internal class DependencyTree
    {
        private readonly Dictionary<Type, DependencyNode> _knownNodes;

        public DependencyTree()
        {
            _knownNodes = new Dictionary<Type, DependencyNode>();
        }

        public void AddDependency(Type subjecType, Type dependsOnType)
        {
            var subjectNode = GetNode(subjecType);
            var dependsOnNode = GetNode(dependsOnType);

            subjectNode.AddDependency(dependsOnNode);
        }

        public void AddNode(Type knownType)
        {
            GetNode(knownType);
        }

        private DependencyNode GetNode(Type type)
        {
            if (!_knownNodes.ContainsKey(type))
            {
                _knownNodes.Add(type, new DependencyNode(type));
            }
            return _knownNodes[type];
        }
    }
}
