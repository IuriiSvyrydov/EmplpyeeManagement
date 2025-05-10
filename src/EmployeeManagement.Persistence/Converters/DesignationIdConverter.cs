using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities.Designations.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters
{
    public class DesignationIdConverter : ValueConverter<DesignationId, Guid>
    {
        public DesignationIdConverter() : base(e => e.Value,
            id => DesignationId.Create(id).Value)
        {

        }

    }

    public sealed class DesignationIdComparer : ValueComparer<DesignationId>
    {
        public DesignationIdComparer() : base(
            (x, y) => x!.Value == y!.Value,
            x => x.Value.GetHashCode())
        {

        }
    }
}
