//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

using Microsoft.PowerShell.EditorServices.Transport.Stdio.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.PowerShell.EditorServices.Transport.Stdio.Event
{
    [MessageTypeName("output")]
    public class OutputEvent : EventBase<OutputEventBody>
    {
    }

    public class OutputEventBody
    {
        public string Category { get; set; }

        public string Output { get; set; }
    }
}

