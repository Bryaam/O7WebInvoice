// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Web.Common.Security.Entity;

namespace Angkor.O7Web.Interface.Security.Model
{
    public class SwitchModuleViewModel : O7ViewModel
    {
        public SwitchModuleViewModel()
        {
            Modules = new List<Module>();
        }

        public List<Module> Modules { get; set; }
    }
}