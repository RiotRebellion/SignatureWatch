using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureWatch.UseCases.Features.Common.Utils
{
    public class StringUtil
    {
        protected internal bool IsValueHasLettersOnly(string value) => value.All(Char.IsLetter);

        protected internal string ParseToLower(string value) => value.ToLower();
    }
}
