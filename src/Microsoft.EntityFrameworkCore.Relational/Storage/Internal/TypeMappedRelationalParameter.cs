﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Utilities;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    public class TypeMappedRelationalParameter : IRelationalParameter
    {
        public TypeMappedRelationalParameter(
            [NotNull] string invariantName,
            [NotNull] string name,
            [NotNull] RelationalTypeMapping relationalTypeMapping,
            [CanBeNull] bool? nullable)
        {
            Check.NotEmpty(invariantName, nameof(invariantName));
            Check.NotEmpty(name, nameof(name));
            Check.NotNull(relationalTypeMapping, nameof(relationalTypeMapping));

            InvariantName = invariantName;
            Name = name;
            RelationalTypeMapping = relationalTypeMapping;
            IsNullable = nullable;
        }

        public virtual string InvariantName { get; }

        public virtual string Name { get; }

        // internal for testing
        internal RelationalTypeMapping RelationalTypeMapping { get; }

        // internal for testing
        internal bool? IsNullable { get; }

        public virtual void AddDbParameter(DbCommand command, object value)
        {
            Check.NotNull(command, nameof(command));

            command.Parameters
                .Add(RelationalTypeMapping
                    .CreateParameter(command, Name, value, IsNullable));
        }
    }
}
