﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinExplorer.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusyIndicatorDialog
    {
        public BusyIndicatorDialog()
        {
            this.InitializeComponent();
        }
    }
}