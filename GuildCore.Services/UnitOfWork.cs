using GuildCore.Entities;
using GuildCore.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Services
{
    public class UnitOfWork : IDisposable
    {
        private readonly GeneralDbContext _context = null;
     
        private BannerRepository _roleRepository = null;

        public UnitOfWork(GeneralDbContext context)
        {
            _context = context;
        }
        //public SMUserRepository SMUserRepository
        //{
        //    get { return _userRepository ?? (_userRepository = new SMUserRepository(_context)); }
        //}
        //public SMUserRoleRepository SMUserRoleRepository
        //{
        //    get { return _userRoleRepository ?? (_userRoleRepository = new SMUserRoleRepository(_context)); }
        //}
        public BannerRepository RoleRepository
        {
            get
            {
                return _roleRepository ?? (_roleRepository = new BannerRepository(_context));
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
