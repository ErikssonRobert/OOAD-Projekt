using System;
using System.Collections.Generic;
using LoGoPrototype;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms;
using NavigationPage = Xamarin.Forms.PlatformConfiguration.iOSSpecific.NavigationPage;

namespace LoGoPrototype.Views
{
    public partial class Main : TabbedPage
    {
        public Main()
        {
            InitializeComponent();
            this.CurrentPageChanged += (object sender, EventArgs e) =>
            (Children[1] as Logo).Refresh();
        }


    }
}
