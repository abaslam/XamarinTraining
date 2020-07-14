namespace XamarinExplorer.Models
{
    using System;

    public class MenuModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Label { get; set; }
        public string Page { get; set; }
    }
}
