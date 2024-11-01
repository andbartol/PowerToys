﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json;

using Microsoft.PowerToys.Settings.UI.Library.Interfaces;

namespace Microsoft.PowerToys.Settings.UI.Library
{
    public class PowerRenameLocalProperties : ISettingsConfig
    {
        public PowerRenameLocalProperties()
        {
            PersistState = false;
            MRUEnabled = false;
            MaxMRUSize = 0;
            ShowIcon = false;
            ExtendedContextMenuOnly = false;
            UseBoostLib = false;
        }

        private int _maxSize;

        public bool PersistState { get; set; }

        public bool MRUEnabled { get; set; }

        public int MaxMRUSize
        {
            get
            {
                return _maxSize;
            }

            set
            {
                if (value < 0)
                {
                    _maxSize = 0;
                }
                else
                {
                    _maxSize = value;
                }
            }
        }

        public bool ShowIcon { get; set; }

        public bool ExtendedContextMenuOnly { get; set; }

        public bool UseBoostLib { get; set; }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }

        // This function is required to implement the ISettingsConfig interface and obtain the settings configurations.
        public string GetModuleName()
        {
            string moduleName = PowerRenameSettings.ModuleName;
            return moduleName;
        }

        // This can be utilized in the future if the settings.json file is to be modified/deleted.
        public bool UpgradeSettingsConfiguration()
        {
            return false;
        }
    }
}
