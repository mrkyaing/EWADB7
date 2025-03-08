﻿using HRMS.Web.DAO;
using HRMS.Web.Respostories.Domain;

namespace HRMS.Web.UnitOfWorks {
    public class UnitOfWork : IUnitOfWork {
        private readonly HRMSWebDbContext _dbContext;

        public UnitOfWork(HRMSWebDbContext dbContext) {
            this._dbContext = dbContext;
        }

        private IPositoryRepository positoryRepository;
        public IPositoryRepository PositoryRepository {
            get {
                return positoryRepository = positoryRepository ?? new PositionRepository(_dbContext);
            }
        }

        private IDepartmentRepository departmentRepository;
        public IDepartmentRepository DepartmentRepository {
            get {
                return departmentRepository = departmentRepository ?? new DepartmentRepository(_dbContext);
            }
        }

        public void Commit() {
            _dbContext.SaveChanges();
        }

        public void Rollback() {
            _dbContext.Dispose();
        }
    }
}
