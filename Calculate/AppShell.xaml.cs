﻿namespace Calculate
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ResultPage), typeof(ResultPage));
        }
    }
}
