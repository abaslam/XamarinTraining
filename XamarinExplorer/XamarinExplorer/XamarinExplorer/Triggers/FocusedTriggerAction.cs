using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinExplorer.Triggers
{
    public class FocusedTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry entry)
        {
            entry.BackgroundColor = Color.Red;
        }
    }
}
