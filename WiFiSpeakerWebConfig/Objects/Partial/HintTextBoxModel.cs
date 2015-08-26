using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiFiSpeakerWebConfig.Objects
{
    public class HintTextBoxModel
    {
        public string Placeholder { get; set; }
        public string Icon { get; set; }
        public string InputName { get; set; }
        public HintTextBoxModel() : this("", "", "") { }
        public HintTextBoxModel(string placeHolder, string icon, string inputName)
        {
            this.Placeholder = placeHolder;
            this.Icon = icon;
            this.InputName = inputName;
        }
    }
}
