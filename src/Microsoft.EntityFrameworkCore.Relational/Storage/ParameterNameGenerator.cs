// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.EntityFrameworkCore.Storage
{
    public class ParameterNameGenerator
    {
        private int _count;

        public virtual string GenerateNext() => $"p{_count++}";

        public virtual void Reset() => _count = 0;
    }
}
