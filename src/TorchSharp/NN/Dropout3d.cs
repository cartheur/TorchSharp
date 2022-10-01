// Copyright (c) .NET Foundation and Contributors.  All Rights Reserved.  See LICENSE in the project root for license information.
using System;
using System.Runtime.InteropServices;
using static TorchSharp.torch;

namespace TorchSharp
{
    using Modules;

    namespace Modules
    {
        /// <summary>
        /// This class is used to represent a Dropout3d module.
        /// </summary>
        public class Dropout3d : torch.nn.Module<Tensor, Tensor>
        {
            internal Dropout3d(IntPtr handle, IntPtr boxedHandle) : base(handle, boxedHandle) { }

            [DllImport("LibTorchSharp")]
            private static extern IntPtr THSNN_Dropout3d_forward(torch.nn.Module<Tensor, Tensor>.HType module, IntPtr tensor);

            public override Tensor forward(Tensor tensor)
            {
                var res = THSNN_Dropout3d_forward(handle, tensor.Handle);
                if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Tensor(res);
            }
        }
    }

    public static partial class torch
    {
        public static partial class nn
        {
            [DllImport("LibTorchSharp")]
            extern static IntPtr THSNN_Dropout3d_ctor(double p, [MarshalAs(UnmanagedType.U1)] bool inplace, out IntPtr pBoxedModule);

            /// <summary>
            /// Randomly zero out entire channels (a channel is a 3D feature map, e.g., the jj -th channel of the ii -th sample in the batched input is a 3D tensor \text{input}[i, j]input[i,j] ).
            /// Each channel will be zeroed out independently on every forward call with probability p using samples from a Bernoulli distribution.
            /// </summary>
            /// <param name="p">Probability of an element to be zeroed. Default: 0.5</param>
            /// <param name="inplace">If set to true, will do this operation in-place. Default: false</param>
            /// <returns></returns>
            static public Dropout3d Dropout3d(double p = 0.5, bool inplace = false)
            {
                var handle = THSNN_Dropout3d_ctor(p, inplace, out var boxedHandle);
                if (handle == IntPtr.Zero) { torch.CheckForErrors(); }
                return new Dropout3d(handle, boxedHandle);
            }

            public static partial class functional
            {
                [DllImport("LibTorchSharp")]
                extern static IntPtr THSNN_dropout3d(IntPtr input, double p, [MarshalAs(UnmanagedType.U1)] bool training, [MarshalAs(UnmanagedType.U1)] bool inplace);

                /// <summary>
                /// Randomly zero out entire channels (a channel is a 3D feature map, e.g., the jj -th channel of the ii -th sample in the batched input is a 3D tensor \text{input}[i, j]input[i,j] ).
                /// Each channel will be zeroed out independently on every forward call with probability p using samples from a Bernoulli distribution.
                /// </summary>
                static public Tensor dropout3d(Tensor input, double p = 0.5, bool training = true, bool inplace = false)
                {
                    var res = THSNN_dropout3d(input.Handle, p, training, inplace);
                    if (res == IntPtr.Zero) { torch.CheckForErrors(); }
                    return new Tensor(res);
                }
            }
        }
    }
}
