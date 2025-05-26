using CQRS.Data.Models;
using MediatR;

namespace CQRS.Command
{
    public class AddDepartmentCommand : IRequest<Department>
    {
        public Department Department { get; set; }
    }

    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            _departmentRepository.Add(request.Department);
            _departmentRepository.SaveChanges();
            return request.Department;
        }
    }
}
