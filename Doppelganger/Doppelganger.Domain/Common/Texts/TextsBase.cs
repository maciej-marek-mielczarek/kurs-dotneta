using System;
using System.Collections.Generic;

namespace Doppelganger.Domain.Common.Texts
{
    public class TextsBase: AuditableModel
    {
        protected TextsBase(Dictionary<Enum, string> dictionary)
        {
            Dict = dictionary;
        }
        public Dictionary<Enum, string> Dict { get; }
    }
}