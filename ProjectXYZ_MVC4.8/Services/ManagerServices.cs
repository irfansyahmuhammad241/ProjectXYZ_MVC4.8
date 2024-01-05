using ProjectXYZ_MVC4._8.Contracts;
using ProjectXYZ_MVC4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectXYZ_MVC4._8.Services
{
    public class ManagerServices
    {
        private readonly IManagerRepository _manager;

        public ManagerServices(IManagerRepository managerLogistics)
        {
            _manager = managerLogistics;

        }

        public IEnumerable<Manager> GetAllManager()
        {
            var manager = _manager.GetAll();
            if (!manager.Any())
            {
                return null; // manager not found
            }

            var toDto = manager.Select(managerEntity =>
                                                new Manager
                                                {
                                                    ID = managerEntity.ID,
                                                    ManagerName = managerEntity.ManagerName,
                                                    ManagerEmail = managerEntity.ManagerEmail,
                                                    ManagerPhone = managerEntity.ManagerPhone,

                                                }).ToList();

            return toDto; // manager found
        }

        public Manager GetManagerId(int id)
        {
            var manager = _manager.GetById(id);
            if (manager is null)
            {
                return null; // manager not found
            }

            var toDto = new Manager
            {
                ID = manager.ID,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
            };

            return toDto; // manager roles found
        }

        public Manager CreateNewManager(Manager newManager)
        {
            var manager = new Manager
            {
                ManagerName = newManager.ManagerName,
                ManagerEmail = newManager.ManagerEmail,
                ManagerPhone = newManager.ManagerPhone,
            };

            var createdManager = _manager.Create(manager);
            if (createdManager is null)
            {
                return null; // manager not created
            }

            var toDto = new Manager
            {
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
            };

            return toDto; // manager created
        }

        public int UpdateManager(Manager updateManager)
        {
            var isExist = _manager.IsExist(updateManager.ID);
            if (!isExist)
            {
                return -1; // Manager Not Found
            }

            var getManager = _manager.GetById(updateManager.ID);

            getManager.ManagerName = updateManager.ManagerName;
            getManager.ManagerEmail = updateManager.ManagerEmail;
            getManager.ManagerPhone = updateManager.ManagerPhone;

            var isUpdate = _manager.Update(getManager);
            return isUpdate ? 1 : 0;
        }

        public int DeleteManager(int id)
        {
            var isExist = _manager.IsExist(id);
            if (!isExist)
            {
                return -1; // manager not found
            }

            var manager = _manager.GetById(id);
            var isDelete = _manager.Delete(manager);
            if (!isDelete)
            {
                return 0; // manager not deleted
            }

            return 1;
        }
    }
}