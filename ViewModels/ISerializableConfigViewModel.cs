using SuchByte.WindowsUtils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.WindowsUtils.ViewModels
{
    internal interface ISerializableConfigViewModel
    {
        protected ISerializableConfiguration SerializableConfiguration { get; }

        void SetConfig();

        bool SaveConfig();
    }
}
