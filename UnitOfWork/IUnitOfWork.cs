using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.UnitOfWork
{
    public interface IUnitOfWork
    {
        public void Save();

        public void Rollback();
    }
}
