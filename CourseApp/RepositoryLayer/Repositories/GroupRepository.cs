using DomainLayer.Entities;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class GroupRepository : IRepository<Group>
    {

        public void Create(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Group>.datas.Add(entity);
        }

        public void Delete(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();
            AppDbContext<Group>.datas.Remove(entity);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return AppDbContext<Group>.datas.Find(predicate);
        }

        public List<Group> GetAll(Predicate<Group> predicate = null)
        {
            return predicate == null ? AppDbContext<Group>.datas : AppDbContext<Group>.datas.FindAll(predicate);
        }

        public void Update(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();
            //int capacity;
            var group = Get(m => m.Id == entity.Id);

            if (group != null)
            {
                if (String.IsNullOrEmpty(entity.Name))  
                {
                    entity.Name = group.Name;            
                }
                else                                      
                {
                    group.Name = entity.Name;
                }
                if (group.Capacity == 0)
                {
                    entity.Capacity = group.Capacity;
                }
                else
                {
                    group.Capacity = group.Capacity;
                }

                if (String.IsNullOrEmpty(entity.Capacity.ToString()))
                {
                    group.Capacity = entity.Capacity;
                }
                else
                {
                     entity.Capacity = group.Capacity;
                }

            }
            else
            {
                throw new ArgumentNullException();
            }
            group.Teacher = entity.Teacher;

        }
    }
}
