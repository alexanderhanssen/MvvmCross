﻿// MvxBindingCreator.cs

// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
//
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using MvvmCross.Binding.Bindings;
using MvvmCross.Platform;
using MvvmCross.Platform.Logging;
using Xamarin.Forms;

namespace MvvmCross.Forms.Bindings
{
    public abstract class MvxBindingCreator : IMvxBindingCreator
    {
        public void CreateBindings(object sender,
                                   object oldValue,
                                   object newValue,
                                   Func<string, IEnumerable<MvxBindingDescription>> parseBindingDescriptions)
        {
            var attachedObject = sender as BindableObject;

            if (attachedObject == null)
            {
                MvxFormsLog.Instance.Warn("Null attached Element seen in Bi.nd binding");
                return;
            }

            var text = newValue as string;
            if (string.IsNullOrEmpty(text))
                return;

            var bindingDescriptions = parseBindingDescriptions(text);
            if (bindingDescriptions == null)
                return;

            ApplyBindings(attachedObject, bindingDescriptions);
        }

        protected abstract void ApplyBindings(BindableObject attachedObject,
                                              IEnumerable<MvxBindingDescription> bindingDescriptions);
    }
}
