//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.PowerShell.EditorServices.Components
{
    /// <summary>
    /// Provides a default implementation for the IComponentRegistry
    /// interface.
    /// </summary>
    public class ComponentRegistry : IComponentRegistry
    {
        private Dictionary<Type, object> componentRegistry =
            new Dictionary<Type, object>();

        /// <summary>
        /// Registers an instance of the specified component type
        /// or throws an ArgumentException if an instance has
        /// already been registered.
        /// </summary>
        /// <param name="componentType">
        /// The component type that the instance represents.
        /// </param>
        /// <param name="componentInstance">
        /// The instance of the component to be registered.
        /// </param>
        /// <returns>
        /// The provided component instance for convenience in assignment
        /// statements.
        /// </returns>
        public object Register(Type componentType, object componentInstance)
        {
            this.componentRegistry.Add(componentType, componentInstance);
            return componentInstance;
        }


        /// <summary>
        /// Gets the registered instance of the specified
        /// component type or throws a KeyNotFoundException if
        /// no instance has been registered.
        /// </summary>
        /// <param name="componentType">
        /// The component type for which an instance will be retrieved.
        /// </param>
        /// <returns>The implementation of the specified type.</returns>
        public object Get(Type componentType)
        {
            return this.componentRegistry[componentType];
        }

        /// <summary>
        /// Attempts to retrieve the instance of the specified
        /// component type and, if found, stores it in the
        /// componentInstance parameter.
        /// </summary>
        /// <param name="componentInstance">
        /// The out parameter in which the found instance will be stored.
        /// </param>
        /// <param name="componentType">
        /// The component type for which an instance will be retrieved.
        /// </param>
        /// <returns>
        /// True if a registered instance was found, false otherwise.
        /// </returns>
        public bool TryGet(Type componentType, out object componentInstance)
        {
            componentInstance = null;

            if (this.componentRegistry.TryGetValue(componentType, out componentInstance))
            {
                return componentInstance != null;
            }

            return false;
        }
    }
}
