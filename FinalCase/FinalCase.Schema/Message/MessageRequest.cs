﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;
public class MessageRequest
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string MessageContent { get; set; }
}

