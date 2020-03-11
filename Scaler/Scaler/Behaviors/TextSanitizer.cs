using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Scaler.Behaviors
{
    public class TextSanitizer : Behavior<Entry>
    {
        public string RegexInput { get; set; }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            var value = entry?.Text;

            if (!string.IsNullOrWhiteSpace(value))
            {
                entry.Text = Regex.Replace(value, RegexInput, string.Empty);
            }
        }
    }
}
