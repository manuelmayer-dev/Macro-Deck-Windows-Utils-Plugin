using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.WindowsUtils.Models
{
    public class IconImportModel
    {

        public string IconPack { get; set; }

        public string IconId { get; set; }

        public string ToString()
        {
            return $"{this.IconPack}.{this.IconId}";
        }

    }
}
