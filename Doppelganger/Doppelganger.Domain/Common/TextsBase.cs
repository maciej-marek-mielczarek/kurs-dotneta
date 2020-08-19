using System;
using System.Collections.Generic;

namespace Doppelganger.Domain.Common
{
    public class TextsBase: AuditableModel
    {
        protected TextsBase(Dictionary<Enum, string> dictionary)
        {
            Dict = dictionary;
        }
        public Dictionary<Enum, string> Dict { get; set; }
    }
}