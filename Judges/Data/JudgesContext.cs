using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Judges.Data
{
    public class JudgesContext : DbContext
    {
        public JudgesContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    }
}
