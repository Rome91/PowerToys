﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows;
using TwoWayIPCLibLib;

namespace Microsoft.PowerToys.Settings.UI.Runner
{
    public class Program
    {
        /// <summary>
        /// Create an instance of the  IPC wrapper.
        /// </summary>
        private static ITwoWayIPCManager Ipcmanager = new TwoWayIPCManager();

        [STAThreadAttribute()]
        public static void Main(string[] args)
        {
            using (new UI.App())
            {
                App app = new App();
                app.InitializeComponent();

                if (args.Length > 1)
                {
                    Ipcmanager.Initialize(args[1], args[0]);
                    app.Run();
                }
                else
                {
                    MessageBox.Show(
                        "The application cannot be run as a standalone process. Please start the application through the runner.",
                        "Forbidden",
                        MessageBoxButton.OK);
                    app.Shutdown();
                }
            }
        }

        public static ITwoWayIPCManager GetTwoWayIPCManager()
        {
            return Ipcmanager;
        }
    }
}