using System;
using System.Linq;

namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.Group;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class GroupServices : IGroupServices
    {
        private readonly IGroupRepository groupRepository;
        private readonly IStudentRepository studentRepository;

        public GroupServices(IGroupRepository groupRepository, IStudentRepository studentRepository)
        {
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<GroupDto>> GetAllGroups()
        {
            var groups = await this.groupRepository.GetAll();

            foreach (var group in groups)
            {
                await AddRelatedEntities(group, false);
            }

            return groups.Adapt<IEnumerable<GroupDto>>();
        }

        public async Task<GroupDto> Get(int id)
        {
            var group = await this.groupRepository.Get(id);

            await this.AddRelatedEntities(group);

            return group.Adapt<GroupDto>();
        }

        public async Task<GroupDto> Create(GroupCreateDto group)
        {
            var groupModel = group.Adapt<Group>();

            groupModel.FormationDate = DateTime.Now;

            var newGroup = await this.groupRepository.Create(groupModel);

            await this.AddRelatedEntities(newGroup);

            return newGroup.Adapt<GroupDto>();
        }

        public async Task<GroupDto> Update(GroupUpdateDto group)
        {
            var groupModel = group.Adapt<Group>();

            var changedGroup = await this.groupRepository.Update(groupModel);

            await this.AddRelatedEntities(changedGroup);

            return changedGroup.Adapt<GroupDto>();
        }

        public async Task Delete(int id)
        {
            await this.groupRepository.Delete(id);
        }

        private async Task AddRelatedEntities(Group group, bool addAllStudents = true)
        {
            group.Head = await this.studentRepository.Get(group.HeadId);

            var students = (await this.studentRepository.GetByGroupId(group.Id)).ToList();

            group.StudentsCount = students.Count;

            if (addAllStudents)
            {
                group.Students = students;
            }
        }
    }
}