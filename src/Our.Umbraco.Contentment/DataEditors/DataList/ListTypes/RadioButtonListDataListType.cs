﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.IO;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Contentment.DataEditors
{
    internal class RadioButtonListDataListType : IDataListType
    {
        public string Name => "Radio Button List";

        public string Description => "[Add a friendly description]";

        public string Icon => "icon-target";

        public string View => IOHelper.ResolveUrl(RadioButtonListDataEditor.DataEditorViewPath);

        [ConfigurationField(typeof(LayoutConfigurationField))]
        public string Orientation { get; set; }

        class LayoutConfigurationField : ConfigurationField
        {
            public LayoutConfigurationField()
            {
                var items = new[]
                {
                    new { label = "Horizontal", value = "horizontal" },
                    new { label = "Vertical", value = "vertical" }
                };

                Key = "orientation";
                Name = "Orientation";
                Description = "Select the layout of the options.";
                View = IOHelper.ResolveUrl(RadioButtonListDataEditor.DataEditorViewPath);
                Config = new Dictionary<string, object>
                {
                    { "orientation", "horizontal" },
                    { Constants.Conventions.ConfigurationEditors.Items, items },
                    { Constants.Conventions.ConfigurationEditors.DefaultValue, "vertical" }
                };
            }
        }
    }
}
