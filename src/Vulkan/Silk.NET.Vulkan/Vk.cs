using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Silk.NET.Core;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;
using Silk.NET.Core.Native;
using LibraryLoader = Silk.NET.Core.Loader.LibraryLoader;

namespace Silk.NET.Vulkan
{
    public partial class Vk
    {
        private readonly Dictionary<IntPtr, List<string>> _extensions = new Dictionary<IntPtr, List<string>>();
        public Instance? CurrentInstance { get; set; }
        public Device? CurrentDevice { get; set; }
        public static Version32 Version10 => new Version32(1, 0, 0);
        public static Version32 Version11 => new Version32(1, 1, 0);
        public static Version32 Version12 => new Version32(1, 2, 0);

        public static Version32 MakeVersion
            (uint major, uint minor, uint patch = 0) => new Version32(major, minor, patch);

        public static Vk GetApi()
        {
            var ctx = new MultiNativeContext
                (CreateDefaultContext(new VulkanLibraryNameContainer().GetLibraryName()), null);
            var ret = new Vk(ctx);
            ctx.Contexts[1] = new LamdaNativeContext
            (
                x =>
                {
                    if (x.EndsWith("ProcAddr"))
                    {
                        return default;
                    }

                    IntPtr ptr = default;
                    ptr = ret.GetInstanceProcAddr(ret.CurrentInstance.GetValueOrDefault(), x);
                    if (ptr != default)
                    {
                        return ptr;
                    }

                    ptr = ret.GetDeviceProcAddr(ret.CurrentDevice.GetValueOrDefault(), x);
                    return ptr;
                }
            );
            return ret;
        }

        public static Vk GetApi(InstanceCreateInfo info, out Instance instance) => GetApi(ref info, out instance);

        public static unsafe Vk GetApi(ref InstanceCreateInfo info, out Instance instance)
        {
            var ctx = new MultiNativeContext
                (CreateDefaultContext(new VulkanLibraryNameContainer().GetLibraryName()), null);
            var ret = new Vk(ctx);
            ctx.Contexts[1] = new LamdaNativeContext
            (
                x =>
                {
                    if (x.EndsWith("ProcAddr"))
                    {
                        return default;
                    }

                    IntPtr ptr = default;
                    ptr = ret.GetInstanceProcAddr(ret.CurrentInstance.GetValueOrDefault(), x);
                    if (ptr != default)
                    {
                        return ptr;
                    }

                    ptr = ret.GetDeviceProcAddr(ret.CurrentDevice.GetValueOrDefault(), x);
                    return ptr;
                }
            );

            fixed (InstanceCreateInfo* infoPtr = &info)
            {
                fixed (Instance* instancePtr = &instance)
                {
                    ret.CreateInstance(infoPtr, null, instancePtr);
                }
            }

            return ret;
        }

        public static Vk GetApi(ref InstanceCreateInfo info, ref AllocationCallbacks callbacks, out Instance instance)
        {
            var ctx = new MultiNativeContext
                (CreateDefaultContext(new VulkanLibraryNameContainer().GetLibraryName()), null);
            var ret = new Vk(ctx);
            ctx.Contexts[1] = new LamdaNativeContext
            (
                x =>
                {
                    if (x.EndsWith("ProcAddr"))
                    {
                        return default;
                    }

                    IntPtr ptr = default;
                    ptr = ret.GetInstanceProcAddr(ret.CurrentInstance.GetValueOrDefault(), x);
                    if (ptr != default)
                    {
                        return ptr;
                    }

                    ptr = ret.GetDeviceProcAddr(ret.CurrentDevice.GetValueOrDefault(), x);
                    return ptr;
                }
            );

            instance = default;
            ret.CreateInstance(in info, in callbacks, out instance);
            return ret;
        }

        /// <summary>
        /// Attempts to load the given instance extension.
        /// </summary>
        /// <param name="instance">The instance to load the extension from.</param>
        /// <param name="ext">The loaded instance extension, or null if load failed.</param>
        /// <typeparam name="T">The instance extension to load.</typeparam>
        /// <remarks>
        /// This function doesn't check that the extension is enabled - you will get an error later on if you attempt
        /// to call an extension function from an extension that isn't loaded.
        /// </remarks>
        /// <returns>Whether the extension is available and loaded.</returns>
        public bool TryGetInstanceExtension<T>(Instance instance, out T ext) where T : NativeExtension<Vk> =>
            !((ext = IsInstanceExtensionPresent(ExtensionAttribute.GetExtensionAttribute(typeof(T)).Name)
                ? (T)Activator.CreateInstance
                (typeof(T), new LamdaNativeContext(x => GetInstanceProcAddr(instance, x)))
                : null) is null);

        /// <summary>
        /// Attempts to load the given device extension.
        /// </summary>
        /// <param name="instance">The instance to load the extension from.</param>
        /// <param name="device">The device to load the extension from.</param>
        /// <param name="ext">The loaded device extension, or null if load failed.</param>
        /// <typeparam name="T">The device extension to load.</typeparam>
        /// <remarks>
        /// This function doesn't check that the extension is enabled - you will get an error later on if you attempt
        /// to call an extension function from an extension that isn't loaded.
        /// </remarks>
        /// <returns>Whether the extension is available and loaded.</returns>
        public bool TryGetDeviceExtension<T>
            (Instance instance, Device device, out T ext) where T : NativeExtension<Vk> =>
            !((ext = IsDeviceExtensionPresent(instance, ExtensionAttribute.GetExtensionAttribute(typeof(T)).Name)
                ? (T)Activator.CreateInstance
                    (typeof(T), new LamdaNativeContext(x => GetDeviceProcAddr(device, x)))
                : null) is null);

