// 
// Author: Ian Davis <ian@innovatian.com>
// Copyright (c) 2009-2010, Innovatian Software, LLC
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using Ninject.Parameters;

    /// <summary>
    /// The host factory for NinjectServiceHosts
    /// </summary>
    public class NinjectServiceHostFactory : ServiceHostFactory
    {
        /// <summary>
        /// The kernel that is used to create instances.
        /// </summary>
        private static IKernel kernelInstance;

        /// <summary>
        /// Sets the kernel on this instance.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void SetKernel(IKernel kernel)
        {
            kernelInstance = kernel;
        }

        /// <summary>
        /// Creates a <see cref="T:System.ServiceModel.ServiceHost"/> for a
        /// specified type of service with a specific base address.
        /// </summary>
        /// <param name="serviceType">
        /// Specifies the type of service to host.
        /// </param>
        /// <param name="baseAddresses">
        /// The <see cref="T:System.Array"/> of type <see cref="T:System.Uri"/>
        /// that contains the base addresses for the service hosted.
        /// </param>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.ServiceHost"/> for the type of
        /// service specified with a specific base address.
        /// </returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var serviceTypeParameter = new ConstructorArgument("serviceType", serviceType);
            var baseAddressesParameter = new ConstructorArgument("baseAddresses", baseAddresses);
            return kernelInstance.Get<ServiceHost>(serviceTypeParameter, baseAddressesParameter);
        }
    }
}