        /// <inheritdoc />
        [Obsolete("Use IsInstanceExtensionPresent instead.", true)]
        public override bool IsExtensionPresent(string extension) => IsInstanceExtensionPresent(extension);

        private List<string> _cachedInstanceExtensions = new List<string>();
        private Dictionary<IntPtr, List<string>> _cachedDeviceExtensions = new Dictionary<IntPtr, List<string>>();

        /// <summary>
        /// Checks whether the given instance extension is available.
        /// </summary>
        /// <param name="extension">The instance extension name.</param>
        /// <returns>Whether the instance extension is available.</returns>
        public unsafe bool IsInstanceExtensionPresent(string extension)
        {
            if (_cachedInstanceExtensions.Count == 0)
            {
                var extProperties = stackalloc ExtensionProperties[128];
                Add(_cachedInstanceExtensions, extProperties);
            }

            return _cachedInstanceExtensions.Contains(extension);
        }

        /// <summary>
        /// Checks whether the given device extension is available on any physical devices.
        /// </summary>
        /// <param name="instance">The Vulkan instance.</param>
        /// <param name="extension">The extension to check for.</param>
        /// <returns>Whether the device extension is available.</returns>
        public bool IsDeviceExtensionPresent(Instance instance, string extension)
            => IsDeviceExtensionPresent(instance, extension, out _);

        /// <summary>
        /// Checks whether the given device extension is available on the given physical device.
        /// </summary>
        /// <param name="device">The physical device.</param>
        /// <param name="extension">The extension to check for.</param>
        /// <returns>Whether the device extension is available.</returns>
        public unsafe bool IsDeviceExtensionPresent(PhysicalDevice device, string extension)
        {
            List<string> list;
            if (!_cachedDeviceExtensions.ContainsKey(device.Handle))
            {
                var extProperties = stackalloc ExtensionProperties[128];
                _cachedDeviceExtensions.Add(device.Handle, list = Add(device, new List<string>(), extProperties));
            }
            else
            {
                list = _cachedDeviceExtensions[device.Handle];
            }

            return list.Contains(extension);
        }

        /// <summary>
        /// Checks whether the given device extension is available, and returns the first physical device that provides
        /// it.
        /// </summary>
        /// <param name="instance">The Vulkan instance to use.</param>
        /// <param name="extension">The extension to check for.</param>
        /// <param name="device">The first physical device that provides the extension.</param>
        /// <returns>Whether the device extension is available.</returns>
        public unsafe bool IsDeviceExtensionPresent(Instance instance, string extension, out PhysicalDevice device)
        {
            var physicalDeviceCount = 0u;
            EnumeratePhysicalDevices(instance, &physicalDeviceCount, null);
            var physicalDevices = stackalloc PhysicalDevice[(int) physicalDeviceCount];
            EnumeratePhysicalDevices(instance, &physicalDeviceCount, physicalDevices);

            for (var i = 0; i < physicalDeviceCount; i++)
            {
                var physicalDevice = physicalDevices[i];
                if (IsDeviceExtensionPresent(physicalDevice, extension))
                {
                    device = physicalDevice;
                    return true;
                }
            }

            device = default;
            return false;
        }

        /// <summary>
        /// Clears all cached extension information, so that the next time extension-related functions are called the
        /// cached extension information is refreshed.
        /// </summary>
        public void PurgeExtensionCache()
        {
            _extensions.Clear();
            _cachedInstanceExtensions.Clear();
            _cachedDeviceExtensions.Clear();
        }

        private unsafe List<string> GetExtensions(Instance? instance, PhysicalDevice? device)
        {
            var l = new List<string>();
            var props = stackalloc ExtensionProperties[128];

            if (instance.HasValue)
            {
                if (!device.HasValue)
                {
                    var physicalDeviceCount = 0u;
                    EnumeratePhysicalDevices(instance.Value, &physicalDeviceCount, null);
                    var physicalDevices = stackalloc PhysicalDevice[(int) physicalDeviceCount];
                    EnumeratePhysicalDevices(instance.Value, &physicalDeviceCount, physicalDevices);

                    for (var i = 0; i < physicalDeviceCount; i++)
                    {
                        var physicalDevice = physicalDevices[i];
                        Add(physicalDevice, l, props);
                    }
                }
                else
                {
                    Add(device.Value, l, props);
                }
            }

            return l.Distinct().ToList();
        }

        private unsafe void Add(ICollection<string> l, ExtensionProperties* props)
        {
            var result = Vulkan.Result.Incomplete;
            while (result == Vulkan.Result.Incomplete)
            {
                var instanceExtPropertiesCount = 128u;
                result = EnumerateInstanceExtensionProperties((byte*) 0, &instanceExtPropertiesCount, props);
                if (result == Vulkan.Result.Success || result == Vulkan.Result.Incomplete)
                {
                    for (var i = 0; i < instanceExtPropertiesCount; i++)
                    {
                        l.Add(Marshal.PtrToStringAnsi((IntPtr) props[i].ExtensionName));
                    }
                }
            }
        }

        private unsafe List<string> Add(PhysicalDevice physicalDevice, List<string> l, ExtensionProperties* props)
        {
            var result = Vulkan.Result.Incomplete;
            while (result == Vulkan.Result.Incomplete)
            {
                var deviceExtPropertiesCount = 128u;
                result = EnumerateDeviceExtensionProperties
                    (physicalDevice, (byte*) 0, &deviceExtPropertiesCount, props);
                if (result == Vulkan.Result.Success || result == Vulkan.Result.Incomplete)
                {
                    for (var j = 0; j < deviceExtPropertiesCount; j++)
                    {
                        l.Add(Marshal.PtrToStringAnsi((IntPtr) props[j].ExtensionName));
                    }
                }
            }

            return l;
        }
    }
}
